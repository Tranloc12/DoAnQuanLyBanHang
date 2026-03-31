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

            bool thanhCong = userBUS.QuenMatKhau(username, email);
            if (thanhCong)
            {
                lblKetQua.Text = "Mật khẩu đã reset về: 123456";
                lblKetQua.ForeColor = System.Drawing.Color.Green;
                MessageBox.Show("Mật khẩu của bạn đã được đặt lại thành '123456'.\nVui lòng đăng nhập và đổi mật khẩu ngay!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblKetQua.Text = "Thông tin không chính xác!";
                lblKetQua.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("Tên đăng nhập hoặc Email/SĐT không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
