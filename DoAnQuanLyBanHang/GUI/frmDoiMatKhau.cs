using System;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;

namespace DoAnQuanLyBanHang
{
    public partial class frmDoiMatKhau : Form
    {
        private readonly UserBUS userBUS = new UserBUS();

        public frmDoiMatKhau() { InitializeComponent(); }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            lblTaiKhoan.Text = "Tài khoản: " + SessionUser.CurrentUser?.UserName;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string mkCu   = txtMatKhauCu.Text.Trim();
            string mkMoi   = txtMatKhauMoi.Text.Trim();
            string mkNhap2 = txtXacNhan.Text.Trim();

            if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(mkNhap2))
            { MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (mkMoi.Length < 4)
            { MessageBox.Show("Mật khẩu mới phải có ít nhất 4 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (mkMoi != mkNhap2)
            { MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // Xác nhận mật khẩu cũ bằng cách thử đăng nhập
            var check = userBUS.KiemTraDangNhap(SessionUser.CurrentUser.UserName, mkCu);
            if (check == null)
            { MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); txtMatKhauCu.Clear(); txtMatKhauCu.Focus(); return; }

            if (userBUS.DoiMatKhau(SessionUser.CurrentUser.UserID, mkMoi))
            {
                MessageBox.Show("✅ Đổi mật khẩu thành công!\nVui lòng đăng nhập lại.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHuy_Click(object sender, EventArgs e) => this.Close();
    }
}
