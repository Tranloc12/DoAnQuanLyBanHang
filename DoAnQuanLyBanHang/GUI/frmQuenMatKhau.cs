using System;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;

namespace DoAnQuanLyBanHang
{
    public partial class frmQuenMatKhau : Form
    {
        private readonly UserBUS userBUS = new UserBUS();

        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnLayLaiMatKhau_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string pass = userBUS.QuenMatKhau(username, email);
            if (pass != null)
            {
                lblKetQua.Text = "Mật khẩu của bạn là: " + pass;
                MessageBox.Show("Tìm thấy mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblKetQua.Text = "Sai thông tin hoặc tài khoản bị khóa!";
                MessageBox.Show("Thông tin không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
