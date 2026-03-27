using System;
using System.Windows.Forms;

namespace DoAnQuanLyBanHang
{
    public partial class FormMain : Form
    {
        private readonly BUS.DashboardBUS dashboardBUS = new BUS.DashboardBUS();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            TaiDuLieuDashboard();

            if (SessionUser.CurrentUser != null)
            {
                lblAdminName.Text = SessionUser.CurrentUser.FullName;
                tssUser.Text      = "Nhân viên: " + SessionUser.CurrentUser.FullName;
                tssRole.Text      = "Quyền: " + SessionUser.CurrentUser.Role;

                // Ẩn nút Nhân Viên nếu không phải Admin
                btnUser.Visible = (SessionUser.CurrentUser.Role == "Admin");
            }

            // Cập nhật đồng hồ mỗi giây
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, ev) => tssClock.Text = "⏰ " + DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
        }

        private void TaiDuLieuDashboard()
        {
            try
            {
                lblLowStockCount.Text = dashboardBUS.LaySoSanPhamSapHet() + " SP";
                lblTodayRevenue.Text  = dashboardBUS.LayDoanhThuDinhDang();
            }
            catch
            {
                lblLowStockCount.Text = "Lỗi kết nối";
                lblTodayRevenue.Text  = "Lỗi kết nối";
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
            TaiDuLieuDashboard(); // Làm mới dashboard sau khi bán
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
                var frm = new frmSanPham();
                frm.Show();
            }
        }

        // ── Stubs từ Designer ──
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void panel1_DockChanged(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e) => btnInventory_Click(sender, e);
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void stsMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void lblLowStockCount_Click(object sender, EventArgs e) => btnReport_Click(sender, e);
    }
}
