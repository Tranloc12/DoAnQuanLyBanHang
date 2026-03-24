namespace DoAnQuanLyBanHang
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            panel1 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(246, 374);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên Đăng Nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 438);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 1;
            label2.Text = "Mật Khẩu";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(377, 374);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 2;
            txtUsername.TextChanged += textBox1_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(377, 431);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(364, 493);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Location = new Point(4, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 73);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // label3
            // 
            label3.BackColor = Color.ForestGreen;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.CausesValidation = false;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FloralWhite;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(800, 73);
            label3.TabIndex = 0;
            label3.Text = "HỆ THỐNG QUẢN LÝ BÁN HÀNG CHO CỬA HÀNG TIỆN LỢI ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-41, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 352);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 532);
            Controls.Add(panel1);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "frmLogin";
            Text = "frmLogin";
            Load += frmLogin_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox1;
    }
}