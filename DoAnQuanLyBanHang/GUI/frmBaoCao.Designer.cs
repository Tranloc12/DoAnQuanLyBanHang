namespace DoAnQuanLyBanHang
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle          = new System.Windows.Forms.Label();
            // KPI Cards
            pnlKPI            = new System.Windows.Forms.Panel();
            pnlCard1          = new System.Windows.Forms.Panel();
            lblCard1Title     = new System.Windows.Forms.Label();
            lblDoanhThuHomNay = new System.Windows.Forms.Label();
            pnlCard2          = new System.Windows.Forms.Panel();
            lblCard2Title     = new System.Windows.Forms.Label();
            lblTongDonHomNay  = new System.Windows.Forms.Label();
            pnlCard3          = new System.Windows.Forms.Panel();
            lblCard3Title     = new System.Windows.Forms.Label();
            lblTongKhachHang  = new System.Windows.Forms.Label();
            pnlCard4          = new System.Windows.Forms.Panel();
            lblCard4Title     = new System.Windows.Forms.Label();
            lblSanPhamSapHet  = new System.Windows.Forms.Label();
            // Bộ lọc
            grpLoc            = new System.Windows.Forms.GroupBox();
            lblTuNgay         = new System.Windows.Forms.Label();
            dtpTuNgay         = new System.Windows.Forms.DateTimePicker();
            lblDenNgay        = new System.Windows.Forms.Label();
            dtpDenNgay        = new System.Windows.Forms.DateTimePicker();
            btnXemBaoCao      = new System.Windows.Forms.Button();
            btnXemSapHet      = new System.Windows.Forms.Button();
            btnBanChay        = new System.Windows.Forms.Button();
            btnCaHomNay       = new System.Windows.Forms.Button();
            btnLamMoi         = new System.Windows.Forms.Button();
            // Kết quả
            lblKetQua         = new System.Windows.Forms.Label();
            dgvBaoCao         = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            pnlKPI.SuspendLayout(); pnlCard1.SuspendLayout(); pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout(); pnlCard4.SuspendLayout(); grpLoc.SuspendLayout();
            SuspendLayout();

            // Title
            lblTitle.Text = "📊 BÁO CÁO & THỐNG KÊ"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 15, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.DarkGreen; lblTitle.Location = new System.Drawing.Point(12, 10); lblTitle.Size = new System.Drawing.Size(400, 32);

            // ── KPI Panel ──
            pnlKPI.Location = new System.Drawing.Point(12, 48); pnlKPI.Size = new System.Drawing.Size(960, 105); pnlKPI.BackColor = System.Drawing.Color.Transparent;

            void SetupCard(System.Windows.Forms.Panel p, System.Windows.Forms.Label title, System.Windows.Forms.Label val, int x, string t, System.Drawing.Color c)
            {
                p.Location = new System.Drawing.Point(x, 0); p.Size = new System.Drawing.Size(225, 95); p.BackColor = c; p.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                title.Text = t; title.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold); title.ForeColor = System.Drawing.Color.White; title.Location = new System.Drawing.Point(10, 12); title.Size = new System.Drawing.Size(200, 22);
                val.Text = "..."; val.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold); val.ForeColor = System.Drawing.Color.White; val.Location = new System.Drawing.Point(10, 45); val.Size = new System.Drawing.Size(200, 35);
                p.Controls.Add(title); p.Controls.Add(val);
            }
            SetupCard(pnlCard1, lblCard1Title, lblDoanhThuHomNay, 0,   "💰 Doanh thu hôm nay",    System.Drawing.Color.FromArgb(34, 139, 34));
            SetupCard(pnlCard2, lblCard2Title, lblTongDonHomNay,  240, "🛒 Đơn hàng hôm nay",     System.Drawing.Color.FromArgb(30, 144, 255));
            SetupCard(pnlCard3, lblCard3Title, lblTongKhachHang,  480, "👥 Tổng khách hàng",      System.Drawing.Color.FromArgb(255, 140, 0));
            SetupCard(pnlCard4, lblCard4Title, lblSanPhamSapHet,  720, "⚠ Sản phẩm sắp hết",     System.Drawing.Color.FromArgb(220, 53, 69));
            pnlKPI.Controls.AddRange(new System.Windows.Forms.Control[] { pnlCard1, pnlCard2, pnlCard3, pnlCard4 });

            // ── Bộ lọc ──
            grpLoc.Text = "Báo cáo & lọc"; grpLoc.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            grpLoc.Location = new System.Drawing.Point(12, 162); grpLoc.Size = new System.Drawing.Size(960, 60);
            lblTuNgay.Text = "Từ ngày:"; lblTuNgay.Location = new System.Drawing.Point(10, 25); lblTuNgay.Size = new System.Drawing.Size(68, 22);
            dtpTuNgay.Location = new System.Drawing.Point(80, 22); dtpTuNgay.Size = new System.Drawing.Size(140, 27); dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            lblDenNgay.Text = "Đến ngày:"; lblDenNgay.Location = new System.Drawing.Point(232, 25); lblDenNgay.Size = new System.Drawing.Size(72, 22);
            dtpDenNgay.Location = new System.Drawing.Point(307, 22); dtpDenNgay.Size = new System.Drawing.Size(140, 27); dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            btnXemBaoCao.Text = "📊 Doanh thu";  btnXemBaoCao.Location = new System.Drawing.Point(460, 20); btnXemBaoCao.Size = new System.Drawing.Size(120, 30); btnXemBaoCao.BackColor = System.Drawing.Color.SteelBlue;   btnXemBaoCao.ForeColor = System.Drawing.Color.White; btnXemBaoCao.Click += new System.EventHandler(btnXemBaoCao_Click);
            btnXemSapHet.Text  = "⚠ Sắp hết";    btnXemSapHet.Location  = new System.Drawing.Point(588, 20); btnXemSapHet.Size  = new System.Drawing.Size(110, 30); btnXemSapHet.BackColor  = System.Drawing.Color.DarkOrange; btnXemSapHet.ForeColor  = System.Drawing.Color.White; btnXemSapHet.Click  += new System.EventHandler(btnXemSapHet_Click);
            btnBanChay.Text    = "🏆 Bán chạy";   btnBanChay.Location    = new System.Drawing.Point(706, 20); btnBanChay.Size    = new System.Drawing.Size(110, 30); btnBanChay.BackColor    = System.Drawing.Color.DarkViolet;  btnBanChay.ForeColor    = System.Drawing.Color.White; btnBanChay.Click    += new System.EventHandler(btnBanChay_Click);
            btnCaHomNay.Text   = "📅 Ca hôm nay"; btnCaHomNay.Location   = new System.Drawing.Point(824, 20); btnCaHomNay.Size   = new System.Drawing.Size(115, 30); btnCaHomNay.BackColor   = System.Drawing.Color.Teal;        btnCaHomNay.ForeColor   = System.Drawing.Color.White; btnCaHomNay.Click   += new System.EventHandler(btnCaHomNay_Click);
            btnLamMoi.Text     = "🔄";    btnLamMoi.Location     = new System.Drawing.Point(920, 20); btnLamMoi.Size     = new System.Drawing.Size(40, 30);  btnLamMoi.BackColor     = System.Drawing.Color.Gray;        btnLamMoi.ForeColor     = System.Drawing.Color.White; btnLamMoi.Click     += new System.EventHandler(btnLamMoi_Click);
            grpLoc.Controls.AddRange(new System.Windows.Forms.Control[] { lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnXemBaoCao, btnXemSapHet, btnBanChay, btnCaHomNay, btnLamMoi });

            // ── Kết quả ──
            lblKetQua.Text = ""; lblKetQua.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold); lblKetQua.ForeColor = System.Drawing.Color.DarkGreen; lblKetQua.Location = new System.Drawing.Point(12, 232); lblKetQua.Size = new System.Drawing.Size(960, 24);
            dgvBaoCao.Location = new System.Drawing.Point(12, 260); dgvBaoCao.Size = new System.Drawing.Size(960, 350);
            dgvBaoCao.AllowUserToAddRows = false; dgvBaoCao.ReadOnly = true;
            dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            ClientSize = new System.Drawing.Size(990, 628); Text = "Báo Cáo & Thống Kê"; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += new System.EventHandler(frmBaoCao_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, pnlKPI, grpLoc, lblKetQua, dgvBaoCao });

            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            pnlKPI.ResumeLayout(false); pnlCard1.ResumeLayout(false); pnlCard2.ResumeLayout(false);
            pnlCard3.ResumeLayout(false); pnlCard4.ResumeLayout(false); grpLoc.ResumeLayout(false);
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
