namespace GUI_QuanLy
{
    partial class frmNhaCungCap
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblTitle = new Label();
            dgvNCC = new DataGridView();
            grpThongTin = new GroupBox();
            lblTen = new Label();
            txtTen = new TextBox();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            pnlButtons = new Panel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNCC).BeginInit();
            grpThongTin.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(380, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            // 
            // dgvNCC
            // 
            dgvNCC.AllowUserToAddRows = false;
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNCC.ColumnHeadersHeight = 29;
            dgvNCC.Location = new Point(12, 48);
            dgvNCC.Name = "dgvNCC";
            dgvNCC.ReadOnly = true;
            dgvNCC.RowHeadersWidth = 51;
            dgvNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNCC.Size = new Size(660, 270);
            dgvNCC.TabIndex = 1;
            dgvNCC.RowEnter += dgvNCC_RowEnter;
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblTen);
            grpThongTin.Controls.Add(txtTen);
            grpThongTin.Controls.Add(lblSDT);
            grpThongTin.Controls.Add(txtSDT);
            grpThongTin.Controls.Add(lblDiaChi);
            grpThongTin.Controls.Add(txtDiaChi);
            grpThongTin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpThongTin.Location = new Point(12, 330);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(660, 120);
            grpThongTin.TabIndex = 2;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin nhà cung cấp";
            // 
            // lblTen
            // 
            lblTen.Location = new Point(15, 30);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(80, 22);
            lblTen.TabIndex = 0;
            lblTen.Text = "Tên NCC:";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(100, 30);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(200, 27);
            txtTen.TabIndex = 1;
            txtTen.TextChanged += txtTen_TextChanged;
            // 
            // lblSDT
            // 
            lblSDT.Location = new Point(328, 30);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(111, 22);
            lblSDT.TabIndex = 2;
            lblSDT.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(440, 27);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(190, 27);
            txtSDT.TabIndex = 3;
            // 
            // lblDiaChi
            // 
            lblDiaChi.Location = new Point(15, 70);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(80, 22);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(100, 70);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(510, 27);
            txtDiaChi.TabIndex = 5;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnSua);
            pnlButtons.Controls.Add(btnXoa);
            pnlButtons.Controls.Add(btnLuu);
            pnlButtons.Controls.Add(btnHuy);
            pnlButtons.Location = new Point(12, 460);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(660, 42);
            pnlButtons.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.SeaGreen;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(0, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 34);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.SteelBlue;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(108, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 34);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Crimson;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(216, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 34);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑 Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.DarkOrange;
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(324, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 34);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Gray;
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(432, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 34);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "✖ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // frmNhaCungCap
            // 
            ClientSize = new Size(692, 520);
            Controls.Add(lblTitle);
            Controls.Add(dgvNCC);
            Controls.Add(grpThongTin);
            Controls.Add(pnlButtons);
            Name = "frmNhaCungCap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Nhà Cung Cấp";
            Load += frmNhaCungCap_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNCC).EndInit();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitle, lblTen, lblSDT, lblDiaChi;
        private System.Windows.Forms.TextBox txtTen, txtSDT, txtDiaChi;
        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnLuu, btnHuy;
    }
}
