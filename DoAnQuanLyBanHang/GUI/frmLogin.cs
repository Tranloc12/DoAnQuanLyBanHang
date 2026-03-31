using DoAnQuanLyBanHang.BUS;
using DoAnQuanLyBanHang.DTO;
using System;
using System.Windows.Forms;

namespace DoAnQuanLyBanHang
{
    public partial class frmLogin : Form
    {
        private readonly UserBUS userBUS = new UserBUS();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserDTO user = userBUS.KiemTraDangNhap(username, password);

            if (user != null)
            {
                // Lưu vào session toàn cục
                SessionUser.CurrentUser = user;

                FormMain fMain = new FormMain();
                fMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

    }
}
