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

        public FormMain()
        {
            InitializeComponent();
            SetupChart();
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
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            pnSidebar.AutoScroll = true;

            DesignBeautifulDashboard();
            TaiDuLieuDashboard();

            if (SessionUser.CurrentUser != null)
            {
                lblAdminName.Text = SessionUser.CurrentUser.FullName;
                lblWelcome.Text = "Chào,";
                tssUser.Text      = "👤 Nhân viên: " + SessionUser.CurrentUser.FullName;
                tssRole.Text      = "🔑 Quyền: " + SessionUser.CurrentUser.Role;

                btnUser.Visible = (SessionUser.CurrentUser.Role == "Admin");
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
                // 1. Cập nhật các thẻ KPI
                lblCardStockVal.Text = dashboardBUS.LaySoSanPhamSapHet().ToString();
                lblCardRevVal.Text   = dashboardBUS.LayDoanhThuHomNay().ToString("N0") + "đ";
                lblCardOrdersVal.Text = dashboardBUS.LayTongDonHangHomNay().ToString();
                lblCardCustVal.Text   = dashboardBUS.LayTongKhachHang().ToString();

                // 2. Cập nhật Biểu đồ 30 ngày (Line Chart)
                var dt = dashboardBUS.LayDoanhThu30Ngay();
                var dates = new List<string>();
                var quantities = new ChartValues<int>();

                int totalPcs = 0;

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    dates.Add(Convert.ToDateTime(row["Ngay"]).ToString("dd/MM"));
                    int qty = Convert.ToInt32(row["SoLuong"]);
                    quantities.Add(qty);
                    totalPcs += qty;
                }

                // Cập nhật nhãn biểu đồ
                lblChartTitle.Text = $"Hoạt động kinh doanh 30 ngày qua (Tổng: {totalPcs} SP)";

                crtRevenue.Series.Clear();
                crtRevenue.Series.Add(new LineSeries
                {
                    Title = "Số lượng bán",
                    Values = quantities,
                    DataLabels = true,
                    StrokeThickness = 3,
                    PointGeometrySize = 10,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(4, 78, 39)), // Dark Green
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 4, 78, 39)),
                    LineSmoothness = 0.5
                });

                crtRevenue.AxisX[0].Labels = dates.ToArray();

                // 3. Hiển thị Top Sản Phẩm & Đơn Hàng Mới Nhất (giả lập listview/panel nếu chưa có control)
                // Trong thực tế sẽ dùng DataGridView hoặc ListView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Dashboard: " + ex.Message);
            }
        }

        // ══════════════════════════════════════════
        //  Sidebar Navigation
        // ══════════════════════════════════════════

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            TaiDuLieuDashboard();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            new frmBanHang().ShowDialog();
            TaiDuLieuDashboard();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            new frmSanPham().ShowDialog();
            TaiDuLieuDashboard();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            new frmLoaiHang().ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            new frmNhaCungCap().ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            new frmKhachHang().ShowDialog();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            new frmNhanVien().ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            new frmTonKho().ShowDialog();
            TaiDuLieuDashboard();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            new frmBaoCao().ShowDialog();
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
            new frmDoiMatKhau().ShowDialog();
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            new frmDonHang().ShowDialog();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            new frmNhaCungCap().ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                var frm = new frmSanPham(keyword);
                frm.Show();
            }
        }

        private void DesignBeautifulDashboard()
        {
            // 1. Nền tổng thể
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            if (pnContent != null) pnContent.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);

            // 2. Sidebar (Menu trái)
            if (pnSidebar != null)
            {
                pnSidebar.BackColor = System.Drawing.Color.FromArgb(4, 78, 39); // #044e27
                
                int buttonHeight = 45;
                int currentY = 100; // Để chừa chỗ cho logo ở trên

                // Danh sách các nút theo thứ tự muốn hiển thị
                Button[] menuButtons = { 
                    btnDashboard, btnSales, btnProduct, btnCategory, 
                    btnCustomer, btnInventory, btnSupplier, btnReport, btnUser 
                };

                foreach (var btn in menuButtons)
                {
                    if (btn == null) continue;

                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.BackColor = System.Drawing.Color.Transparent;
                    btn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
                    btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    btn.Padding = new Padding(25, 0, 0, 0);
                    btn.Cursor = Cursors.Hand;
                    
                    btn.Size = new Size(pnSidebar.Width, buttonHeight);
                    btn.Location = new Point(0, currentY);
                    currentY += buttonHeight + 5; // Thêm khoảng cách giữa các nút

                    // Re-bind hover events to ensure they work
                    btn.MouseEnter -= Button_MouseEnter;
                    btn.MouseLeave -= Button_MouseLeave;
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                }
            }

            // 3. Top bar 
            if (pnTop != null)
            {
                pnTop.BackColor = System.Drawing.Color.FromArgb(4, 78, 39); // #044e27
                pnTop.Height = 65; 

                // Căn chỉnh lại các controls trên TopBar - Tránh chồng lấn/mất layout
                if (lblDashboardTitle != null)
                {
                    lblDashboardTitle.Text = "DASHBOARD";
                    lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(4, 78, 39); // Match Top Bar Green
                    lblDashboardTitle.Location = new Point(20, 20);
                    lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
                    lblDashboardTitle.AutoSize = true;
                }

                int topWidth = pnTop.Width;
                
                if (btnLogout != null) 
                {
                    btnLogout.Size = new Size(70, 30);
                    btnLogout.Location = new Point(topWidth - 85, 18);
                    btnLogout.FlatStyle = FlatStyle.Flat;
                    btnLogout.FlatAppearance.BorderSize = 0;
                    btnLogout.BackColor = System.Drawing.Color.FromArgb(231, 76, 60); // Red
                    btnLogout.ForeColor = System.Drawing.Color.White;
                }

                if (lblAdminName != null) 
                {
                    lblAdminName.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60); 
                    lblAdminName.AutoSize = true;
                    lblAdminName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                    lblAdminName.Location = new Point(topWidth - 200, 24);
                }

                if (lblWelcome != null) 
                {
                    lblWelcome.ForeColor = System.Drawing.Color.White;
                    lblWelcome.AutoSize = true;
                    lblWelcome.Location = new Point(topWidth - 250, 24);
                }

                if (txtSearch != null)
                {
                    txtSearch.Location = new Point(160, 22);
                    txtSearch.Size = new Size(100, 26);
                }
                
                if (lblSearch != null)
                {
                    lblSearch.ForeColor = System.Drawing.Color.White;
                    lblSearch.BackColor = System.Drawing.Color.Transparent;
                    lblSearch.Location = new Point(80, 24);
                    // Move it to avoid overlap if needed
                }

                if (btnSearch != null) 
                {
                    btnSearch.Location = new Point(265, 20);
                    btnSearch.Size = new Size(50, 28);
                }
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
                    
                    // Xóa border cũ nếu có
                    foreach (Control child in cards[i].Controls)
                        if (child.Name == "indicator") cards[i].Controls.Remove(child);

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
            if (pnlChartContainer != null)
            {
                pnlChartContainer.BackColor = System.Drawing.Color.White;
                pnlChartContainer.BorderStyle = BorderStyle.None;
            }
        }

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(6, 95, 48); // Lighter version of #044e27 for hover
                btn.ForeColor = System.Drawing.Color.White;
            }
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = System.Drawing.Color.Transparent;
                btn.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
