namespace DoAnQuanLyBanHang
{
    partial class frmDoiMatKhau
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle       = new System.Windows.Forms.Label();
            lblTaiKhoan    = new System.Windows.Forms.Label();
            grpDoiMK       = new System.Windows.Forms.GroupBox();
            lblMatKhauCu   = new System.Windows.Forms.Label(); txtMatKhauCu   = new System.Windows.Forms.TextBox();
            lblMatKhauMoi  = new System.Windows.Forms.Label(); txtMatKhauMoi  = new System.Windows.Forms.TextBox();
            lblXacNhan     = new System.Windows.Forms.Label(); txtXacNhan     = new System.Windows.Forms.TextBox();
            btnDoiMatKhau  = new System.Windows.Forms.Button();
            btnHuy         = new System.Windows.Forms.Button();

            grpDoiMK.SuspendLayout(); SuspendLayout();

            lblTitle.Text = "ĐỔI MẬT KHẨU"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.DarkGreen; lblTitle.Location = new System.Drawing.Point(12, 12); lblTitle.Size = new System.Drawing.Size(280, 30);
            lblTaiKhoan.Text = "Tài khoản: ..."; lblTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold); lblTaiKhoan.ForeColor = System.Drawing.Color.Navy; lblTaiKhoan.Location = new System.Drawing.Point(12, 48); lblTaiKhoan.Size = new System.Drawing.Size(340, 24);

            grpDoiMK.Text = "Thông tin mật khẩu"; grpDoiMK.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpDoiMK.Location = new System.Drawing.Point(12, 80); grpDoiMK.Size = new System.Drawing.Size(360, 125);
            int lx = 12, tx = 150, gap = 35;
            lblMatKhauCu.Text  = "Mật khẩu hiện tại:"; lblMatKhauCu.Location  = new System.Drawing.Point(lx, 28);      lblMatKhauCu.Size  = new System.Drawing.Size(135, 22); txtMatKhauCu.Location  = new System.Drawing.Point(tx, 25);      txtMatKhauCu.Size  = new System.Drawing.Size(195, 27); txtMatKhauCu.PasswordChar  = '*';
            lblMatKhauMoi.Text = "Mật khẩu mới:";      lblMatKhauMoi.Location = new System.Drawing.Point(lx, 28+gap);   lblMatKhauMoi.Size = new System.Drawing.Size(135, 22); txtMatKhauMoi.Location = new System.Drawing.Point(tx, 25+gap);   txtMatKhauMoi.Size = new System.Drawing.Size(195, 27); txtMatKhauMoi.PasswordChar = '*';
            lblXacNhan.Text    = "Xác nhận MK mới:";   lblXacNhan.Location    = new System.Drawing.Point(lx, 28+gap*2); lblXacNhan.Size    = new System.Drawing.Size(135, 22); txtXacNhan.Location    = new System.Drawing.Point(tx, 25+gap*2); txtXacNhan.Size    = new System.Drawing.Size(195, 27); txtXacNhan.PasswordChar    = '*';
            grpDoiMK.Controls.AddRange(new System.Windows.Forms.Control[] { lblMatKhauCu, txtMatKhauCu, lblMatKhauMoi, txtMatKhauMoi, lblXacNhan, txtXacNhan });

            btnDoiMatKhau.Text = "✅ Đổi mật khẩu"; btnDoiMatKhau.Location = new System.Drawing.Point(12, 218);  btnDoiMatKhau.Size = new System.Drawing.Size(170, 38); btnDoiMatKhau.BackColor = System.Drawing.Color.SeaGreen;   btnDoiMatKhau.ForeColor = System.Drawing.Color.White; btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold); btnDoiMatKhau.Click += new System.EventHandler(btnDoiMatKhau_Click);
            btnHuy.Text         = "✖ Hủy";           btnHuy.Location         = new System.Drawing.Point(195, 218); btnHuy.Size         = new System.Drawing.Size(100, 38); btnHuy.BackColor         = System.Drawing.Color.Gray;       btnHuy.ForeColor         = System.Drawing.Color.White; btnHuy.Font         = new System.Drawing.Font("Segoe UI", 10); btnHuy.Click         += new System.EventHandler(btnHuy_Click);

            ClientSize = new System.Drawing.Size(390, 275); Text = "Đổi Mật Khẩu"; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; MaximizeBox = false;
            Load += new System.EventHandler(frmDoiMatKhau_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblTaiKhoan, grpDoiMK, btnDoiMatKhau, btnHuy });
            grpDoiMK.ResumeLayout(false); ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitle, lblTaiKhoan, lblMatKhauCu, lblMatKhauMoi, lblXacNhan;
        private System.Windows.Forms.TextBox txtMatKhauCu, txtMatKhauMoi, txtXacNhan;
        private System.Windows.Forms.GroupBox grpDoiMK;
        private System.Windows.Forms.Button btnDoiMatKhau, btnHuy;
    }
}
