namespace GUI_QuanLy
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlKPI = new Panel();
            pnlCard1 = new Panel();
            lblCard1Title = new Label();
            lblDoanhThuHomNay = new Label();
            pnlCard2 = new Panel();
            lblCard2Title = new Label();
            lblTongDonHomNay = new Label();
            pnlCard3 = new Panel();
            lblCard3Title = new Label();
            lblTongKhachHang = new Label();
            pnlCard4 = new Panel();
            lblCard4Title = new Label();
            lblSanPhamSapHet = new Label();
            grpLoc = new GroupBox();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            btnXemBaoCao = new Button();
            btnXemSapHet = new Button();
            btnBanChay = new Button();
            btnCaHomNay = new Button();
            btnLamMoi = new Button();
            lblKetQua = new Label();
            dgvBaoCao = new DataGridView();
            pnlKPI.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            grpLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 BÁO CÁO & THỐNG KÊ";
            // 
            // pnlKPI
            // 
            pnlKPI.BackColor = Color.Transparent;
            pnlKPI.Controls.Add(pnlCard1);
            pnlKPI.Controls.Add(pnlCard2);
            pnlKPI.Controls.Add(pnlCard3);
            pnlKPI.Controls.Add(pnlCard4);
            pnlKPI.Location = new Point(12, 48);
            pnlKPI.Name = "pnlKPI";
            pnlKPI.Size = new Size(1170, 105);
            pnlKPI.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlKPI.TabIndex = 1;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.FromArgb(34, 139, 34);
            pnlCard1.BorderStyle = BorderStyle.FixedSingle;
            pnlCard1.Controls.Add(lblCard1Title);
            pnlCard1.Controls.Add(lblDoanhThuHomNay);
            pnlCard1.Location = new Point(0, 0);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(280, 95);
            pnlCard1.TabIndex = 0;
            // 
            // lblCard1Title
            // 
            lblCard1Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard1Title.ForeColor = Color.White;
            lblCard1Title.Location = new Point(10, 12);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Size = new Size(200, 22);
            lblCard1Title.TabIndex = 0;
            lblCard1Title.Text = "💰 Doanh thu hôm nay";
            // 
            // lblDoanhThuHomNay
            // 
            lblDoanhThuHomNay.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDoanhThuHomNay.ForeColor = Color.White;
            lblDoanhThuHomNay.Location = new Point(10, 45);
            lblDoanhThuHomNay.Name = "lblDoanhThuHomNay";
            lblDoanhThuHomNay.Size = new Size(200, 35);
            lblDoanhThuHomNay.TabIndex = 1;
            lblDoanhThuHomNay.Text = "...";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.FromArgb(30, 144, 255);
            pnlCard2.BorderStyle = BorderStyle.FixedSingle;
            pnlCard2.Controls.Add(lblCard2Title);
            pnlCard2.Controls.Add(lblTongDonHomNay);
            pnlCard2.Location = new Point(296, 0);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(280, 95);
            pnlCard2.TabIndex = 1;
            // 
            // lblCard2Title
            // 
            lblCard2Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard2Title.ForeColor = Color.White;
            lblCard2Title.Location = new Point(10, 12);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Size = new Size(200, 22);
            lblCard2Title.TabIndex = 0;
            lblCard2Title.Text = "\U0001f6d2 Đơn hàng hôm nay";
            // 
            // lblTongDonHomNay
            // 
            lblTongDonHomNay.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTongDonHomNay.ForeColor = Color.White;
            lblTongDonHomNay.Location = new Point(10, 45);
            lblTongDonHomNay.Name = "lblTongDonHomNay";
            lblTongDonHomNay.Size = new Size(200, 35);
            lblTongDonHomNay.TabIndex = 1;
            lblTongDonHomNay.Text = "...";
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.FromArgb(255, 140, 0);
            pnlCard3.BorderStyle = BorderStyle.FixedSingle;
            pnlCard3.Controls.Add(lblCard3Title);
            pnlCard3.Controls.Add(lblTongKhachHang);
            pnlCard3.Location = new Point(592, 0);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(280, 95);
            pnlCard3.TabIndex = 2;
            // 
            // lblCard3Title
            // 
            lblCard3Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard3Title.ForeColor = Color.White;
            lblCard3Title.Location = new Point(10, 12);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Size = new Size(200, 22);
            lblCard3Title.TabIndex = 0;
            lblCard3Title.Text = "👥 Tổng khách hàng";
            // 
            // lblTongKhachHang
            // 
            lblTongKhachHang.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTongKhachHang.ForeColor = Color.White;
            lblTongKhachHang.Location = new Point(10, 45);
            lblTongKhachHang.Name = "lblTongKhachHang";
            lblTongKhachHang.Size = new Size(200, 35);
            lblTongKhachHang.TabIndex = 1;
            lblTongKhachHang.Text = "...";
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.FromArgb(220, 53, 69);
            pnlCard4.BorderStyle = BorderStyle.FixedSingle;
            pnlCard4.Controls.Add(lblCard4Title);
            pnlCard4.Controls.Add(lblSanPhamSapHet);
            pnlCard4.Location = new Point(888, 0);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(280, 95);
            pnlCard4.TabIndex = 3;
            // 
            // lblCard4Title
            // 
            lblCard4Title.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCard4Title.ForeColor = Color.White;
            lblCard4Title.Location = new Point(10, 12);
            lblCard4Title.Name = "lblCard4Title";
            lblCard4Title.Size = new Size(200, 22);
            lblCard4Title.TabIndex = 0;
            lblCard4Title.Text = "⚠ Sản phẩm sắp hết";
            // 
            // lblSanPhamSapHet
            // 
            lblSanPhamSapHet.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSanPhamSapHet.ForeColor = Color.White;
            lblSanPhamSapHet.Location = new Point(10, 45);
            lblSanPhamSapHet.Name = "lblSanPhamSapHet";
            lblSanPhamSapHet.Size = new Size(200, 35);
            lblSanPhamSapHet.TabIndex = 1;
            lblSanPhamSapHet.Text = "...";
            // 
            // grpLoc
            // 
            grpLoc.Controls.Add(lblTuNgay);
            grpLoc.Controls.Add(dtpTuNgay);
            grpLoc.Controls.Add(lblDenNgay);
            grpLoc.Controls.Add(dtpDenNgay);
            grpLoc.Controls.Add(btnXemBaoCao);
            grpLoc.Controls.Add(btnXemSapHet);
            grpLoc.Controls.Add(btnBanChay);
            grpLoc.Controls.Add(btnCaHomNay);
            grpLoc.Controls.Add(btnLamMoi);
            grpLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpLoc.Location = new Point(12, 162);
            grpLoc.Name = "grpLoc";
            grpLoc.Size = new Size(1170, 95);
            grpLoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpLoc.TabIndex = 2;
            grpLoc.TabStop = false;
            grpLoc.Text = "Báo cáo & lọc";
            // 
            // lblTuNgay
            // 
            lblTuNgay.Location = new Point(10, 25);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(68, 22);
            lblTuNgay.TabIndex = 0;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(80, 22);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(140, 27);
            dtpTuNgay.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            lblDenNgay.Location = new Point(232, 25);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(72, 22);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(307, 22);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(140, 27);
            dtpDenNgay.TabIndex = 3;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.BackColor = Color.SteelBlue;
            btnXemBaoCao.ForeColor = Color.White;
            btnXemBaoCao.Location = new Point(10, 55);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(120, 30);
            btnXemBaoCao.TabIndex = 4;
            btnXemBaoCao.Text = "📊 Doanh thu";
            btnXemBaoCao.UseVisualStyleBackColor = false;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // btnXemSapHet
            // 
            btnXemSapHet.BackColor = Color.DarkOrange;
            btnXemSapHet.ForeColor = Color.White;
            btnXemSapHet.Location = new Point(136, 55);
            btnXemSapHet.Name = "btnXemSapHet";
            btnXemSapHet.Size = new Size(110, 30);
            btnXemSapHet.TabIndex = 5;
            btnXemSapHet.Text = "⚠ Sắp hết";
            btnXemSapHet.UseVisualStyleBackColor = false;
            btnXemSapHet.Click += btnXemSapHet_Click;
            // 
            // btnBanChay
            // 
            btnBanChay.BackColor = Color.DarkViolet;
            btnBanChay.ForeColor = Color.White;
            btnBanChay.Location = new Point(252, 55);
            btnBanChay.Name = "btnBanChay";
            btnBanChay.Size = new Size(110, 30);
            btnBanChay.TabIndex = 6;
            btnBanChay.Text = "🏆 Bán chạy";
            btnBanChay.UseVisualStyleBackColor = false;
            btnBanChay.Click += btnBanChay_Click;
            // 
            // btnCaHomNay
            // 
            btnCaHomNay.BackColor = Color.Teal;
            btnCaHomNay.ForeColor = Color.White;
            btnCaHomNay.Location = new Point(368, 55);
            btnCaHomNay.Name = "btnCaHomNay";
            btnCaHomNay.Size = new Size(115, 30);
            btnCaHomNay.TabIndex = 7;
            btnCaHomNay.Text = "📅 Ca hôm nay";
            btnCaHomNay.UseVisualStyleBackColor = false;
            btnCaHomNay.Click += btnCaHomNay_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gray;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(489, 55);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(40, 30);
            btnLamMoi.TabIndex = 8;
            btnLamMoi.Text = "🔄";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // lblKetQua
            // 
            lblKetQua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKetQua.ForeColor = Color.DarkGreen;
            lblKetQua.Location = new Point(12, 267);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(1170, 24);
            lblKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblKetQua.TabIndex = 3;
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.ColumnHeadersHeight = 29;
            dgvBaoCao.Location = new Point(12, 295);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.Size = new Size(1170, 475);
            dgvBaoCao.TabIndex = 4;
            dgvBaoCao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // frmBaoCao
            // 
            ClientSize = new Size(1200, 800);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitle);
            Controls.Add(pnlKPI);
            Controls.Add(grpLoc);
            Controls.Add(lblKetQua);
            Controls.Add(dgvBaoCao);
            Name = "frmBaoCao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo Cáo & Thống Kê";
            Load += frmBaoCao_Load;
            pnlKPI.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard2.ResumeLayout(false);
            pnlCard3.ResumeLayout(false);
            pnlCard4.ResumeLayout(false);
            grpLoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle, lblTuNgay, lblDenNgay, lblKetQua;
        private System.Windows.Forms.Label lblCard1Title, lblDoanhThuHomNay;
        private System.Windows.Forms.Label lblCard2Title, lblTongDonHomNay;
        private System.Windows.Forms.Label lblCard3Title, lblTongKhachHang;
        private System.Windows.Forms.Label lblCard4Title, lblSanPhamSapHet;
        private System.Windows.Forms.Panel pnlKPI, pnlCard1, pnlCard2, pnlCard3, pnlCard4;
        private System.Windows.Forms.GroupBox grpLoc;
        private System.Windows.Forms.DateTimePicker dtpTuNgay, dtpDenNgay;
        private System.Windows.Forms.Button btnXemBaoCao, btnXemSapHet, btnBanChay, btnCaHomNay, btnLamMoi;
        private System.Windows.Forms.DataGridView dgvBaoCao;
    }
}
