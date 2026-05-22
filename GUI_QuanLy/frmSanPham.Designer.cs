namespace GUI_QuanLy
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
            dgvSanPham = new DataGridView();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            grpThongTin = new GroupBox();
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblDanhMuc = new Label();
            cbDanhMuc = new ComboBox();
            lblNhaCungCap = new Label();
            cbNhaCungCap = new ComboBox();
            lblGiaNhap = new Label();
            txtGiaNhap = new TextBox();
            lblGiaBan = new Label();
            txtGiaBan = new TextBox();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            lblSoLuongMin = new Label();
            txtSoLuongMin = new TextBox();
            lblDonVi = new Label();
            txtDonVi = new TextBox();
            pnlButtons = new Panel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            btnExcel = new Button();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            grpThongTin.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.ColumnHeadersHeight = 29;
            dgvSanPham.Location = new Point(12, 85);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(760, 330);
            dgvSanPham.TabIndex = 3;
            dgvSanPham.RowEnter += dgvSanPham_RowEnter;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(105, 49);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(280, 27);
            txtTimKiem.TabIndex = 2;
            txtTimKiem.KeyUp += txtTimKiem_KeyUp;
            // 
            // lblTimKiem
            // 
            lblTimKiem.Location = new Point(12, 52);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(90, 24);
            lblTimKiem.TabIndex = 1;
            lblTimKiem.Text = "🔍 Tìm kiếm:";
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblMaSP);
            grpThongTin.Controls.Add(txtMaSP);
            grpThongTin.Controls.Add(lblTenSP);
            grpThongTin.Controls.Add(txtTenSP);
            grpThongTin.Controls.Add(lblDanhMuc);
            grpThongTin.Controls.Add(cbDanhMuc);
            grpThongTin.Controls.Add(lblNhaCungCap);
            grpThongTin.Controls.Add(cbNhaCungCap);
            grpThongTin.Controls.Add(lblGiaNhap);
            grpThongTin.Controls.Add(txtGiaNhap);
            grpThongTin.Controls.Add(lblGiaBan);
            grpThongTin.Controls.Add(txtGiaBan);
            grpThongTin.Controls.Add(lblSoLuong);
            grpThongTin.Controls.Add(txtSoLuong);
            grpThongTin.Controls.Add(lblSoLuongMin);
            grpThongTin.Controls.Add(txtSoLuongMin);
            grpThongTin.Controls.Add(lblDonVi);
            grpThongTin.Controls.Add(txtDonVi);
            grpThongTin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpThongTin.Location = new Point(12, 430);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(760, 185);
            grpThongTin.TabIndex = 4;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sản phẩm";
            // 
            // lblMaSP
            // 
            lblMaSP.Location = new Point(15, 30);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(100, 22);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã SP:";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(120, 30);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(150, 27);
            txtMaSP.TabIndex = 1;
            // 
            // lblTenSP
            // 
            lblTenSP.Location = new Point(15, 65);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(100, 22);
            lblTenSP.TabIndex = 2;
            lblTenSP.Text = "Tên SP:";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(120, 65);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(280, 27);
            txtTenSP.TabIndex = 3;
            // 
            // lblDanhMuc
            // 
            lblDanhMuc.Location = new Point(15, 100);
            lblDanhMuc.Name = "lblDanhMuc";
            lblDanhMuc.Size = new Size(100, 22);
            lblDanhMuc.TabIndex = 4;
            lblDanhMuc.Text = "Danh mục:";
            // 
            // cbDanhMuc
            // 
            cbDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDanhMuc.Location = new Point(120, 100);
            cbDanhMuc.Name = "cbDanhMuc";
            cbDanhMuc.Size = new Size(200, 28);
            cbDanhMuc.TabIndex = 5;
            // 
            // lblNhaCungCap
            // 
            lblNhaCungCap.Location = new Point(15, 135);
            lblNhaCungCap.Name = "lblNhaCungCap";
            lblNhaCungCap.Size = new Size(100, 22);
            lblNhaCungCap.TabIndex = 6;
            lblNhaCungCap.Text = "Nhà CC:";
            // 
            // cbNhaCungCap
            // 
            cbNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNhaCungCap.Location = new Point(120, 135);
            cbNhaCungCap.Name = "cbNhaCungCap";
            cbNhaCungCap.Size = new Size(200, 28);
            cbNhaCungCap.TabIndex = 7;
            // 
            // lblGiaNhap
            // 
            lblGiaNhap.Location = new Point(429, 30);
            lblGiaNhap.Name = "lblGiaNhap";
            lblGiaNhap.Size = new Size(95, 22);
            lblGiaNhap.TabIndex = 8;
            lblGiaNhap.Text = "Giá nhập:";
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Location = new Point(529, 30);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(130, 27);
            txtGiaNhap.TabIndex = 9;
            // 
            // lblGiaBan
            // 
            lblGiaBan.Location = new Point(429, 65);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(95, 22);
            lblGiaBan.TabIndex = 10;
            lblGiaBan.Text = "Giá bán:";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(529, 65);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(130, 27);
            txtGiaBan.TabIndex = 11;
            // 
            // lblSoLuong
            // 
            lblSoLuong.Location = new Point(429, 100);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(95, 22);
            lblSoLuong.TabIndex = 12;
            lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(529, 100);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(60, 27);
            txtSoLuong.TabIndex = 13;
            // 
            // lblSoLuongMin
            // 
            lblSoLuongMin.Location = new Point(429, 135);
            lblSoLuongMin.Name = "lblSoLuongMin";
            lblSoLuongMin.Size = new Size(95, 22);
            lblSoLuongMin.TabIndex = 14;
            lblSoLuongMin.Text = "SL tối thiểu:";
            // 
            // txtSoLuongMin
            // 
            txtSoLuongMin.Location = new Point(529, 135);
            txtSoLuongMin.Name = "txtSoLuongMin";
            txtSoLuongMin.Size = new Size(80, 27);
            txtSoLuongMin.TabIndex = 15;
            // 
            // lblDonVi
            // 
            lblDonVi.Location = new Point(600, 100);
            lblDonVi.Name = "lblDonVi";
            lblDonVi.Size = new Size(55, 22);
            lblDonVi.TabIndex = 16;
            lblDonVi.Text = "Đơn vị:";
            // 
            // txtDonVi
            // 
            txtDonVi.Location = new Point(660, 100);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.Size = new Size(80, 27);
            txtDonVi.TabIndex = 17;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnSua);
            pnlButtons.Controls.Add(btnXoa);
            pnlButtons.Controls.Add(btnLuu);
            pnlButtons.Controls.Add(btnHuy);
            pnlButtons.Controls.Add(btnExcel);
            pnlButtons.Location = new Point(12, 628);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(760, 45);
            pnlButtons.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.SeaGreen;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(5, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 35);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.SteelBlue;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(120, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 35);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Crimson;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(235, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 35);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑 Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.DarkOrange;
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(350, 5);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 35);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Gray;
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(465, 5);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 35);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "✖ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnExcel
            // 
            btnExcel.BackColor = Color.DarkGreen;
            btnExcel.ForeColor = Color.White;
            btnExcel.Location = new Point(650, 5);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(100, 35);
            btnExcel.TabIndex = 5;
            btnExcel.Text = "📂 Excel";
            btnExcel.UseVisualStyleBackColor = false;
            btnExcel.Click += btnExcel_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // frmSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 720);
            Controls.Add(lblTitle);
            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(dgvSanPham);
            Controls.Add(grpThongTin);
            Controls.Add(pnlButtons);
            Name = "frmSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Sản Phẩm";
            Load += frmSanPham_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
