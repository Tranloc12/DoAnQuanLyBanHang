using DoAnQuanLyBanHang.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQuanLyBanHang
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserBUS bus = new UserBUS();

            // Lộc lưu ý: txtUsername và txtPassword phải đúng tên (Name) bạn đặt ở giao diện nhé
            if (bus.KiemTraDangNhap(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Đăng nhập thành công! Chào Lộc.", "Thông báo");

                // 1. Tạo đối tượng Form chính
                Form1 f = new Form1();

                // 2. Ẩn form đăng nhập hiện tại đi
                this.Hide();

                // 3. Hiện Form chính lên
                f.ShowDialog();

                // 4. Sau khi đóng Form chính thì đóng luôn chương trình
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu! Vui lòng thử lại.", "Lỗi");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
