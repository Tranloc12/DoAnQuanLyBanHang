namespace DoAnQuanLyBanHang
{
    partial class frmNhaCungCap
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle = new System.Windows.Forms.Label();
            dgvNCC   = new System.Windows.Forms.DataGridView();
            grpThongTin = new System.Windows.Forms.GroupBox();
            lblTen   = new System.Windows.Forms.Label(); txtTen    = new System.Windows.Forms.TextBox();
            lblSDT   = new System.Windows.Forms.Label(); txtSDT    = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label(); txtEmail  = new System.Windows.Forms.TextBox();
            lblDiaChi = new System.Windows.Forms.Label(); txtDiaChi = new System.Windows.Forms.TextBox();
            pnlButtons = new System.Windows.Forms.Panel();
            btnThem = new System.Windows.Forms.Button(); btnSua = new System.Windows.Forms.Button();
            btnXoa  = new System.Windows.Forms.Button(); btnLuu = new System.Windows.Forms.Button();
            btnHuy  = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvNCC).BeginInit();
            grpThongTin.SuspendLayout(); pnlButtons.SuspendLayout(); SuspendLayout();

            lblTitle.Text = "QUẢN LÝ NHÀ CUNG CẤP"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.DarkGreen; lblTitle.Location = new System.Drawing.Point(12, 10); lblTitle.Size = new System.Drawing.Size(380, 30);

            dgvNCC.Location = new System.Drawing.Point(12, 48); dgvNCC.Size = new System.Drawing.Size(660, 270);
            dgvNCC.AllowUserToAddRows = false; dgvNCC.ReadOnly = true;
            dgvNCC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvNCC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvNCC.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dgvNCC_RowEnter);

            grpThongTin.Text = "Thông tin nhà cung cấp"; grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpThongTin.Location = new System.Drawing.Point(12, 330); grpThongTin.Size = new System.Drawing.Size(660, 130);
            int lx = 12, tx = 130, gap = 30;
            lblTen.Text   = "Tên NCC:";    lblTen.Location   = new System.Drawing.Point(lx, 25);        lblTen.Size   = new System.Drawing.Size(115, 22); txtTen.Location   = new System.Drawing.Point(tx, 23);        txtTen.Size   = new System.Drawing.Size(250, 27);
            lblSDT.Text   = "Điện thoại:"; lblSDT.Location   = new System.Drawing.Point(lx, 25+gap);    lblSDT.Size   = new System.Drawing.Size(115, 22); txtSDT.Location   = new System.Drawing.Point(tx, 23+gap);    txtSDT.Size   = new System.Drawing.Size(150, 27);
            lblEmail.Text = "Email:";       lblEmail.Location = new System.Drawing.Point(lx, 25+gap*2);  lblEmail.Size = new System.Drawing.Size(115, 22); txtEmail.Location = new System.Drawing.Point(tx, 23+gap*2);  txtEmail.Size = new System.Drawing.Size(250, 27);
            lblDiaChi.Text= "Địa chỉ:";    lblDiaChi.Location= new System.Drawing.Point(lx, 25+gap*3);  lblDiaChi.Size= new System.Drawing.Size(115, 22); txtDiaChi.Location= new System.Drawing.Point(tx, 23+gap*3);  txtDiaChi.Size= new System.Drawing.Size(400, 27);
            grpThongTin.Controls.AddRange(new System.Windows.Forms.Control[] { lblTen, txtTen, lblSDT, txtSDT, lblEmail, txtEmail, lblDiaChi, txtDiaChi });

            pnlButtons.Location = new System.Drawing.Point(12, 472); pnlButtons.Size = new System.Drawing.Size(660, 42);
            int bw = 100, bh = 34;
            btnThem.Text = "➕ Thêm"; btnThem.Location = new System.Drawing.Point(0, 4);   btnThem.Size = new System.Drawing.Size(bw, bh); btnThem.BackColor = System.Drawing.Color.SeaGreen;   btnThem.ForeColor = System.Drawing.Color.White; btnThem.Click += new System.EventHandler(btnThem_Click);
            btnSua.Text  = "✏ Sửa";  btnSua.Location  = new System.Drawing.Point(108, 4); btnSua.Size  = new System.Drawing.Size(bw, bh); btnSua.BackColor  = System.Drawing.Color.SteelBlue;  btnSua.ForeColor  = System.Drawing.Color.White; btnSua.Click  += new System.EventHandler(btnSua_Click);
            btnXoa.Text  = "🗑 Xóa"; btnXoa.Location  = new System.Drawing.Point(216, 4); btnXoa.Size  = new System.Drawing.Size(bw, bh); btnXoa.BackColor  = System.Drawing.Color.Crimson;    btnXoa.ForeColor  = System.Drawing.Color.White; btnXoa.Click  += new System.EventHandler(btnXoa_Click);
            btnLuu.Text  = "💾 Lưu"; btnLuu.Location  = new System.Drawing.Point(324, 4); btnLuu.Size  = new System.Drawing.Size(bw, bh); btnLuu.BackColor  = System.Drawing.Color.DarkOrange; btnLuu.ForeColor  = System.Drawing.Color.White; btnLuu.Click  += new System.EventHandler(btnLuu_Click);
            btnHuy.Text  = "✖ Hủy";  btnHuy.Location  = new System.Drawing.Point(432, 4); btnHuy.Size  = new System.Drawing.Size(bw, bh); btnHuy.BackColor  = System.Drawing.Color.Gray;       btnHuy.ForeColor  = System.Drawing.Color.White; btnHuy.Click  += new System.EventHandler(btnHuy_Click);
            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnThem, btnSua, btnXoa, btnLuu, btnHuy });

            ClientSize = new System.Drawing.Size(692, 528); Text = "Quản Lý Nhà Cung Cấp"; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += new System.EventHandler(frmNhaCungCap_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, dgvNCC, grpThongTin, pnlButtons });
            ((System.ComponentModel.ISupportInitialize)dgvNCC).EndInit();
            grpThongTin.ResumeLayout(false); pnlButtons.ResumeLayout(false); ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitle, lblTen, lblSDT, lblEmail, lblDiaChi;
        private System.Windows.Forms.TextBox txtTen, txtSDT, txtEmail, txtDiaChi;
        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnLuu, btnHuy;
    }
}
