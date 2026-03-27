namespace DoAnQuanLyBanHang
{
    partial class frmLoaiHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle = new System.Windows.Forms.Label();
            dgvLoaiHang = new System.Windows.Forms.DataGridView();
            grpThongTin = new System.Windows.Forms.GroupBox();
            lblTenLoai = new System.Windows.Forms.Label(); txtTenLoai = new System.Windows.Forms.TextBox();
            lblMoTa    = new System.Windows.Forms.Label(); txtMoTa    = new System.Windows.Forms.TextBox();
            pnlButtons = new System.Windows.Forms.Panel();
            btnThem = new System.Windows.Forms.Button(); btnSua = new System.Windows.Forms.Button();
            btnXoa  = new System.Windows.Forms.Button(); btnLuu = new System.Windows.Forms.Button();
            btnHuy  = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvLoaiHang).BeginInit();
            grpThongTin.SuspendLayout(); pnlButtons.SuspendLayout(); SuspendLayout();

            lblTitle.Text = "QUẢN LÝ LOẠI HÀNG"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.DarkGreen; lblTitle.Location = new System.Drawing.Point(12, 10); lblTitle.Size = new System.Drawing.Size(350, 30);

            dgvLoaiHang.Location = new System.Drawing.Point(12, 48); dgvLoaiHang.Size = new System.Drawing.Size(560, 280);
            dgvLoaiHang.AllowUserToAddRows = false; dgvLoaiHang.ReadOnly = true;
            dgvLoaiHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiHang.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dgvLoaiHang_RowEnter);

            grpThongTin.Text = "Thông tin loại hàng"; grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpThongTin.Location = new System.Drawing.Point(12, 340); grpThongTin.Size = new System.Drawing.Size(560, 100);
            lblTenLoai.Text = "Tên loại:"; lblTenLoai.Location = new System.Drawing.Point(12, 28); lblTenLoai.Size = new System.Drawing.Size(80, 22);
            txtTenLoai.Location = new System.Drawing.Point(95, 25); txtTenLoai.Size = new System.Drawing.Size(200, 27);
            lblMoTa.Text    = "Mô tả:";    lblMoTa.Location    = new System.Drawing.Point(12, 60); lblMoTa.Size    = new System.Drawing.Size(80, 22);
            txtMoTa.Location    = new System.Drawing.Point(95, 58); txtMoTa.Size    = new System.Drawing.Size(440, 27);
            grpThongTin.Controls.AddRange(new System.Windows.Forms.Control[] { lblTenLoai, txtTenLoai, lblMoTa, txtMoTa });

            pnlButtons.Location = new System.Drawing.Point(12, 455); pnlButtons.Size = new System.Drawing.Size(560, 42);
            int bw = 95, bh = 34;
            btnThem.Text = "➕ Thêm"; btnThem.Location = new System.Drawing.Point(0, 4);   btnThem.Size = new System.Drawing.Size(bw, bh); btnThem.BackColor = System.Drawing.Color.SeaGreen;   btnThem.ForeColor = System.Drawing.Color.White; btnThem.Click += new System.EventHandler(btnThem_Click);
            btnSua.Text  = "✏ Sửa";  btnSua.Location  = new System.Drawing.Point(103, 4); btnSua.Size  = new System.Drawing.Size(bw, bh); btnSua.BackColor  = System.Drawing.Color.SteelBlue;  btnSua.ForeColor  = System.Drawing.Color.White; btnSua.Click  += new System.EventHandler(btnSua_Click);
            btnXoa.Text  = "🗑 Xóa"; btnXoa.Location  = new System.Drawing.Point(206, 4); btnXoa.Size  = new System.Drawing.Size(bw, bh); btnXoa.BackColor  = System.Drawing.Color.Crimson;    btnXoa.ForeColor  = System.Drawing.Color.White; btnXoa.Click  += new System.EventHandler(btnXoa_Click);
            btnLuu.Text  = "💾 Lưu"; btnLuu.Location  = new System.Drawing.Point(309, 4); btnLuu.Size  = new System.Drawing.Size(bw, bh); btnLuu.BackColor  = System.Drawing.Color.DarkOrange; btnLuu.ForeColor  = System.Drawing.Color.White; btnLuu.Click  += new System.EventHandler(btnLuu_Click);
            btnHuy.Text  = "✖ Hủy";  btnHuy.Location  = new System.Drawing.Point(412, 4); btnHuy.Size  = new System.Drawing.Size(bw, bh); btnHuy.BackColor  = System.Drawing.Color.Gray;       btnHuy.ForeColor  = System.Drawing.Color.White; btnHuy.Click  += new System.EventHandler(btnHuy_Click);
            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnThem, btnSua, btnXoa, btnLuu, btnHuy });

            ClientSize = new System.Drawing.Size(590, 512); Text = "Quản Lý Loại Hàng"; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += new System.EventHandler(frmLoaiHang_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, dgvLoaiHang, grpThongTin, pnlButtons });
            ((System.ComponentModel.ISupportInitialize)dgvLoaiHang).EndInit();
            grpThongTin.ResumeLayout(false); pnlButtons.ResumeLayout(false); ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitle, lblTenLoai, lblMoTa;
        private System.Windows.Forms.TextBox txtTenLoai, txtMoTa;
        private System.Windows.Forms.DataGridView dgvLoaiHang;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnLuu, btnHuy;
    }
}
