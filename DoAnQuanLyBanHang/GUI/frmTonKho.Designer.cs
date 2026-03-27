namespace DoAnQuanLyBanHang
{
    partial class frmTonKho
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle    = new System.Windows.Forms.Label();
            // Legend
            pnlLegend   = new System.Windows.Forms.Panel();
            lblLegend1  = new System.Windows.Forms.Label();
            lblLegend2  = new System.Windows.Forms.Label();
            lblLegend3  = new System.Windows.Forms.Label();
            // Grid
            dgvTonKho   = new System.Windows.Forms.DataGridView();
            lblThongKe  = new System.Windows.Forms.Label();
            // Buttons
            pnlButtons  = new System.Windows.Forms.Panel();
            btnTatCa    = new System.Windows.Forms.Button();
            btnSapHet   = new System.Windows.Forms.Button();
            btnNhapKho  = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvTonKho).BeginInit();
            pnlLegend.SuspendLayout(); pnlButtons.SuspendLayout(); SuspendLayout();

            lblTitle.Text = "QUẢN LÝ TỒN KHO"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.DarkGreen; lblTitle.Location = new System.Drawing.Point(12, 10); lblTitle.Size = new System.Drawing.Size(350, 30);

            // Legend
            pnlLegend.Location = new System.Drawing.Point(12, 46); pnlLegend.Size = new System.Drawing.Size(750, 28); pnlLegend.BackColor = System.Drawing.Color.White;
            lblLegend1.Text = "  🟢 Còn hàng  "; lblLegend1.Location = new System.Drawing.Point(0, 5);   lblLegend1.Size = new System.Drawing.Size(120, 20); lblLegend1.BackColor = System.Drawing.Color.FromArgb(200, 240, 200);
            lblLegend2.Text = "  🟡 Sắp hết   "; lblLegend2.Location = new System.Drawing.Point(130, 5); lblLegend2.Size = new System.Drawing.Size(120, 20); lblLegend2.BackColor = System.Drawing.Color.FromArgb(255, 240, 180);
            lblLegend3.Text = "  🔴 Hết hàng  "; lblLegend3.Location = new System.Drawing.Point(260, 5); lblLegend3.Size = new System.Drawing.Size(120, 20); lblLegend3.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
            pnlLegend.Controls.AddRange(new System.Windows.Forms.Control[] { lblLegend1, lblLegend2, lblLegend3 });

            dgvTonKho.Location = new System.Drawing.Point(12, 80); dgvTonKho.Size = new System.Drawing.Size(850, 420);
            dgvTonKho.AllowUserToAddRows = false; dgvTonKho.ReadOnly = true;
            dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvTonKho.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(dgvTonKho_CellFormatting);

            lblThongKe.Text = ""; lblThongKe.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold); lblThongKe.Location = new System.Drawing.Point(12, 506); lblThongKe.Size = new System.Drawing.Size(400, 22);

            pnlButtons.Location = new System.Drawing.Point(12, 532); pnlButtons.Size = new System.Drawing.Size(850, 42);
            int bh = 34;
            btnTatCa.Text   = "📋 Tất cả";   btnTatCa.Location   = new System.Drawing.Point(0, 4);   btnTatCa.Size   = new System.Drawing.Size(115, bh); btnTatCa.BackColor   = System.Drawing.Color.SteelBlue;  btnTatCa.ForeColor   = System.Drawing.Color.White; btnTatCa.Click   += new System.EventHandler(btnTatCa_Click);
            btnSapHet.Text  = "⚠ Sắp hết";   btnSapHet.Location  = new System.Drawing.Point(123, 4); btnSapHet.Size  = new System.Drawing.Size(115, bh); btnSapHet.BackColor  = System.Drawing.Color.DarkOrange; btnSapHet.ForeColor  = System.Drawing.Color.White; btnSapHet.Click  += new System.EventHandler(btnSapHet_Click);
            btnNhapKho.Text = "📦 Nhập kho"; btnNhapKho.Location = new System.Drawing.Point(246, 4); btnNhapKho.Size = new System.Drawing.Size(130, bh); btnNhapKho.BackColor = System.Drawing.Color.SeaGreen;   btnNhapKho.ForeColor = System.Drawing.Color.White; btnNhapKho.Click += new System.EventHandler(btnNhapKho_Click);
            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnTatCa, btnSapHet, btnNhapKho });

            ClientSize = new System.Drawing.Size(882, 590); Text = "Quản Lý Tồn Kho"; StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += new System.EventHandler(frmTonKho_Load);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, pnlLegend, dgvTonKho, lblThongKe, pnlButtons });
            ((System.ComponentModel.ISupportInitialize)dgvTonKho).EndInit();
            pnlLegend.ResumeLayout(false); pnlButtons.ResumeLayout(false); ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitle, lblLegend1, lblLegend2, lblLegend3, lblThongKe;
        private System.Windows.Forms.Panel pnlLegend, pnlButtons;
        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.Button btnTatCa, btnSapHet, btnNhapKho;
    }
}
