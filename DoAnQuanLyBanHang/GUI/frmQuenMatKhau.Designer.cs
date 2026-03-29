namespace DoAnQuanLyBanHang
{
    partial class frmQuenMatKhau
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnLayLaiMatKhau = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(30, 50);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(220, 23);
            this.txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(30, 110);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 23);
            this.txtEmail.TabIndex = 3;
            // 
            // btnLayLaiMatKhau
            // 
            this.btnLayLaiMatKhau.Location = new System.Drawing.Point(30, 150);
            this.btnLayLaiMatKhau.Name = "btnLayLaiMatKhau";
            this.btnLayLaiMatKhau.Size = new System.Drawing.Size(120, 30);
            this.btnLayLaiMatKhau.TabIndex = 4;
            this.btnLayLaiMatKhau.Text = "Lấy lại mật khẩu";
            this.btnLayLaiMatKhau.UseVisualStyleBackColor = true;
            this.btnLayLaiMatKhau.Click += new System.EventHandler(this.btnLayLaiMatKhau_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(160, 150);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 30);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.ForeColor = System.Drawing.Color.Blue;
            this.lblKetQua.Location = new System.Drawing.Point(30, 195);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(50, 15);
            this.lblKetQua.TabIndex = 6;
            this.lblKetQua.Text = "Kết quả:";
            // 
            // frmQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 231);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLayLaiMatKhau);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmQuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnLayLaiMatKhau;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblKetQua;
    }
}
