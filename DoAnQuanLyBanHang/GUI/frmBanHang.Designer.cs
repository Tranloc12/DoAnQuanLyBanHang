namespace DoAnQuanLyBanHang
{
    partial class frmBanHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle          = new System.Windows.Forms.Label();
            // -- Giỏ hàng (DataGridView)
            dgvGioHang        = new System.Windows.Forms.DataGridView();
            // -- Chọn sản phẩm
            grpChonSP         = new System.Windows.Forms.GroupBox();
            lblSanPham        = new System.Windows.Forms.Label();
            cbSanPham         = new System.Windows.Forms.ComboBox();
            lblDonGia         = new System.Windows.Forms.Label();
            txtDonGia         = new System.Windows.Forms.TextBox();
            lblSoLuong        = new System.Windows.Forms.Label();
            txtSoLuong        = new System.Windows.Forms.TextBox();
            btnThemVaoGio     = new System.Windows.Forms.Button();
            btnXoaDong        = new System.Windows.Forms.Button();
            // -- Khách hàng
            grpKhachHang      = new System.Windows.Forms.GroupBox();
            lblSDTKH          = new System.Windows.Forms.Label();
            txtSDTKhachHang   = new System.Windows.Forms.TextBox();
            btnTimKH          = new System.Windows.Forms.Button();
            lblTenKhachHang   = new System.Windows.Forms.Label();
            // -- Thanh toán
            grpThanhToan      = new System.Windows.Forms.GroupBox();
            lblTongTienTitle  = new System.Windows.Forms.Label();
            lblTongTien       = new System.Windows.Forms.Label();
            lblGiamGia        = new System.Windows.Forms.Label();
            txtGiamGia        = new System.Windows.Forms.TextBox();
            lblThanhToanTitle = new System.Windows.Forms.Label();
            lblThanhToan      = new System.Windows.Forms.Label();
            lblPTTT           = new System.Windows.Forms.Label();
            cbPhuongThucTT    = new System.Windows.Forms.ComboBox();
            lblGhiChu         = new System.Windows.Forms.Label();
            txtGhiChu         = new System.Windows.Forms.TextBox();
            btnThanhToan      = new System.Windows.Forms.Button();
            btnLamMoi         = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            grpChonSP.SuspendLayout(); grpKhachHang.SuspendLayout(); grpThanhToan.SuspendLayout();
            SuspendLayout();

            // Title
            lblTitle.Text = "🛒 BÁN HÀNG (POS)"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 15, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.DarkGreen; lblTitle.Location = new System.Drawing.Point(10, 10); lblTitle.Size = new System.Drawing.Size(350, 32);

            // grpChonSP (trên cùng bên trái)
            grpChonSP.Text = "Chọn sản phẩm"; grpChonSP.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpChonSP.Location = new System.Drawing.Point(10, 50); grpChonSP.Size = new System.Drawing.Size(700, 75);
            lblSanPham.Text = "Sản phẩm:"; lblSanPham.Location = new System.Drawing.Point(10, 28); lblSanPham.Size = new System.Drawing.Size(80, 22);
            cbSanPham.Location = new System.Drawing.Point(95, 25); cbSanPham.Size = new System.Drawing.Size(280, 27); cbSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; cbSanPham.SelectedIndexChanged += new System.EventHandler(cbSanPham_SelectedIndexChanged);
            lblDonGia.Text = "Đơn giá:"; lblDonGia.Location = new System.Drawing.Point(385, 28); lblDonGia.Size = new System.Drawing.Size(65, 22);
            txtDonGia.Location = new System.Drawing.Point(453, 25); txtDonGia.Size = new System.Drawing.Size(90, 27);
            lblSoLuong.Text = "SL:"; lblSoLuong.Location = new System.Drawing.Point(548, 28); lblSoLuong.Size = new System.Drawing.Size(28, 22);
            txtSoLuong.Location = new System.Drawing.Point(578, 25); txtSoLuong.Size = new System.Drawing.Size(50, 27); txtSoLuong.Text = "1";
            btnThemVaoGio.Text = "➕ Thêm"; btnThemVaoGio.Location = new System.Drawing.Point(634, 22); btnThemVaoGio.Size = new System.Drawing.Size(58, 30); btnThemVaoGio.BackColor = System.Drawing.Color.SeaGreen; btnThemVaoGio.ForeColor = System.Drawing.Color.White; btnThemVaoGio.Click += new System.EventHandler(btnThemVaoGio_Click);
            grpChonSP.Controls.AddRange(new System.Windows.Forms.Control[] { lblSanPham, cbSanPham, lblDonGia, txtDonGia, lblSoLuong, txtSoLuong, btnThemVaoGio });

            // dgvGioHang
            dgvGioHang.Location = new System.Drawing.Point(10, 135); dgvGioHang.Size = new System.Drawing.Size(700, 270);
            dgvGioHang.AllowUserToAddRows = false; dgvGioHang.ReadOnly = true; dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.Columns.Add("MaSP", "Mã SP"); dgvGioHang.Columns.Add("TenSP", "Tên sản phẩm"); dgvGioHang.Columns.Add("SoLuong", "SL"); dgvGioHang.Columns.Add("DonGia", "Đơn giá"); dgvGioHang.Columns.Add("ThanhTien", "Thành tiền");
            dgvGioHang.Columns["TenSP"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            btnXoaDong.Text = "🗑 Xóa dòng"; btnXoaDong.Location = new System.Drawing.Point(10, 412); btnXoaDong.Size = new System.Drawing.Size(110, 32); btnXoaDong.BackColor = System.Drawing.Color.Crimson; btnXoaDong.ForeColor = System.Drawing.Color.White; btnXoaDong.Click += new System.EventHandler(btnXoaDong_Click);

            // grpKhachHang (bên phải trên)
            grpKhachHang.Text = "Khách hàng"; grpKhachHang.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpKhachHang.Location = new System.Drawing.Point(720, 50); grpKhachHang.Size = new System.Drawing.Size(280, 100);
            lblSDTKH.Text = "SĐT KH:"; lblSDTKH.Location = new System.Drawing.Point(10, 28); lblSDTKH.Size = new System.Drawing.Size(65, 22);
            txtSDTKhachHang.Location = new System.Drawing.Point(78, 25); txtSDTKhachHang.Size = new System.Drawing.Size(120, 27);
            btnTimKH.Text = "Tìm"; btnTimKH.Location = new System.Drawing.Point(202, 23); btnTimKH.Size = new System.Drawing.Size(65, 30); btnTimKH.BackColor = System.Drawing.Color.SteelBlue; btnTimKH.ForeColor = System.Drawing.Color.White; btnTimKH.Click += new System.EventHandler(btnTimKH_Click);
            lblTenKhachHang.Text = "Khách lẻ"; lblTenKhachHang.Location = new System.Drawing.Point(10, 60); lblTenKhachHang.Size = new System.Drawing.Size(255, 22); lblTenKhachHang.ForeColor = System.Drawing.Color.Navy; lblTenKhachHang.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            grpKhachHang.Controls.AddRange(new System.Windows.Forms.Control[] { lblSDTKH, txtSDTKhachHang, btnTimKH, lblTenKhachHang });

            // grpThanhToan (bên phải dưới)
            grpThanhToan.Text = "Thanh toán"; grpThanhToan.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpThanhToan.Location = new System.Drawing.Point(720, 160); grpThanhToan.Size = new System.Drawing.Size(280, 310);
            int ty = 25, tgap = 38;
            lblTongTienTitle.Text = "Tổng tiền:"; lblTongTienTitle.Location = new System.Drawing.Point(10, ty); lblTongTienTitle.Size = new System.Drawing.Size(90, 22);
            lblTongTien.Text = "0 VNĐ"; lblTongTien.Location = new System.Drawing.Point(105, ty); lblTongTien.Size = new System.Drawing.Size(160, 22); lblTongTien.ForeColor = System.Drawing.Color.DarkGreen; lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblGiamGia.Text = "Giảm giá:"; lblGiamGia.Location = new System.Drawing.Point(10, ty + tgap); lblGiamGia.Size = new System.Drawing.Size(90, 22);
            txtGiamGia.Text = "0"; txtGiamGia.Location = new System.Drawing.Point(105, ty + tgap - 2); txtGiamGia.Size = new System.Drawing.Size(120, 27); txtGiamGia.TextChanged += new System.EventHandler(txtGiamGia_TextChanged);
            lblThanhToanTitle.Text = "Thành toán:"; lblThanhToanTitle.Location = new System.Drawing.Point(10, ty + tgap * 2); lblThanhToanTitle.Size = new System.Drawing.Size(90, 22);
            lblThanhToan.Text = "0 VNĐ"; lblThanhToan.Location = new System.Drawing.Point(105, ty + tgap * 2); lblThanhToan.Size = new System.Drawing.Size(160, 26); lblThanhToan.ForeColor = System.Drawing.Color.Crimson; lblThanhToan.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            lblPTTT.Text = "Thanh toán:"; lblPTTT.Location = new System.Drawing.Point(10, ty + tgap * 3 + 5); lblPTTT.Size = new System.Drawing.Size(90, 22);
            cbPhuongThucTT.Location = new System.Drawing.Point(105, ty + tgap * 3 + 2); cbPhuongThucTT.Size = new System.Drawing.Size(155, 27); cbPhuongThucTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            lblGhiChu.Text = "Ghi chú:"; lblGhiChu.Location = new System.Drawing.Point(10, ty + tgap * 4 + 5); lblGhiChu.Size = new System.Drawing.Size(90, 22);
            txtGhiChu.Location = new System.Drawing.Point(10, ty + tgap * 4 + 28); txtGhiChu.Size = new System.Drawing.Size(250, 27);
            btnThanhToan.Text = "✅ THANH TOÁN"; btnThanhToan.Location = new System.Drawing.Point(10, ty + tgap * 5 + 25); btnThanhToan.Size = new System.Drawing.Size(255, 42); btnThanhToan.BackColor = System.Drawing.Color.DarkGreen; btnThanhToan.ForeColor = System.Drawing.Color.White; btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold); btnThanhToan.Click += new System.EventHandler(btnThanhToan_Click);
            grpThanhToan.Controls.AddRange(new System.Windows.Forms.Control[] { lblTongTienTitle, lblTongTien, lblGiamGia, txtGiamGia, lblThanhToanTitle, lblThanhToan, lblPTTT, cbPhuongThucTT, lblGhiChu, txtGhiChu, btnThanhToan });

            btnLamMoi.Text = "🔄 Làm mới"; btnLamMoi.Location = new System.Drawing.Point(720, 478); btnLamMoi.Size = new System.Drawing.Size(280, 38); btnLamMoi.BackColor = System.Drawing.Color.DimGray; btnLamMoi.ForeColor = System.Drawing.Color.White; btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10); btnLamMoi.Click += new System.EventHandler(btnLamMoi_Click);

            ClientSize = new System.Drawing.Size(1020, 540); Text = "Bán Hàng (POS)"; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; Load += new System.EventHandler(frmBanHang_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, grpChonSP, dgvGioHang, btnXoaDong, grpKhachHang, grpThanhToan, btnLamMoi });

            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            grpChonSP.ResumeLayout(false); grpKhachHang.ResumeLayout(false); grpThanhToan.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.GroupBox grpChonSP, grpKhachHang, grpThanhToan;
        private System.Windows.Forms.Label lblSanPham, lblDonGia, lblSoLuong;
        private System.Windows.Forms.ComboBox cbSanPham;
        private System.Windows.Forms.TextBox txtDonGia, txtSoLuong;
        private System.Windows.Forms.Button btnThemVaoGio, btnXoaDong;
        private System.Windows.Forms.Label lblSDTKH, lblTenKhachHang;
        private System.Windows.Forms.TextBox txtSDTKhachHang;
        private System.Windows.Forms.Button btnTimKH;
        private System.Windows.Forms.Label lblTongTienTitle, lblTongTien, lblGiamGia, lblThanhToanTitle, lblThanhToan, lblPTTT, lblGhiChu;
        private System.Windows.Forms.TextBox txtGiamGia, txtGhiChu;
        private System.Windows.Forms.ComboBox cbPhuongThucTT;
        private System.Windows.Forms.Button btnThanhToan, btnLamMoi;
    }
}
