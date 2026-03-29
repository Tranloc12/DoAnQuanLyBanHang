namespace DoAnQuanLyBanHang
{
    partial class frmNhanVien
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle     = new System.Windows.Forms.Label();
            dgvNhanVien  = new System.Windows.Forms.DataGridView();
            grpThongTin  = new System.Windows.Forms.GroupBox();
            lblTenDangNhap = new System.Windows.Forms.Label(); txtTenDangNhap = new System.Windows.Forms.TextBox();
            lblMatKhau   = new System.Windows.Forms.Label();   txtMatKhau     = new System.Windows.Forms.TextBox();
            lblHoTen     = new System.Windows.Forms.Label();   txtHoTen       = new System.Windows.Forms.TextBox();
            lblEmail     = new System.Windows.Forms.Label();   txtEmail       = new System.Windows.Forms.TextBox();
            lblSDT       = new System.Windows.Forms.Label();   txtSDT         = new System.Windows.Forms.TextBox();
            lblQuyen     = new System.Windows.Forms.Label();   cbQuyen        = new System.Windows.Forms.ComboBox();
            pnlButtons   = new System.Windows.Forms.Panel();
            btnThem      = new System.Windows.Forms.Button();
            btnSua       = new System.Windows.Forms.Button();
            btnXoa       = new System.Windows.Forms.Button();
            btnLuu       = new System.Windows.Forms.Button();
            btnHuy       = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            grpThongTin.SuspendLayout(); pnlButtons.SuspendLayout(); SuspendLayout();

            lblTitle.Text = "QUẢN LÝ NHÂN VIÊN"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.DarkGreen; lblTitle.Location = new System.Drawing.Point(12, 10); lblTitle.Size = new System.Drawing.Size(350, 30);

            dgvNhanVien.Location = new System.Drawing.Point(12, 50); dgvNhanVien.Size = new System.Drawing.Size(760, 300);
            dgvNhanVien.AllowUserToAddRows = false; dgvNhanVien.ReadOnly = true;
            dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dgvNhanVien_RowEnter);

            grpThongTin.Text = "Thông tin nhân viên"; grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpThongTin.Location = new System.Drawing.Point(12, 365); grpThongTin.Size = new System.Drawing.Size(760, 185);

            int lx = 15, tx = 140, ly = 25, gap = 30;
            lblTenDangNhap.Text = "Tên đăng nhập:"; lblTenDangNhap.Location = new System.Drawing.Point(lx, ly);         lblTenDangNhap.Size = new System.Drawing.Size(120, 22); txtTenDangNhap.Location = new System.Drawing.Point(tx, ly - 2);         txtTenDangNhap.Size = new System.Drawing.Size(160, 27);
            lblMatKhau.Text     = "Mật khẩu:";       lblMatKhau.Location     = new System.Drawing.Point(lx, ly + gap);     lblMatKhau.Size     = new System.Drawing.Size(120, 22); txtMatKhau.Location     = new System.Drawing.Point(tx, ly + gap - 2);     txtMatKhau.Size     = new System.Drawing.Size(160, 27); txtMatKhau.PasswordChar = '*';
            lblHoTen.Text       = "Họ và tên:";       lblHoTen.Location       = new System.Drawing.Point(lx, ly + gap * 2); lblHoTen.Size       = new System.Drawing.Size(120, 22); txtHoTen.Location       = new System.Drawing.Point(tx, ly + gap * 2 - 2); txtHoTen.Size       = new System.Drawing.Size(250, 27);
            lblEmail.Text       = "Email:";            lblEmail.Location       = new System.Drawing.Point(lx, ly + gap * 3); lblEmail.Size       = new System.Drawing.Size(120, 22); txtEmail.Location       = new System.Drawing.Point(tx, ly + gap * 3 - 2); txtEmail.Size       = new System.Drawing.Size(220, 27);
            lblSDT.Text         = "Điện thoại:";       lblSDT.Location         = new System.Drawing.Point(lx, ly + gap * 4); lblSDT.Size         = new System.Drawing.Size(120, 22); txtSDT.Location         = new System.Drawing.Point(tx, ly + gap * 4 - 2); txtSDT.Size         = new System.Drawing.Size(150, 27);
            lblQuyen.Text       = "Quyền:";            lblQuyen.Location       = new System.Drawing.Point(420, ly);          lblQuyen.Size       = new System.Drawing.Size(80, 22);  cbQuyen.Location        = new System.Drawing.Point(505, ly - 2);       cbQuyen.Size        = new System.Drawing.Size(130, 27); cbQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            grpThongTin.Controls.AddRange(new System.Windows.Forms.Control[] { lblTenDangNhap, txtTenDangNhap, lblMatKhau, txtMatKhau, lblHoTen, txtHoTen, lblEmail, txtEmail, lblSDT, txtSDT, lblQuyen, cbQuyen });

            pnlButtons.Location = new System.Drawing.Point(12, 562); pnlButtons.Size = new System.Drawing.Size(760, 45);
            int bw = 100, bh = 35;
            btnThem.Text = "➕ Thêm"; btnThem.Location = new System.Drawing.Point(5, 5);   btnThem.Size = new System.Drawing.Size(bw, bh); btnThem.BackColor = System.Drawing.Color.SeaGreen;   btnThem.ForeColor = System.Drawing.Color.White; btnThem.Click += new System.EventHandler(btnThem_Click);
            btnSua.Text  = "✏ Sửa";   btnSua.Location  = new System.Drawing.Point(115, 5); btnSua.Size  = new System.Drawing.Size(bw, bh); btnSua.BackColor  = System.Drawing.Color.SteelBlue;  btnSua.ForeColor  = System.Drawing.Color.White; btnSua.Click  += new System.EventHandler(btnSua_Click);
            btnXoa.Text  = "🗑 Xóa"; btnXoa.Location = new System.Drawing.Point(225, 5); btnXoa.Size  = new System.Drawing.Size(bw, bh); btnXoa.BackColor  = System.Drawing.Color.Crimson;    btnXoa.ForeColor  = System.Drawing.Color.White; btnXoa.Click  += new System.EventHandler(btnXoa_Click);
            btnLuu.Text  = "💾 Lưu";  btnLuu.Location  = new System.Drawing.Point(335, 5); btnLuu.Size  = new System.Drawing.Size(bw, bh); btnLuu.BackColor  = System.Drawing.Color.DarkOrange; btnLuu.ForeColor  = System.Drawing.Color.White; btnLuu.Click  += new System.EventHandler(btnLuu_Click);
            btnHuy.Text  = "✖ Hủy";   btnHuy.Location  = new System.Drawing.Point(445, 5); btnHuy.Size  = new System.Drawing.Size(bw, bh); btnHuy.BackColor  = System.Drawing.Color.Gray;       btnHuy.ForeColor  = System.Drawing.Color.White; btnHuy.Click  += new System.EventHandler(btnHuy_Click);
            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnThem, btnSua, btnXoa, btnLuu, btnHuy });

            ClientSize = new System.Drawing.Size(800, 620); Text = "Quản Lý Nhân Viên"; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += new System.EventHandler(frmNhanVien_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, dgvNhanVien, grpThongTin, pnlButtons });

            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            grpThongTin.ResumeLayout(false); pnlButtons.ResumeLayout(false); ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle, lblTenDangNhap, lblMatKhau, lblHoTen, lblEmail, lblSDT, lblQuyen;
        private System.Windows.Forms.TextBox txtTenDangNhap, txtMatKhau, txtHoTen, txtEmail, txtSDT;
        private System.Windows.Forms.ComboBox cbQuyen;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnLuu, btnHuy;
    }
}
