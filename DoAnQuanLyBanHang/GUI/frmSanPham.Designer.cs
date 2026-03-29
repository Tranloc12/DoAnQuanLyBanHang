namespace DoAnQuanLyBanHang
{
    partial class frmSanPham
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvSanPham    = new System.Windows.Forms.DataGridView();
            txtTimKiem    = new System.Windows.Forms.TextBox();
            lblTimKiem    = new System.Windows.Forms.Label();
            grpThongTin   = new System.Windows.Forms.GroupBox();
            lblMaSP       = new System.Windows.Forms.Label();
            txtMaSP       = new System.Windows.Forms.TextBox();
            lblTenSP      = new System.Windows.Forms.Label();
            txtTenSP      = new System.Windows.Forms.TextBox();
            lblDanhMuc    = new System.Windows.Forms.Label();
            cbDanhMuc     = new System.Windows.Forms.ComboBox();
            lblNhaCungCap = new System.Windows.Forms.Label();
            cbNhaCungCap  = new System.Windows.Forms.ComboBox();
            lblGiaNhap    = new System.Windows.Forms.Label();
            txtGiaNhap    = new System.Windows.Forms.TextBox();
            lblGiaBan     = new System.Windows.Forms.Label();
            txtGiaBan     = new System.Windows.Forms.TextBox();
            lblSoLuong    = new System.Windows.Forms.Label();
            txtSoLuong    = new System.Windows.Forms.TextBox();
            lblSoLuongMin = new System.Windows.Forms.Label();
            txtSoLuongMin = new System.Windows.Forms.TextBox();
            lblDonVi      = new System.Windows.Forms.Label();
            txtDonVi      = new System.Windows.Forms.TextBox();
            pnlButtons    = new System.Windows.Forms.Panel();
            btnThem       = new System.Windows.Forms.Button();
            btnSua        = new System.Windows.Forms.Button();
            btnXoa        = new System.Windows.Forms.Button();
            btnLuu        = new System.Windows.Forms.Button();
            btnHuy        = new System.Windows.Forms.Button();
            btnExcel      = new System.Windows.Forms.Button();
            lblTitle      = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            grpThongTin.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // lblTitle
            lblTitle.Text      = "QUẢN LÝ SẢN PHẨM";
            lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            lblTitle.Location  = new System.Drawing.Point(12, 10);
            lblTitle.Size      = new System.Drawing.Size(350, 30);

            // lblTimKiem + txtTimKiem
            lblTimKiem.Text     = "🔍 Tìm kiếm:";
            lblTimKiem.Location = new System.Drawing.Point(12, 52);
            lblTimKiem.Size     = new System.Drawing.Size(90, 24);
            txtTimKiem.Location = new System.Drawing.Point(105, 49);
            txtTimKiem.Size     = new System.Drawing.Size(280, 27);
            txtTimKiem.KeyUp   += new System.Windows.Forms.KeyEventHandler(txtTimKiem_KeyUp);

            // dgvSanPham
            dgvSanPham.Location              = new System.Drawing.Point(12, 85);
            dgvSanPham.Size                  = new System.Drawing.Size(760, 330);
            dgvSanPham.AllowUserToAddRows    = false;
            dgvSanPham.ReadOnly              = true;
            dgvSanPham.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.RowEnter             += new System.Windows.Forms.DataGridViewCellEventHandler(dgvSanPham_RowEnter);

            // grpThongTin
            grpThongTin.Text     = "Thông tin sản phẩm";
            grpThongTin.Font     = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpThongTin.Location = new System.Drawing.Point(12, 430);
            grpThongTin.Size     = new System.Drawing.Size(760, 185);

            int lx = 15, tx = 120, ly = 25, gap = 32;

            lblMaSP.Text = "Mã SP:";         lblMaSP.Location = new System.Drawing.Point(lx, ly);       lblMaSP.Size = new System.Drawing.Size(100, 22);
            txtMaSP.Location = new System.Drawing.Point(tx, ly - 2);         txtMaSP.Size = new System.Drawing.Size(150, 27);

            lblTenSP.Text = "Tên SP:";        lblTenSP.Location = new System.Drawing.Point(lx, ly + gap);  lblTenSP.Size = new System.Drawing.Size(100, 22);
            txtTenSP.Location = new System.Drawing.Point(tx, ly + gap - 2);  txtTenSP.Size = new System.Drawing.Size(280, 27);

            lblDanhMuc.Text = "Danh mục:";   lblDanhMuc.Location = new System.Drawing.Point(lx, ly + gap * 2); lblDanhMuc.Size = new System.Drawing.Size(100, 22);
            cbDanhMuc.Location = new System.Drawing.Point(tx, ly + gap * 2 - 2); cbDanhMuc.Size = new System.Drawing.Size(200, 27); cbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            lblNhaCungCap.Text = "Nhà CC:";  lblNhaCungCap.Location = new System.Drawing.Point(lx, ly + gap * 3); lblNhaCungCap.Size = new System.Drawing.Size(100, 22);
            cbNhaCungCap.Location = new System.Drawing.Point(tx, ly + gap * 3 - 2); cbNhaCungCap.Size = new System.Drawing.Size(200, 27); cbNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            int rx = 390, rtx = 490;
            lblGiaNhap.Text = "Giá nhập:";   lblGiaNhap.Location = new System.Drawing.Point(rx, ly);         lblGiaNhap.Size = new System.Drawing.Size(95, 22);
            txtGiaNhap.Location = new System.Drawing.Point(rtx, ly - 2);         txtGiaNhap.Size = new System.Drawing.Size(130, 27);

            lblGiaBan.Text = "Giá bán:";     lblGiaBan.Location = new System.Drawing.Point(rx, ly + gap);   lblGiaBan.Size = new System.Drawing.Size(95, 22);
            txtGiaBan.Location = new System.Drawing.Point(rtx, ly + gap - 2);   txtGiaBan.Size = new System.Drawing.Size(130, 27);

            lblSoLuong.Text = "Số lượng:";   lblSoLuong.Location = new System.Drawing.Point(rx, ly + gap * 2); lblSoLuong.Size = new System.Drawing.Size(95, 22);
            txtSoLuong.Location = new System.Drawing.Point(rtx, ly + gap * 2 - 2); txtSoLuong.Size = new System.Drawing.Size(80, 27);

            lblSoLuongMin.Text = "SL tối thiểu:"; lblSoLuongMin.Location = new System.Drawing.Point(rx, ly + gap * 3); lblSoLuongMin.Size = new System.Drawing.Size(95, 22);
            txtSoLuongMin.Location = new System.Drawing.Point(rtx, ly + gap * 3 - 2); txtSoLuongMin.Size = new System.Drawing.Size(80, 27);

            lblDonVi.Text = "Đơn vị:";       lblDonVi.Location = new System.Drawing.Point(rx, ly + gap * 4); lblDonVi.Size = new System.Drawing.Size(95, 22);
            txtDonVi.Location = new System.Drawing.Point(rtx, ly + gap * 4 - 2); txtDonVi.Size = new System.Drawing.Size(100, 27);

            grpThongTin.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblMaSP, txtMaSP, lblTenSP, txtTenSP,
                lblDanhMuc, cbDanhMuc, lblNhaCungCap, cbNhaCungCap,
                lblGiaNhap, txtGiaNhap, lblGiaBan, txtGiaBan,
                lblSoLuong, txtSoLuong, lblSoLuongMin, txtSoLuongMin,
                lblDonVi, txtDonVi
            });

            // pnlButtons
            pnlButtons.Location = new System.Drawing.Point(12, 628);
            pnlButtons.Size     = new System.Drawing.Size(760, 45);

            int bx = 5, bw = 100, bh = 35;
            btnThem.Text = "➕ Thêm";  btnThem.Location = new System.Drawing.Point(bx, 5);       btnThem.Size = new System.Drawing.Size(bw, bh); btnThem.BackColor = System.Drawing.Color.SeaGreen;   btnThem.ForeColor = System.Drawing.Color.White; btnThem.Click += new System.EventHandler(btnThem_Click);
            btnSua.Text  = "✏ Sửa";   btnSua.Location  = new System.Drawing.Point(bx + 110, 5); btnSua.Size  = new System.Drawing.Size(bw, bh); btnSua.BackColor = System.Drawing.Color.SteelBlue;   btnSua.ForeColor = System.Drawing.Color.White; btnSua.Click  += new System.EventHandler(btnSua_Click);
            btnXoa.Text  = "🗑 Xóa";  btnXoa.Location  = new System.Drawing.Point(bx + 220, 5); btnXoa.Size  = new System.Drawing.Size(bw, bh); btnXoa.BackColor = System.Drawing.Color.Crimson;    btnXoa.ForeColor = System.Drawing.Color.White; btnXoa.Click  += new System.EventHandler(btnXoa_Click);
            btnLuu.Text  = "💾 Lưu";  btnLuu.Location  = new System.Drawing.Point(bx + 330, 5); btnLuu.Size  = new System.Drawing.Size(bw, bh); btnLuu.BackColor = System.Drawing.Color.DarkOrange; btnLuu.ForeColor = System.Drawing.Color.White; btnLuu.Click  += new System.EventHandler(btnLuu_Click);
            btnHuy.Text  = "✖ Hủy";   btnHuy.Location  = new System.Drawing.Point(bx + 440, 5); btnHuy.Size  = new System.Drawing.Size(bw, bh); btnHuy.BackColor = System.Drawing.Color.Gray;       btnHuy.ForeColor = System.Drawing.Color.White; btnHuy.Click  += new System.EventHandler(btnHuy_Click);
            btnExcel.Text  = "📂 Excel"; btnExcel.Location = new System.Drawing.Point(bx + 550, 5); btnExcel.Size = new System.Drawing.Size(bw, bh); btnExcel.BackColor = System.Drawing.Color.DarkGreen; btnExcel.ForeColor = System.Drawing.Color.White; btnExcel.Click += new System.EventHandler(btnExcel_Click);

            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnThem, btnSua, btnXoa, btnLuu, btnHuy, btnExcel });

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize    = new System.Drawing.Size(800, 720);
            Text          = "Quản Lý Sản Phẩm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load         += new System.EventHandler(frmSanPham_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblTimKiem, txtTimKiem, dgvSanPham, grpThongTin, pnlButtons });

            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            grpThongTin.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView    dgvSanPham;
        private System.Windows.Forms.TextBox         txtTimKiem;
        private System.Windows.Forms.Label           lblTimKiem;
        private System.Windows.Forms.GroupBox        grpThongTin;
        private System.Windows.Forms.Label           lblMaSP, lblTenSP, lblDanhMuc, lblNhaCungCap;
        private System.Windows.Forms.Label           lblGiaNhap, lblGiaBan, lblSoLuong, lblSoLuongMin, lblDonVi;
        private System.Windows.Forms.TextBox         txtMaSP, txtTenSP, txtGiaNhap, txtGiaBan;
        private System.Windows.Forms.TextBox         txtSoLuong, txtSoLuongMin, txtDonVi;
        private System.Windows.Forms.ComboBox        cbDanhMuc, cbNhaCungCap;
        private System.Windows.Forms.Panel           pnlButtons;
        private System.Windows.Forms.Button          btnThem, btnSua, btnXoa, btnLuu, btnHuy, btnExcel;
        private System.Windows.Forms.Label           lblTitle;
    }
}
