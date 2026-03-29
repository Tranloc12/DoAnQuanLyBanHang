namespace DoAnQuanLyBanHang
{
    partial class frmTonKho
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlLegend = new Panel();
            lblLegend1 = new Label();
            lblLegend2 = new Label();
            lblLegend3 = new Label();
            dgvTonKho = new DataGridView();
            lblThongKe = new Label();
            pnlButtons = new Panel();
            btnTatCa = new Button();
            btnSapHet = new Button();
            btnNhapKho = new Button();
            btnExcel = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            pnlLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTonKho).BeginInit();
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
            lblTitle.Text = "QUẢN LÝ TỒN KHO";
            // 
            // pnlLegend
            // 
            pnlLegend.BackColor = Color.White;
            pnlLegend.Controls.Add(lblLegend1);
            pnlLegend.Controls.Add(lblLegend2);
            pnlLegend.Controls.Add(lblLegend3);
            pnlLegend.Location = new Point(12, 46);
            pnlLegend.Name = "pnlLegend";
            pnlLegend.Size = new Size(750, 28);
            pnlLegend.TabIndex = 1;
            // 
            // lblLegend1
            // 
            lblLegend1.BackColor = Color.FromArgb(200, 240, 200);
            lblLegend1.Location = new Point(0, 5);
            lblLegend1.Name = "lblLegend1";
            lblLegend1.Size = new Size(120, 20);
            lblLegend1.TabIndex = 0;
            lblLegend1.Text = "  \U0001f7e2 Còn hàng  ";
            // 
            // lblLegend2
            // 
            lblLegend2.BackColor = Color.FromArgb(255, 240, 180);
            lblLegend2.Location = new Point(130, 5);
            lblLegend2.Name = "lblLegend2";
            lblLegend2.Size = new Size(120, 20);
            lblLegend2.TabIndex = 1;
            lblLegend2.Text = "  \U0001f7e1 Sắp hết   ";
            // 
            // lblLegend3
            // 
            lblLegend3.BackColor = Color.FromArgb(255, 200, 200);
            lblLegend3.Location = new Point(260, 5);
            lblLegend3.Name = "lblLegend3";
            lblLegend3.Size = new Size(120, 20);
            lblLegend3.TabIndex = 2;
            lblLegend3.Text = "  🔴 Hết hàng  ";
            // 
            // dgvTonKho
            // 
            dgvTonKho.AllowUserToAddRows = false;
            dgvTonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTonKho.ColumnHeadersHeight = 29;
            dgvTonKho.Location = new Point(12, 80);
            dgvTonKho.Name = "dgvTonKho";
            dgvTonKho.ReadOnly = true;
            dgvTonKho.RowHeadersWidth = 51;
            dgvTonKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTonKho.Size = new Size(850, 420);
            dgvTonKho.TabIndex = 2;
            dgvTonKho.CellFormatting += dgvTonKho_CellFormatting;
            // 
            // lblThongKe
            // 
            lblThongKe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblThongKe.Location = new Point(12, 506);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new Size(400, 22);
            lblThongKe.TabIndex = 3;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnTatCa);
            pnlButtons.Controls.Add(btnSapHet);
            pnlButtons.Controls.Add(btnNhapKho);
            pnlButtons.Controls.Add(btnExcel);
            pnlButtons.Location = new Point(12, 532);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(850, 42);
            pnlButtons.TabIndex = 4;
            // 
            // btnTatCa
            // 
            btnTatCa.BackColor = Color.SteelBlue;
            btnTatCa.ForeColor = Color.White;
            btnTatCa.Location = new Point(0, 4);
            btnTatCa.Name = "btnTatCa";
            btnTatCa.Size = new Size(115, 34);
            btnTatCa.TabIndex = 0;
            btnTatCa.Text = "📋 Tất cả";
            btnTatCa.UseVisualStyleBackColor = false;
            btnTatCa.Click += btnTatCa_Click;
            // 
            // btnSapHet
            // 
            btnSapHet.BackColor = Color.DarkOrange;
            btnSapHet.ForeColor = Color.White;
            btnSapHet.Location = new Point(123, 4);
            btnSapHet.Name = "btnSapHet";
            btnSapHet.Size = new Size(115, 34);
            btnSapHet.TabIndex = 1;
            btnSapHet.Text = "⚠ Sắp hết";
            btnSapHet.UseVisualStyleBackColor = false;
            btnSapHet.Click += btnSapHet_Click;
            // 
            // btnNhapKho
            // 
            btnNhapKho.BackColor = Color.SeaGreen;
            btnNhapKho.ForeColor = Color.White;
            btnNhapKho.Location = new Point(246, 4);
            btnNhapKho.Name = "btnNhapKho";
            btnNhapKho.Size = new Size(130, 34);
            btnNhapKho.TabIndex = 2;
            btnNhapKho.Text = "📦 Nhập kho";
            btnNhapKho.UseVisualStyleBackColor = false;
            btnNhapKho.Click += btnNhapKho_Click;
            // 
            // btnExcel
            // 
            btnExcel.BackColor = Color.FromArgb(33, 115, 70);
            btnExcel.ForeColor = Color.White;
            btnExcel.Location = new Point(385, 4);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(120, 34);
            btnExcel.TabIndex = 3;
            btnExcel.Text = "📊 Xuất Excel";
            btnExcel.UseVisualStyleBackColor = false;
            btnExcel.Click += btnExcel_Click;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(450, 16);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(98, 20);
            lblTimKiem.TabIndex = 5;
            lblTimKiem.Text = "🔍 Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(552, 14);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(200, 27);
            txtTimKiem.TabIndex = 6;
            txtTimKiem.KeyUp += txtTimKiem_KeyUp;
            // 
            // frmTonKho
            // 
            ClientSize = new Size(882, 590);
            Controls.Add(lblTitle);
            Controls.Add(pnlLegend);
            Controls.Add(dgvTonKho);
            Controls.Add(lblThongKe);
            Controls.Add(pnlButtons);
            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Name = "frmTonKho";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Tồn Kho";
            Load += frmTonKho_Load;
            pnlLegend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTonKho).EndInit();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label lblTitle, lblLegend1, lblLegend2, lblLegend3, lblThongKe, lblTimKiem;
        private System.Windows.Forms.Panel pnlLegend, pnlButtons;
        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.Button btnTatCa, btnSapHet, btnNhapKho, btnExcel;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}
