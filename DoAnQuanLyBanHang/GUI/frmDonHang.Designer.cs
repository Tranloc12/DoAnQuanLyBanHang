namespace DoAnQuanLyBanHang
{
    partial class frmDonHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle        = new System.Windows.Forms.Label();
            grpLoc          = new System.Windows.Forms.GroupBox();
            lblTuNgay       = new System.Windows.Forms.Label();
            dtpTuNgay       = new System.Windows.Forms.DateTimePicker();
            lblDenNgay      = new System.Windows.Forms.Label();
            dtpDenNgay      = new System.Windows.Forms.DateTimePicker();
            btnLoc          = new System.Windows.Forms.Button();
            btnTatCa        = new System.Windows.Forms.Button();
            txtTimKiem      = new System.Windows.Forms.TextBox();
            dgvDonHang      = new System.Windows.Forms.DataGridView();
            lblChiTiet      = new System.Windows.Forms.Label();
            dgvChiTiet      = new System.Windows.Forms.DataGridView();
            pnlButtons      = new System.Windows.Forms.Panel();
            btnXemChiTiet   = new System.Windows.Forms.Button();
            btnHuyDon       = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            grpLoc.SuspendLayout(); pnlButtons.SuspendLayout(); SuspendLayout();

            lblTitle.Text = "LỊCH SỬ ĐƠN HÀNG"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.DarkGreen; lblTitle.Location = new System.Drawing.Point(12, 10); lblTitle.Size = new System.Drawing.Size(350, 30);

            grpLoc.Text = "Lọc theo ngày"; grpLoc.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpLoc.Location = new System.Drawing.Point(12, 47); grpLoc.Size = new System.Drawing.Size(760, 55);
            lblTuNgay.Text = "Từ ngày:"; lblTuNgay.Location = new System.Drawing.Point(10, 22); lblTuNgay.Size = new System.Drawing.Size(70, 22);
            dtpTuNgay.Location = new System.Drawing.Point(82, 20); dtpTuNgay.Size = new System.Drawing.Size(140, 27); dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            lblDenNgay.Text = "Đến ngày:"; lblDenNgay.Location = new System.Drawing.Point(235, 22); lblDenNgay.Size = new System.Drawing.Size(72, 22);
            dtpDenNgay.Location = new System.Drawing.Point(310, 20); dtpDenNgay.Size = new System.Drawing.Size(140, 27); dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            btnLoc.Text = "🔍 Lọc"; btnLoc.Location = new System.Drawing.Point(460, 18); btnLoc.Size = new System.Drawing.Size(85, 30); btnLoc.BackColor = System.Drawing.Color.SteelBlue; btnLoc.ForeColor = System.Drawing.Color.White; btnLoc.Click += new System.EventHandler(btnLoc_Click);
            btnTatCa.Text = "📋 Tất cả"; btnTatCa.Location = new System.Drawing.Point(555, 18); btnTatCa.Size = new System.Drawing.Size(90, 30); btnTatCa.BackColor = System.Drawing.Color.SlateGray; btnTatCa.ForeColor = System.Drawing.Color.White; btnTatCa.Click += new System.EventHandler(btnTatCa_Click);
            
            txtTimKiem.Location = new System.Drawing.Point(650, 18); txtTimKiem.Size = new System.Drawing.Size(100, 30); txtTimKiem.PlaceholderText = "Mã/Tên KH"; txtTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(txtTimKiem_KeyUp);

            grpLoc.Controls.AddRange(new System.Windows.Forms.Control[] { lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnLoc, btnTatCa, txtTimKiem });

            dgvDonHang.Location = new System.Drawing.Point(12, 112); dgvDonHang.Size = new System.Drawing.Size(760, 240);
            dgvDonHang.AllowUserToAddRows = false; dgvDonHang.ReadOnly = true;
            dgvDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonHang.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dgvDonHang_RowEnter);

            lblChiTiet.Text = "Chi tiết đơn hàng:"; lblChiTiet.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold); lblChiTiet.Location = new System.Drawing.Point(12, 360); lblChiTiet.Size = new System.Drawing.Size(200, 22);
            dgvChiTiet.Location = new System.Drawing.Point(12, 382); dgvChiTiet.Size = new System.Drawing.Size(760, 175);
            dgvChiTiet.AllowUserToAddRows = false; dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            pnlButtons.Location = new System.Drawing.Point(12, 568); pnlButtons.Size = new System.Drawing.Size(760, 42);
            btnXemChiTiet.Text = "📄 Xem chi tiết"; btnXemChiTiet.Location = new System.Drawing.Point(5, 5); btnXemChiTiet.Size = new System.Drawing.Size(140, 32); btnXemChiTiet.BackColor = System.Drawing.Color.SteelBlue; btnXemChiTiet.ForeColor = System.Drawing.Color.White; btnXemChiTiet.Click += new System.EventHandler(btnXemChiTiet_Click);
            btnHuyDon.Text    = "❌ Hủy đơn";    btnHuyDon.Location    = new System.Drawing.Point(155, 5); btnHuyDon.Size    = new System.Drawing.Size(120, 32); btnHuyDon.BackColor    = System.Drawing.Color.Crimson;    btnHuyDon.ForeColor    = System.Drawing.Color.White; btnHuyDon.Click    += new System.EventHandler(btnHuyDon_Click);
            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnXemChiTiet, btnHuyDon });

            ClientSize = new System.Drawing.Size(800, 625); Text = "Lịch Sử Đơn Hàng"; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += new System.EventHandler(frmDonHang_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, grpLoc, dgvDonHang, lblChiTiet, dgvChiTiet, pnlButtons });

            ((System.ComponentModel.ISupportInitialize)dgvDonHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            grpLoc.ResumeLayout(false); pnlButtons.ResumeLayout(false); ResumeLayout(false);
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
