namespace GUI_QuanLy
{
    partial class frmPaymentQR
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            picQR = new PictureBox();
            lblInfo = new Label();
            lblSubtitle = new Label();
            btnDong = new Button();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkSlateBlue;
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(376, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUÉT MÃ THANH TOÁN PAYPAL";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picQR
            // 
            picQR.BackColor = Color.White;
            picQR.BorderStyle = BorderStyle.FixedSingle;
            picQR.Location = new Point(50, 60);
            picQR.Name = "picQR";
            picQR.Size = new Size(300, 300);
            picQR.SizeMode = PictureBoxSizeMode.StretchImage;
            picQR.TabIndex = 1;
            picQR.TabStop = false;
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblInfo.Location = new Point(12, 375);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(376, 50);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "Đơn hàng: ...\nSố tiền: ...";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(12, 435);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(376, 23);
            lblSubtitle.TabIndex = 3;
            lblSubtitle.Text = "Mở app PayPal và quét mã QR để thanh toán";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDong
            // 
            btnDong.BackColor = Color.SteelBlue;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(140, 475);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(120, 40);
            btnDong.TabIndex = 4;
            btnDong.Text = "ĐÓNG";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // frmPaymentQR
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(400, 535);
            Controls.Add(lblTitle);
            Controls.Add(picQR);
            Controls.Add(lblInfo);
            Controls.Add(lblSubtitle);
            Controls.Add(btnDong);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPaymentQR";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thanh toán PayPal QR";
            Load += frmPaymentQR_Load;
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnDong;
    }
}
