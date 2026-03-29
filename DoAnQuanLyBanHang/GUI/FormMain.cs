using System;
using System.Windows.Forms;
using System.Linq;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;

namespace DoAnQuanLyBanHang
{
    public partial class FormMain : Form
    {
        private readonly BUS.DashboardBUS dashboardBUS = new BUS.DashboardBUS();
        private Form activeForm = null;
        private Panel pnlHome;

        public FormMain()
        {
            InitializeComponent();
            SetupChart();
            InitializeHomePanel();
        }

        private void InitializeHomePanel()
        {
            pnlHome = new Panel();
            pnlHome.Name = "pnlHome";
            pnlHome.Dock = DockStyle.Fill;
            pnlHome.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);

            // Chuyển các control từ pnContent vào pnlHome 
            // Lưu ý: Các control này đang là con của pnContent từ Designer
            pnlHome.Controls.Add(cboFilter);
            pnlHome.Controls.Add(lblDashboardTitle);
            pnlHome.Controls.Add(pnlKPIContainer);
            pnlHome.Controls.Add(pnlChartContainer);
            
            pnContent.Controls.Add(pnlHome);
            pnlHome.BringToFront();
        }

        private void SetupChart()
        {
            if (crtRevenue == null)
            {
                crtRevenue = new LiveCharts.WinForms.CartesianChart();
                crtRevenue.Dock = DockStyle.Fill;
                pnlChartContainer.Controls.Add(crtRevenue);
            }

            // Tùy chỉnh phong cách biểu đồ (Line chart xịn xò)
            crtRevenue.Series = new SeriesCollection();
            crtRevenue.AxisX.Add(new Axis
            {
                Title = "Ngày",
                Labels = new string[] { },
                Separator = new Separator { Step = 3, IsEnabled = false }
            });

            crtRevenue.AxisY.Add(new Axis
            {
                Title = "Số lượng bán (SP)",
                LabelFormatter = value => value.ToString("N0") + " sp",
                MinValue = 0
            });
        }

        private System.Windows.Forms.Timer mainTimer;

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = "Hệ thống quản lý bán hàng cho cửa hàng tiện lợi";
            this.Size = new System.Drawing.Size(1280, 950);
            this.MinimumSize = new System.Drawing.Size(1280, 950);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            pnSidebar.AutoScroll = true;
            pnContent.AutoScroll  = true;
            pnContent.Padding     = new Padding(8); // Giảm padding để có thêm chỗ

            DesignBeautifulDashboard();
            
            cboFilter.SelectedIndex = 0; // "7 ngày gần nhất"
            TaiDuLieuDashboard();

            if (SessionUser.CurrentUser != null)
            {
                lblAdminName.Text = SessionUser.CurrentUser.FullName;
                lblWelcome.Text = "Chào,";
                tssUser.Text      = "👤 Nhân viên: " + SessionUser.CurrentUser.FullName;
                tssRole.Text      = "🔑 Quyền: " + SessionUser.CurrentUser.Role;

                // Tất cả nút đều hiện (Phân quyền xử lý trong sự kiện Click)
                btnDashboard.Visible = true;
                btnProduct.Visible   = true;
                btnCategory.Visible  = true;
                btnSupplier.Visible  = true;
                btnUser.Visible      = true;
                btnReport.Visible    = true;
                btnInventory.Visible  = true;
            }

            // Xử lý thời gian thực
            if (mainTimer == null)
            {
                mainTimer = new System.Windows.Forms.Timer();
                mainTimer.Interval = 1000;
                mainTimer.Tick += (s, ev) => {
                    tssClock.Text = "⏰ Giờ hệ thống: " + DateTime.Now.ToString("HH:mm:ss");
                };
                mainTimer.Start();
            }

            this.Resize += (s, ev) => DesignBeautifulDashboard();
        }

        private void TaiDuLieuDashboard()
        {
            try
            {
                // Xác định số ngày từ bộ lọc
                int days = 7; // Mặc định 7 ngày
                if (cboFilter.SelectedIndex == 1) days = 30;
                else if (cboFilter.SelectedIndex == 2) days = 1;

                // 1. Cập nhật các thẻ KPI
                lblCardStockVal.Text = dashboardBUS.LaySoSanPhamSapHet().ToString();
                
                if (days == 1)
                {
                    lblCardRevVal.Text   = dashboardBUS.LayDoanhThuHomNay().ToString("N0") + "đ";
                    lblCardOrdersVal.Text = dashboardBUS.LayTongDonHangHomNay().ToString();
                }
                else
                {
                    decimal tongDTRange = 0;
                    var dtRange = dashboardBUS.LayDoanhThuTheoNgay(days);
                    foreach (System.Data.DataRow r in dtRange.Rows) tongDTRange += Convert.ToDecimal(r["DoanhThu"]);
                    
                    lblCardRevVal.Text   = tongDTRange.ToString("N0") + "đ";
                    lblCardOrdersVal.Text = dashboardBUS.LayTongDonHangTheoNgay(days).ToString();
                }
                
                lblCardCustVal.Text   = dashboardBUS.LayTongKhachHang().ToString();

                // 2. Cập nhật Biểu đồ (theo số ngày đã lọc)
                var dt = dashboardBUS.LayDoanhThuTheoNgay(days);
                var dates = new List<string>();
                var quantities = new ChartValues<int>();

                int totalPcs = 0;

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    dates.Add(Convert.ToDateTime(row["Ngay"]).ToString("dd/MM"));
                    int qty = row["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(row["SoLuong"]);
                    quantities.Add(qty);
                    totalPcs += qty;
                }

                // Cập nhật nhãn biểu đồ
                lblChartTitle.Text = $"Hoạt động kinh doanh {days} ngày qua (Tổng: {totalPcs} SP)";

                crtRevenue.Series.Clear();
                crtRevenue.Series.Add(new LineSeries
                {
                    Title = "Số lượng bán",
                    Values = quantities,
                    DataLabels = days <= 7, // Chỉ hiện label nếu ít ngày để tránh rối
                    StrokeThickness = 3,
                    PointGeometrySize = 8,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(4, 78, 39)), // Dark Green
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 4, 78, 39)),
                    LineSmoothness = 0.5
                });

                crtRevenue.AxisX[0].Labels = dates.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Dashboard: " + ex.Message);
            }
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDuLieuDashboard();
        }

        // ══════════════════════════════════════════
        //  Sidebar Navigation
        // ══════════════════════════════════════════

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
            // Hiện lại Dashboard Home
            pnlHome.Visible = true;
            pnlHome.BringToFront();
            
            TaiDuLieuDashboard();
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                pnContent.Controls.Remove(activeForm); // Xóa khỏi danh sách control
                activeForm.Dispose(); // Hủy triệt để
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            
            // Ẩn Dashboard Home
            pnlHome.Visible = false;

            pnContent.Controls.Add(childForm);
            pnContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBanHang());
        }

        private bool IsAdmin()
        {
            if (SessionUser.CurrentUser != null && SessionUser.CurrentUser.Role == "Admin")
                return true;
            
            MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (!IsAdmin()) return;
            OpenChildForm(new frmSanPham());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (!IsAdmin()) return;
            OpenChildForm(new frmLoaiHang());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            if (!IsAdmin()) return;
            OpenChildForm(new frmNhaCungCap());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!IsAdmin()) return;
            OpenChildForm(new frmNhanVien());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (!IsAdmin()) return;
            OpenChildForm(new frmTonKho());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBaoCao());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionUser.CurrentUser = null;
                new frmLogin().Show();
                this.Close();
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDoiMatKhau());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDonHang());
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaCungCap());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                OpenChildForm(new frmSanPham(keyword));
            }
        }

        private void DesignBeautifulDashboard()
        {
            if (label1 != null) label1.Visible = false;

            // 1. Nền tổng thể
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            if (pnContent != null) pnContent.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);

            // 2. Sidebar (Menu trái)
            if (pnSidebar != null)
            {
                pnSidebar.BackColor = System.Drawing.Color.FromArgb(4, 78, 39); // #044e27
                
                // 2.1. Logo cập nhật
                if (pictureBox1 != null)
                {
                    pictureBox1.Size = new Size(140, 80); // To hơn tí
                    pictureBox1.Location = new Point(8, 15);
                    try {
                        string logoPath = System.IO.Path.Combine(Application.StartupPath, "Resources", "logo.png");
                        if (System.IO.File.Exists(logoPath))
                            pictureBox1.Image = System.Drawing.Image.FromFile(logoPath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    } catch { } 
                }

                int buttonHeight = 45;
                int currentY = 135; // Nhích xuống thêm tí do logo to hơn

                var sidebarColor = System.Drawing.Color.FromArgb(4, 78, 39);

                // Danh sách các nút theo thứ tự muốn hiển thị
                var menuItems = new (Button btn, string text)[]
                {
                    (btnDashboard, "  TRANG CHỦ"),
                    (btnSales,     "  BÁN HÀNG (POS)"),
                    (btnProduct,   "  SẢN PHẨM"),
                    (btnCategory,  "  LOẠI HÀNG"),
                    (btnCustomer,  "  KHÁCH HÀNG"),
                    (btnInventory, "  KHO HÀNG"),
                    (btnSupplier,  "  NHÀ CUNG CẤP"),
                    (btnReport,    "  BÁO CÁO"),
                    (btnUser,      "  NHÂN VIÊN"),
                };

                foreach (var (btn, text) in menuItems)
                {
                    if (btn == null) continue;

                    btn.Text      = text;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize  = 0;
                    btn.FlatAppearance.BorderColor = sidebarColor;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.BackColor = sidebarColor;           // màu cụ thể, không dùng Transparent
                    btn.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                    btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    btn.Padding   = new Padding(0, 0, 0, 0);
                    btn.Cursor    = Cursors.Hand;
                    btn.Size      = new System.Drawing.Size(pnSidebar.Width, buttonHeight);
                    btn.Location  = new System.Drawing.Point(0, currentY);
                    currentY += buttonHeight + 2;

                    // Re-bind hover events
                    btn.MouseEnter -= Button_MouseEnter;
                    btn.MouseLeave -= Button_MouseLeave;
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                }
            }

            // 3. Top bar (User's Green Theme)
            if (pnTop != null)
            {
                var myGreen = System.Drawing.Color.FromArgb(4, 78, 39);
                pnTop.BackColor = myGreen;
                pnTop.Height = 60; 

                // Reset layout controls
                int topWidth = pnTop.Width;

                // 3.1. Dashboard Title (Located in Content Area, based on pnSidebar offset)
                if (lblDashboardTitle != null)
                {
                    lblDashboardTitle.Text = "DASHBOARD";
                    lblDashboardTitle.ForeColor = myGreen; // Bold Green on white background
                    lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
                    lblDashboardTitle.Location = new System.Drawing.Point(20, 15);
                    lblDashboardTitle.AutoSize = true;
                }
                
                // Position items from right to left
                // 3.2. Logout Button
                if (btnLogout != null) 
                {
                    btnLogout.Size = new System.Drawing.Size(80, 28);
                    btnLogout.Location = new System.Drawing.Point(topWidth - 90, 16);
                    btnLogout.FlatStyle = FlatStyle.Flat;
                    btnLogout.FlatAppearance.BorderSize = 1;
                    btnLogout.FlatAppearance.BorderColor = Color.White;
                    btnLogout.BackColor = Color.Transparent;
                    btnLogout.ForeColor = Color.White;
                    btnLogout.Text = "Thoát";
                    btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
                }

                // 3.3. User Info (Greeting)
                if (lblAdminName != null) 
                {
                    lblAdminName.ForeColor = Color.White; 
                    lblAdminName.BackColor = Color.Transparent; 
                    lblAdminName.AutoSize = true;
                    lblAdminName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                    lblAdminName.Location = new Point(topWidth - 220, 20); 
                }

                if (lblWelcome != null) 
                {
                    lblWelcome.Text = "Chào,";
                    lblWelcome.ForeColor = Color.White;
                    lblWelcome.BackColor = Color.Transparent; 
                    lblWelcome.AutoSize = true;
                    lblWelcome.Location = new Point(topWidth - 270, 20); 
                }

                // 3.4. Search Bar
                if (txtSearch != null)
                {
                    txtSearch.Location = new Point(140, 18);
                    txtSearch.Size = new Size(130, 26);
                }
                
                if (lblSearch != null)
                {
                    lblSearch.Text = "Tìm kiếm:";
                    lblSearch.ForeColor = Color.White;
                    lblSearch.BackColor = Color.Transparent;
                    lblSearch.Location = new Point(40, 20);
                    lblSearch.AutoSize = true;
                }

                if (btnSearch != null) 
                {
                    btnSearch.Location = new Point(275, 17);
                    btnSearch.Size = new Size(45, 28);
                    btnSearch.BackColor = Color.White;
                    btnSearch.ForeColor = myGreen;
                    btnSearch.FlatStyle = FlatStyle.Popup;
                    btnSearch.Text = "TÌM";
                    btnSearch.Font = new System.Drawing.Font("Segoe UI", 8F, FontStyle.Bold);
                }
            }

            // 3.5. Bộ lọc thời gian (Nằm trong pnlHome)
            if (cboFilter != null && pnlHome != null)
            {
                cboFilter.BringToFront();
                cboFilter.Location = new Point(pnlHome.Width - 160, 18);
                cboFilter.Size = new Size(140, 28);
                cboFilter.BackColor = Color.White;
                cboFilter.FlatStyle = FlatStyle.Flat;
            }

            // 3.5. Bottom bar (Status Strip)
            if (stsMain != null)
            {
                stsMain.BackColor = System.Drawing.Color.White;
                stsMain.RenderMode = ToolStripRenderMode.Professional;
                foreach (ToolStripItem item in stsMain.Items)
                {
                    item.ForeColor = System.Drawing.Color.Black;
                    item.Font = new System.Drawing.Font("Segoe UI", 9F);
                }
            }

            // 4. Các thẻ thông tin (KPI Cards) - Phân bổ đều theo chiều ngang
            Panel[] cards = { pnlCardRevenue, pnlCardOrders, pnlCardCustomers, pnlCardStock };
            System.Drawing.Color[] cardColors = { 
                System.Drawing.Color.FromArgb(46, 204, 113), // Xanh lá
                System.Drawing.Color.FromArgb(52, 152, 219), // Xanh dương
                System.Drawing.Color.FromArgb(155, 89, 182), // Tím
                System.Drawing.Color.FromArgb(231, 76, 60)   // Đỏ
            };

            if (pnlKPIContainer != null)
            {
                int cardCount = cards.Length;
                int spacing = 20;
                int totalSpacing = spacing * (cardCount - 1);
                int cardWidth = (pnlKPIContainer.Width - totalSpacing) / cardCount;
                int cardHeight = pnlKPIContainer.Height - 10;

                for (int i = 0; i < cardCount; i++)
                {
                    if (cards[i] == null) continue;

                    cards[i].Size = new Size(cardWidth, cardHeight);
                    cards[i].Location = new Point(i * (cardWidth + spacing), 5);
                    cards[i].BackColor = System.Drawing.Color.White;
                    cards[i].BorderStyle = BorderStyle.None;
                    
                    // Xóa border cũ an toàn (dùng loop ngược để tránh 'Collection was modified')
                    for (int j = cards[i].Controls.Count - 1; j >= 0; j--)
                    {
                        if (cards[i].Controls[j].Name == "indicator")
                            cards[i].Controls.RemoveAt(j);
                    }

                    // Tạo border nhấn ở cạnh trái
                    Panel leftBorder = new Panel();
                    leftBorder.Name = "indicator";
                    leftBorder.BackColor = cardColors[i];
                    leftBorder.Width = 6;
                    leftBorder.Dock = DockStyle.Left;
                    cards[i].Controls.Add(leftBorder);

                    // Drop shadow effect logic (WinForms fake shadow)
                    // cards[i].Region = ... (too complex for now)
                }
            }

            // 5. Khung chứa biểu đồ
            if (pnlChartContainer != null && pnlHome != null)
            {
                pnlChartContainer.Location = new Point(20, 180);
                pnlChartContainer.Size = new Size(pnlHome.Width - 40, pnlHome.Height - 200);
                pnlChartContainer.BackColor = System.Drawing.Color.White;
                pnlChartContainer.BorderStyle = BorderStyle.None;
            }

            // 4.5. Khung chứa KPI
            if (pnlKPIContainer != null && pnlHome != null)
            {
                pnlKPIContainer.Location = new Point(20, 60);
                pnlKPIContainer.Size = new Size(pnlHome.Width - 40, 110);
            }

            // 6. Đảm bảo form con luôn đè lên trên nếu đang mở
            if (activeForm != null)
            {
                activeForm.BringToFront();
            }
        }

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(6, 110, 55); // màu xanh sáng hơn khi hover
                btn.ForeColor = System.Drawing.Color.White;
            }
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(4, 78, 39); // màu sidebar gốc
                btn.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
