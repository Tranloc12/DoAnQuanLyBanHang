namespace GUI_QuanLy
{
    partial class frmDonHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            grpLoc = new GroupBox();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            btnLoc = new Button();
            btnTatCa = new Button();
            txtTimKiem = new TextBox();
            dgvDonHang = new DataGridView();
            lblChiTiet = new Label();
            dgvChiTiet = new DataGridView();
            pnlButtons = new Panel();
            btnXemChiTiet = new Button();
            btnHuyDon = new Button();
            grpLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LỊCH SỬ ĐƠN HÀNG";
            // 
            // grpLoc
            // 
            grpLoc.Controls.Add(lblTuNgay);
            grpLoc.Controls.Add(dtpTuNgay);
            grpLoc.Controls.Add(lblDenNgay);
            grpLoc.Controls.Add(dtpDenNgay);
            grpLoc.Controls.Add(btnLoc);
            grpLoc.Controls.Add(btnTatCa);
            grpLoc.Controls.Add(txtTimKiem);
            grpLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpLoc.Location = new Point(12, 47);
            grpLoc.Name = "grpLoc";
            grpLoc.Size = new Size(760, 55);
            grpLoc.TabIndex = 1;
            grpLoc.TabStop = false;
            grpLoc.Text = "Lọc theo ngày";
            // 
            // lblTuNgay
            // 
            lblTuNgay.Location = new Point(10, 22);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(70, 22);
            lblTuNgay.TabIndex = 0;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(82, 20);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(140, 27);
            dtpTuNgay.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            lblDenNgay.Location = new Point(235, 22);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(72, 22);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(310, 20);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(140, 27);
            dtpDenNgay.TabIndex = 3;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.SteelBlue;
            btnLoc.ForeColor = Color.White;
            btnLoc.Location = new Point(460, 18);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(85, 30);
            btnLoc.TabIndex = 4;
            btnLoc.Text = "🔍 Lọc";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            // 
            // btnTatCa
            // 
            btnTatCa.BackColor = Color.SlateGray;
            btnTatCa.ForeColor = Color.White;
            btnTatCa.Location = new Point(555, 18);
            btnTatCa.Name = "btnTatCa";
            btnTatCa.Size = new Size(90, 30);
            btnTatCa.TabIndex = 5;
            btnTatCa.Text = "📋 Tất cả";
            btnTatCa.UseVisualStyleBackColor = false;
            btnTatCa.Click += btnTatCa_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(650, 18);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Mã/Tên KH";
            txtTimKiem.Size = new Size(100, 27);
            txtTimKiem.TabIndex = 6;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            txtTimKiem.KeyUp += txtTimKiem_KeyUp;
            // 
            // dgvDonHang
            // 
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonHang.ColumnHeadersHeight = 29;
            dgvDonHang.Location = new Point(12, 112);
            dgvDonHang.Name = "dgvDonHang";
            dgvDonHang.ReadOnly = true;
            dgvDonHang.RowHeadersWidth = 51;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.Size = new Size(760, 240);
            dgvDonHang.TabIndex = 2;
            dgvDonHang.RowEnter += dgvDonHang_RowEnter;
            // 
            // lblChiTiet
            // 
            lblChiTiet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblChiTiet.Location = new Point(12, 360);
            lblChiTiet.Name = "lblChiTiet";
            lblChiTiet.Size = new Size(200, 22);
            lblChiTiet.TabIndex = 3;
            lblChiTiet.Text = "Chi tiết đơn hàng:";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ColumnHeadersHeight = 29;
            dgvChiTiet.Location = new Point(12, 382);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.Size = new Size(760, 175);
            dgvChiTiet.TabIndex = 4;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnXemChiTiet);
            pnlButtons.Controls.Add(btnHuyDon);
            pnlButtons.Location = new Point(12, 568);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(760, 42);
            pnlButtons.TabIndex = 5;
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.BackColor = Color.SteelBlue;
            btnXemChiTiet.ForeColor = Color.White;
            btnXemChiTiet.Location = new Point(5, 5);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(140, 32);
            btnXemChiTiet.TabIndex = 0;
            btnXemChiTiet.Text = "📄 Xem chi tiết";
            btnXemChiTiet.UseVisualStyleBackColor = false;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // btnHuyDon
            // 
            btnHuyDon.BackColor = Color.Crimson;
            btnHuyDon.ForeColor = Color.White;
            btnHuyDon.Location = new Point(155, 5);
            btnHuyDon.Name = "btnHuyDon";
            btnHuyDon.Size = new Size(120, 32);
            btnHuyDon.TabIndex = 1;
            btnHuyDon.Text = "❌ Hủy đơn";
            btnHuyDon.UseVisualStyleBackColor = false;
            btnHuyDon.Click += btnHuyDon_Click;
            // 
            // frmDonHang
            // 
            ClientSize = new Size(800, 625);
            Controls.Add(lblTitle);
            Controls.Add(grpLoc);
            Controls.Add(dgvDonHang);
            Controls.Add(lblChiTiet);
            Controls.Add(dgvChiTiet);
            Controls.Add(pnlButtons);
            Name = "frmDonHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lịch Sử Đơn Hàng";
            Load += frmDonHang_Load;
            grpLoc.ResumeLayout(false);
            grpLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle, lblTuNgay, lblDenNgay, lblChiTiet;
        private System.Windows.Forms.DateTimePicker dtpTuNgay, dtpDenNgay;
        private System.Windows.Forms.Button btnLoc, btnTatCa, btnXemChiTiet, btnHuyDon;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvDonHang, dgvChiTiet;
        private System.Windows.Forms.GroupBox grpLoc;
        private System.Windows.Forms.Panel pnlButtons;
    }
}
