namespace DoAnQuanLyBanHang
{
    partial class frmBanHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            dgvGioHang = new DataGridView();
            grpChonSP = new GroupBox();
            txtTimSanPham = new TextBox();
            lblSanPham = new Label();
            cbSanPham = new ComboBox();
            lblDonGia = new Label();
            txtDonGia = new TextBox();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            btnThemVaoGio = new Button();
            btnXoaDong = new Button();
            grpKhachHang = new GroupBox();
            lblSDTKH = new Label();
            txtSDTKhachHang = new TextBox();
            btnTimKH = new Button();
            lblTenKhachHang = new Label();
            txtTenKhachHang = new TextBox();
            chkDungDiem = new CheckBox();
            txtSoDiem = new TextBox();
            lblQuyDoi = new Label();
            grpThanhToan = new GroupBox();
            lblTongTienTitle = new Label();
            lblTongTien = new Label();
            lblGiamGia = new Label();
            txtGiamGia = new TextBox();
            lblThanhToanTitle = new Label();
            lblThanhToan = new Label();
            lblPTTT = new Label();
            cbPhuongThucTT = new ComboBox();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            btnThanhToan = new Button();
            btnInHoaDon = new Button();
            btnLamMoi = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            grpChonSP.SuspendLayout();
            grpKhachHang.SuspendLayout();
            grpThanhToan.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\U0001f6d2 BÁN HÀNG (POS)";
            // 
            // dgvGioHang
            // 
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.ColumnHeadersHeight = 29;
            dgvGioHang.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvGioHang.Location = new Point(10, 135);
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.ReadOnly = true;
            dgvGioHang.RowHeadersWidth = 51;
            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.Size = new Size(700, 270);
            dgvGioHang.TabIndex = 2;
            // 
            // grpChonSP
            // 
            grpChonSP.Controls.Add(txtTimSanPham);
            grpChonSP.Controls.Add(lblSanPham);
            grpChonSP.Controls.Add(cbSanPham);
            grpChonSP.Controls.Add(lblDonGia);
            grpChonSP.Controls.Add(txtDonGia);
            grpChonSP.Controls.Add(lblSoLuong);
            grpChonSP.Controls.Add(txtSoLuong);
            grpChonSP.Controls.Add(btnThemVaoGio);
            grpChonSP.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpChonSP.Location = new Point(10, 50);
            grpChonSP.Name = "grpChonSP";
            grpChonSP.Size = new Size(700, 75);
            grpChonSP.TabIndex = 1;
            grpChonSP.TabStop = false;
            grpChonSP.Text = "Chọn sản phẩm";
            // 
            // txtTimSanPham
            // 
            txtTimSanPham.Location = new Point(10, 25);
            txtTimSanPham.Name = "txtTimSanPham";
            txtTimSanPham.Size = new Size(100, 27);
            txtTimSanPham.TabIndex = 0;
            txtTimSanPham.PlaceholderText = "Mã/Tên SP";
            txtTimSanPham.KeyDown += txtTimSanPham_KeyDown;
            // 
            // lblSanPham
            // 
            lblSanPham.Location = new Point(115, 28);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(70, 22);
            lblSanPham.TabIndex = 1;
            lblSanPham.Text = "Sản phẩm:";
            // 
            // cbSanPham
            // 
            cbSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSanPham.Location = new Point(185, 25);
            cbSanPham.Name = "cbSanPham";
            cbSanPham.Size = new Size(195, 28);
            cbSanPham.TabIndex = 2;
            cbSanPham.SelectedIndexChanged += cbSanPham_SelectedIndexChanged;
            // 
            // lblDonGia
            // 
            lblDonGia.Location = new Point(385, 28);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(65, 22);
            lblDonGia.TabIndex = 2;
            lblDonGia.Text = "Đơn giá:";
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(453, 25);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(90, 27);
            txtDonGia.TabIndex = 3;
            // 
            // lblSoLuong
            // 
            lblSoLuong.Location = new Point(548, 28);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(28, 22);
            lblSoLuong.TabIndex = 4;
            lblSoLuong.Text = "SL:";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(578, 25);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(50, 27);
            txtSoLuong.TabIndex = 5;
            txtSoLuong.Text = "1";
            // 
            // btnThemVaoGio
            // 
            btnThemVaoGio.BackColor = Color.SeaGreen;
            btnThemVaoGio.ForeColor = Color.White;
            btnThemVaoGio.Location = new Point(634, 22);
            btnThemVaoGio.Name = "btnThemVaoGio";
            btnThemVaoGio.Size = new Size(58, 30);
            btnThemVaoGio.TabIndex = 6;
            btnThemVaoGio.Text = "➕ Thêm";
            btnThemVaoGio.UseVisualStyleBackColor = false;
            btnThemVaoGio.Click += btnThemVaoGio_Click;
            // 
            // btnXoaDong
            // 
            btnXoaDong.BackColor = Color.Crimson;
            btnXoaDong.ForeColor = Color.White;
            btnXoaDong.Location = new Point(10, 412);
            btnXoaDong.Name = "btnXoaDong";
            btnXoaDong.Size = new Size(110, 32);
            btnXoaDong.TabIndex = 3;
            btnXoaDong.Text = "🗑 Xóa dòng";
            btnXoaDong.UseVisualStyleBackColor = false;
            btnXoaDong.Click += btnXoaDong_Click;
            // 
            // grpKhachHang
            // 
            grpKhachHang.Controls.Add(lblSDTKH);
            grpKhachHang.Controls.Add(txtSDTKhachHang);
            grpKhachHang.Controls.Add(btnTimKH);
            grpKhachHang.Controls.Add(lblTenKhachHang);
            grpKhachHang.Controls.Add(txtTenKhachHang); // Thêm ô nhập tên
            grpKhachHang.Controls.Add(chkDungDiem);
            grpKhachHang.Controls.Add(txtSoDiem);
            grpKhachHang.Controls.Add(lblQuyDoi);
            grpKhachHang.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpKhachHang.Location = new Point(720, 50);
            grpKhachHang.Name = "grpKhachHang";
            grpKhachHang.Size = new Size(280, 130);
            grpKhachHang.TabIndex = 4;
            grpKhachHang.TabStop = false;
            grpKhachHang.Text = "Khách hàng";
            // 
            // lblSDTKH
            // 
            lblSDTKH.Location = new Point(10, 28);
            lblSDTKH.Name = "lblSDTKH";
            lblSDTKH.Size = new Size(65, 22);
            lblSDTKH.TabIndex = 0;
            lblSDTKH.Text = "SĐT KH:";
            // 
            // txtSDTKhachHang
            // 
            txtSDTKhachHang.Location = new Point(78, 25);
            txtSDTKhachHang.Name = "txtSDTKhachHang";
            txtSDTKhachHang.Size = new Size(120, 27);
            txtSDTKhachHang.TabIndex = 1;
            // 
            // btnTimKH
            // 
            btnTimKH.BackColor = Color.SteelBlue;
            btnTimKH.ForeColor = Color.White;
            btnTimKH.Location = new Point(202, 23);
            btnTimKH.Name = "btnTimKH";
            btnTimKH.Size = new Size(65, 30);
            btnTimKH.TabIndex = 2;
            btnTimKH.Text = "Tìm";
            btnTimKH.UseVisualStyleBackColor = false;
            btnTimKH.Click += btnTimKH_Click;
            // 
            // lblTenKhachHang
            // 
            lblTenKhachHang.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblTenKhachHang.ForeColor = Color.DarkSlateGray;
            lblTenKhachHang.Location = new Point(10, 58);
            lblTenKhachHang.Name = "lblTenKhachHang";
            lblTenKhachHang.Size = new Size(130, 22);
            lblTenKhachHang.TabIndex = 3;
            lblTenKhachHang.Text = "Tên khách hàng:";
            // 
            // txtTenKhachHang
            // 
            txtTenKhachHang.Location = new Point(140, 55);
            txtTenKhachHang.Name = "txtTenKhachHang";
            txtTenKhachHang.Size = new Size(130, 27);
            txtTenKhachHang.TabIndex = 4;
            txtTenKhachHang.PlaceholderText = "Tên khách mới";
            //
            // chkDungDiem  (Row 3: Y=88)
            //
            chkDungDiem.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            chkDungDiem.ForeColor = Color.DarkOrange;
            chkDungDiem.Location = new Point(10, 88);
            chkDungDiem.Name = "chkDungDiem";
            chkDungDiem.Size = new Size(100, 22);
            chkDungDiem.TabIndex = 4;
            chkDungDiem.Text = "⭐ Dùng điểm:";
            chkDungDiem.UseVisualStyleBackColor = true;
            chkDungDiem.CheckedChanged += chkDungDiem_CheckedChanged;
            //
            // txtSoDiem
            //
            txtSoDiem.Location = new Point(112, 86);
            txtSoDiem.Name = "txtSoDiem";
            txtSoDiem.Size = new Size(65, 27);
            txtSoDiem.TabIndex = 5;
            txtSoDiem.Text = "0";
            txtSoDiem.Enabled = false;
            txtSoDiem.TextChanged += txtSoDiem_TextChanged;
            //
            // lblQuyDoi
            //
            lblQuyDoi.Font = new Font("Segoe UI", 8F);
            lblQuyDoi.ForeColor = Color.Gray;
            lblQuyDoi.Location = new Point(180, 90);
            lblQuyDoi.Name = "lblQuyDoi";
            lblQuyDoi.Size = new Size(90, 18);
            lblQuyDoi.TabIndex = 6;
            lblQuyDoi.Text = "= 0 VNĐ";
            // 
            // grpThanhToan
            // 
            grpThanhToan.Controls.Add(lblTongTienTitle);
            grpThanhToan.Controls.Add(lblTongTien);
            grpThanhToan.Controls.Add(lblGiamGia);
            grpThanhToan.Controls.Add(txtGiamGia);
            grpThanhToan.Controls.Add(lblThanhToanTitle);
            grpThanhToan.Controls.Add(lblThanhToan);
            grpThanhToan.Controls.Add(lblPTTT);
            grpThanhToan.Controls.Add(cbPhuongThucTT);
            grpThanhToan.Controls.Add(lblGhiChu);
            grpThanhToan.Controls.Add(txtGhiChu);
            grpThanhToan.Controls.Add(btnThanhToan);
            grpThanhToan.Controls.Add(btnInHoaDon); // Thêm nút in hóa đơn
            grpThanhToan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpThanhToan.Location = new Point(720, 160);
            grpThanhToan.Name = "grpThanhToan";
            grpThanhToan.Size = new Size(280, 330);
            grpThanhToan.TabIndex = 5;
            grpThanhToan.TabStop = false;
            grpThanhToan.Text = "Thanh toán";
            // 
            // lblTongTienTitle  (Row 1: Y=28)
            // 
            lblTongTienTitle.Location = new Point(10, 28);
            lblTongTienTitle.Name = "lblTongTienTitle";
            lblTongTienTitle.Size = new Size(90, 22);
            lblTongTienTitle.TabIndex = 0;
            lblTongTienTitle.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            lblTongTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.DarkGreen;
            lblTongTien.Location = new Point(105, 28);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(160, 22);
            lblTongTien.TabIndex = 1;
            lblTongTien.Text = "0 VNĐ";
            // 
            // lblGiamGia  (Row 2: Y=60)
            // 
            lblGiamGia.Location = new Point(10, 60);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(90, 22);
            lblGiamGia.TabIndex = 2;
            lblGiamGia.Text = "Giảm giá:";
            // 
            // txtGiamGia
            // 
            txtGiamGia.Location = new Point(105, 57);
            txtGiamGia.Name = "txtGiamGia";
            txtGiamGia.Size = new Size(160, 27);
            txtGiamGia.TabIndex = 3;
            txtGiamGia.Text = "0";
            txtGiamGia.TextChanged += txtGiamGia_TextChanged;
            // 
            // lblThanhToanTitle  (Row 3: Y=98)
            // 
            lblThanhToanTitle.Location = new Point(10, 98);
            lblThanhToanTitle.Name = "lblThanhToanTitle";
            lblThanhToanTitle.Size = new Size(90, 22);
            lblThanhToanTitle.TabIndex = 4;
            lblThanhToanTitle.Text = "Thành tiền:";
            // 
            // lblThanhToan
            // 
            lblThanhToan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblThanhToan.ForeColor = Color.Crimson;
            lblThanhToan.Location = new Point(105, 95);
            lblThanhToan.Name = "lblThanhToan";
            lblThanhToan.Size = new Size(160, 26);
            lblThanhToan.TabIndex = 5;
            lblThanhToan.Text = "0 VNĐ";
            // 
            // lblPTTT  (Row 4: Y=135)
            // 
            lblPTTT.Location = new Point(10, 135);
            lblPTTT.Name = "lblPTTT";
            lblPTTT.Size = new Size(90, 22);
            lblPTTT.TabIndex = 6;
            lblPTTT.Text = "Phương thức:";
            // 
            // cbPhuongThucTT
            // 
            cbPhuongThucTT.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPhuongThucTT.Location = new Point(105, 132);
            cbPhuongThucTT.Name = "cbPhuongThucTT";
            cbPhuongThucTT.Size = new Size(160, 28);
            cbPhuongThucTT.TabIndex = 7;
            // 
            // lblGhiChu  (Row 5: Y=172)
            // 
            lblGhiChu.Location = new Point(10, 172);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(90, 22);
            lblGhiChu.TabIndex = 8;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(10, 195);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(255, 27);
            txtGhiChu.TabIndex = 9;
            // 
            // btnThanhToan  (Row 6: Y=235)
            // 
            btnThanhToan.BackColor = Color.DarkGreen;
            btnThanhToan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(10, 235);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(255, 42);
            btnThanhToan.TabIndex = 10;
            btnThanhToan.Text = "✅ THANH TOÁN";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.BackColor = Color.SteelBlue;
            btnInHoaDon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInHoaDon.ForeColor = Color.White;
            btnInHoaDon.Location = new Point(10, 282);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(255, 38);
            btnInHoaDon.TabIndex = 11;
            btnInHoaDon.Text = "🖨 IN HÓA ĐƠN";
            btnInHoaDon.UseVisualStyleBackColor = false;
            btnInHoaDon.Click += btnInHoaDon_Click;
            btnInHoaDon.Enabled = false; 
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.DimGray;
            btnLamMoi.Font = new Font("Segoe UI", 10F);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(720, 478);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(280, 38);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Mã SP";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Tên sản phẩm";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "SL";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Đơn giá";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Thành tiền";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // 
            // frmBanHang
            // 
            ClientSize = new Size(1020, 620);
            Controls.Add(lblTitle);
            Controls.Add(grpChonSP);
            Controls.Add(dgvGioHang);
            Controls.Add(btnXoaDong);
            Controls.Add(grpKhachHang);
            Controls.Add(grpThanhToan);
            Controls.Add(btnLamMoi);
            Name = "frmBanHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bán Hàng (POS)";
            Load += frmBanHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            grpChonSP.ResumeLayout(false);
            grpChonSP.PerformLayout();
            grpKhachHang.ResumeLayout(false);
            grpKhachHang.PerformLayout();
            grpThanhToan.ResumeLayout(false);
            grpThanhToan.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.GroupBox grpChonSP, grpKhachHang, grpThanhToan;
        private System.Windows.Forms.Label lblSanPham, lblDonGia, lblSoLuong;
        private System.Windows.Forms.ComboBox cbSanPham;
        private System.Windows.Forms.TextBox txtDonGia, txtSoLuong, txtTimSanPham;
        private System.Windows.Forms.Button btnThemVaoGio, btnXoaDong;
        private System.Windows.Forms.Label lblSDTKH, lblTenKhachHang;
        private System.Windows.Forms.TextBox txtSDTKhachHang;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Button btnTimKH;
        private System.Windows.Forms.Label lblTongTienTitle, lblTongTien, lblGiamGia, lblThanhToanTitle, lblThanhToan, lblPTTT, lblGhiChu;
        private System.Windows.Forms.TextBox txtGiamGia, txtGhiChu;
        private System.Windows.Forms.ComboBox cbPhuongThucTT;
        private System.Windows.Forms.Button btnThanhToan, btnInHoaDon, btnLamMoi;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.CheckBox chkDungDiem;
        private System.Windows.Forms.TextBox txtSoDiem;
        private System.Windows.Forms.Label lblQuyDoi;
    }
}
