namespace DoAnQuanLyBanHang
{
    partial class frmKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle      = new System.Windows.Forms.Label();
            lblTimKiem    = new System.Windows.Forms.Label();
            txtTimKiem    = new System.Windows.Forms.TextBox();
            dgvKhachHang  = new System.Windows.Forms.DataGridView();
            grpThongTin   = new System.Windows.Forms.GroupBox();
            lblTenKH      = new System.Windows.Forms.Label();
            txtTenKH      = new System.Windows.Forms.TextBox();
            lblSDT        = new System.Windows.Forms.Label();
            txtSDT        = new System.Windows.Forms.TextBox();
            lblEmail      = new System.Windows.Forms.Label();
            txtEmail      = new System.Windows.Forms.TextBox();
            lblDiaChi     = new System.Windows.Forms.Label();
            txtDiaChi     = new System.Windows.Forms.TextBox();
            lblDiem       = new System.Windows.Forms.Label();
            lblDiemValue  = new System.Windows.Forms.Label();
            pnlButtons    = new System.Windows.Forms.Panel();
            btnThem       = new System.Windows.Forms.Button();
            btnSua        = new System.Windows.Forms.Button();
            btnXoa        = new System.Windows.Forms.Button();
            btnLuu        = new System.Windows.Forms.Button();
            btnHuy        = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            grpThongTin.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            lblTitle.Text = "QUẢN LÝ KHÁCH HÀNG"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.DarkGreen; lblTitle.Location = new System.Drawing.Point(12, 10); lblTitle.Size = new System.Drawing.Size(350, 30);
            lblTimKiem.Text = "🔍 Tìm kiếm:"; lblTimKiem.Location = new System.Drawing.Point(12, 52); lblTimKiem.Size = new System.Drawing.Size(90, 24);
            txtTimKiem.Location = new System.Drawing.Point(105, 49); txtTimKiem.Size = new System.Drawing.Size(280, 27); txtTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(txtTimKiem_KeyUp);

            dgvKhachHang.Location = new System.Drawing.Point(12, 85); dgvKhachHang.Size = new System.Drawing.Size(760, 300);
            dgvKhachHang.AllowUserToAddRows = false; dgvKhachHang.ReadOnly = true;
            dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dgvKhachHang_RowEnter);

            grpThongTin.Text = "Thông tin khách hàng"; grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpThongTin.Location = new System.Drawing.Point(12, 400); grpThongTin.Size = new System.Drawing.Size(760, 160);

            int lx = 15, tx = 120, gap = 32;
            lblTenKH.Text = "Tên KH:";    lblTenKH.Location = new System.Drawing.Point(lx, 25);        lblTenKH.Size = new System.Drawing.Size(100, 22); txtTenKH.Location = new System.Drawing.Point(tx, 23);       txtTenKH.Size = new System.Drawing.Size(250, 27);
            lblSDT.Text   = "Điện thoại:"; lblSDT.Location  = new System.Drawing.Point(lx, 25 + gap);  lblSDT.Size   = new System.Drawing.Size(100, 22); txtSDT.Location   = new System.Drawing.Point(tx, 23 + gap); txtSDT.Size   = new System.Drawing.Size(150, 27);
            lblEmail.Text = "Email:";      lblEmail.Location = new System.Drawing.Point(lx, 25 + gap * 2); lblEmail.Size = new System.Drawing.Size(100, 22); txtEmail.Location = new System.Drawing.Point(tx, 23 + gap * 2); txtEmail.Size = new System.Drawing.Size(250, 27);
            lblDiaChi.Text = "Địa chỉ:";  lblDiaChi.Location = new System.Drawing.Point(lx, 25 + gap * 3); lblDiaChi.Size = new System.Drawing.Size(100, 22); txtDiaChi.Location = new System.Drawing.Point(tx, 23 + gap * 3); txtDiaChi.Size = new System.Drawing.Size(350, 27);
            lblDiem.Text   = "Điểm:";     lblDiem.Location   = new System.Drawing.Point(500, 25);        lblDiem.Size   = new System.Drawing.Size(60, 22); 
            lblDiemValue.Text = "0";      lblDiemValue.Location = new System.Drawing.Point(565, 23);     lblDiemValue.Size = new System.Drawing.Size(100, 25); lblDiemValue.ForeColor = System.Drawing.Color.Crimson; lblDiemValue.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);

            grpThongTin.Controls.AddRange(new System.Windows.Forms.Control[] { lblTenKH, txtTenKH, lblSDT, txtSDT, lblEmail, txtEmail, lblDiaChi, txtDiaChi, lblDiem, lblDiemValue });

            pnlButtons.Location = new System.Drawing.Point(12, 575); pnlButtons.Size = new System.Drawing.Size(760, 45);
            int bw = 100, bh = 35;
            btnThem.Text = "➕ Thêm"; btnThem.Location = new System.Drawing.Point(5, 5);   btnThem.Size = new System.Drawing.Size(bw, bh); btnThem.BackColor = System.Drawing.Color.SeaGreen;   btnThem.ForeColor = System.Drawing.Color.White; btnThem.Click += new System.EventHandler(btnThem_Click);
            btnSua.Text  = "✏ Sửa";  btnSua.Location  = new System.Drawing.Point(115, 5); btnSua.Size  = new System.Drawing.Size(bw, bh); btnSua.BackColor  = System.Drawing.Color.SteelBlue;  btnSua.ForeColor  = System.Drawing.Color.White; btnSua.Click  += new System.EventHandler(btnSua_Click);
            btnXoa.Text  = "🗑 Xóa"; btnXoa.Location  = new System.Drawing.Point(225, 5); btnXoa.Size  = new System.Drawing.Size(bw, bh); btnXoa.BackColor  = System.Drawing.Color.Crimson;    btnXoa.ForeColor  = System.Drawing.Color.White; btnXoa.Click  += new System.EventHandler(btnXoa_Click);
            btnLuu.Text  = "💾 Lưu"; btnLuu.Location  = new System.Drawing.Point(335, 5); btnLuu.Size  = new System.Drawing.Size(bw, bh); btnLuu.BackColor  = System.Drawing.Color.DarkOrange; btnLuu.ForeColor  = System.Drawing.Color.White; btnLuu.Click  += new System.EventHandler(btnLuu_Click);
            btnHuy.Text  = "✖ Hủy";  btnHuy.Location  = new System.Drawing.Point(445, 5); btnHuy.Size  = new System.Drawing.Size(bw, bh); btnHuy.BackColor  = System.Drawing.Color.Gray;       btnHuy.ForeColor  = System.Drawing.Color.White; btnHuy.Click  += new System.EventHandler(btnHuy_Click);
            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnThem, btnSua, btnXoa, btnLuu, btnHuy });

            ClientSize = new System.Drawing.Size(800, 640); Text = "Quản Lý Khách Hàng"; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += new System.EventHandler(frmKhachHang_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblTimKiem, txtTimKiem, dgvKhachHang, grpThongTin, pnlButtons });

            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            grpThongTin.ResumeLayout(false); pnlButtons.ResumeLayout(false); ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle, lblTimKiem, lblTenKH, lblSDT, lblEmail, lblDiaChi, lblDiem, lblDiemValue;
        private System.Windows.Forms.TextBox txtTimKiem, txtTenKH, txtSDT, txtEmail, txtDiaChi;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnLuu, btnHuy;
    }
}
