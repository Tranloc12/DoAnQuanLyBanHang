namespace DoAnQuanLyBanHang
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            pnSidebar = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnReport = new Button();
            btnInventory = new Button();
            btnUser = new Button();
            btnCustomer = new Button();
            btnCategory = new Button();
            btnProduct = new Button();
            btnSales = new Button();
            btnDashboard = new Button();
            pnTop = new Panel();
            lblAdminName = new Label();
            btnLogout = new Button();
            lblWelcome = new Label();
            btnSearch = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            pnContent = new Panel();
            pnRevenue = new Panel();
            lblTodayRevenue = new Label();
            lblRevTitle = new Label();
            pnAlertStock = new Panel();
            lblLowStockCount = new Label();
            lblAlertTitle = new Label();
            lblDashboardTitle = new Label();
            stsMain = new StatusStrip();
            tssUser = new ToolStripStatusLabel();
            tssRole = new ToolStripStatusLabel();
            tssClock = new ToolStripStatusLabel();
            pnSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnTop.SuspendLayout();
            pnContent.SuspendLayout();
            pnRevenue.SuspendLayout();
            pnAlertStock.SuspendLayout();
            stsMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnSidebar
            // 
            pnSidebar.BackColor = Color.DarkGreen;
            pnSidebar.Controls.Add(pictureBox1);
            pnSidebar.Controls.Add(label1);
            pnSidebar.Controls.Add(btnReport);
            pnSidebar.Controls.Add(btnInventory);
            pnSidebar.Controls.Add(btnUser);
            pnSidebar.Controls.Add(btnCustomer);
            pnSidebar.Controls.Add(btnCategory);
            pnSidebar.Controls.Add(btnProduct);
            pnSidebar.Controls.Add(btnSales);
            pnSidebar.Controls.Add(btnDashboard);
            pnSidebar.Dock = DockStyle.Left;
            pnSidebar.Location = new Point(0, 0);
            pnSidebar.Name = "pnSidebar";
            pnSidebar.Size = new Size(157, 450);
            pnSidebar.TabIndex = 0;
            pnSidebar.DockChanged += panel1_DockChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(190, 12);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 9;
            label1.Text = "label1";
            // 
            // btnReport
            // 
            btnReport.Location = new Point(32, 280);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(94, 29);
            btnReport.TabIndex = 8;
            btnReport.Text = "BÁO CÁO";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnInventory
            // 
            btnInventory.Location = new Point(32, 245);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(94, 29);
            btnInventory.TabIndex = 7;
            btnInventory.Text = "KHO HÀNG";
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += button7_Click;
            // 
            // btnUser
            // 
            btnUser.Location = new Point(17, 327);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(130, 29);
            btnUser.TabIndex = 6;
            btnUser.Text = "NHÂN VIÊN";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Location = new Point(12, 210);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(125, 29);
            btnCustomer.TabIndex = 5;
            btnCustomer.Text = "KHÁCH HÀNG";
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnCategory
            // 
            btnCategory.Location = new Point(32, 181);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(94, 29);
            btnCategory.TabIndex = 4;
            btnCategory.Text = "LOẠI HÀNG";
            btnCategory.UseVisualStyleBackColor = true;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnProduct
            // 
            btnProduct.Location = new Point(32, 152);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(94, 29);
            btnProduct.TabIndex = 3;
            btnProduct.Text = "SẢN PHẨM";
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnSales
            // 
            btnSales.Location = new Point(32, 123);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(94, 29);
            btnSales.TabIndex = 2;
            btnSales.Text = "BÁN HÀNG (POS)";
            btnSales.TextAlign = ContentAlignment.BottomLeft;
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Location = new Point(12, 88);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(135, 29);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "TRANG CHỦ";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnTop
            // 
            pnTop.BackColor = Color.DarkGreen;
            pnTop.Controls.Add(lblAdminName);
            pnTop.Controls.Add(btnLogout);
            pnTop.Controls.Add(lblWelcome);
            pnTop.Controls.Add(btnSearch);
            pnTop.Controls.Add(lblSearch);
            pnTop.Controls.Add(txtSearch);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(157, 0);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(643, 45);
            pnTop.TabIndex = 1;
            // 
            // lblAdminName
            // 
            lblAdminName.AutoSize = true;
            lblAdminName.BackColor = Color.Ivory;
            lblAdminName.Location = new Point(477, 15);
            lblAdminName.Name = "lblAdminName";
            lblAdminName.Size = new Size(12, 20);
            lblAdminName.TabIndex = 8;
            lblAdminName.Text = ",";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(549, 9);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 12;
            btnLogout.Text = "Thoát";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.Ivory;
            lblWelcome.Location = new Point(428, 15);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(43, 20);
            lblWelcome.TabIndex = 7;
            lblWelcome.Text = "Chào";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(270, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "TÌM";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BackColor = SystemColors.ButtonFace;
            lblSearch.Location = new Point(33, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(79, 20);
            lblSearch.TabIndex = 10;
            lblSearch.Text = "Mã SP/Tên";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(128, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 10;
            // 
            // pnContent
            // 
            pnContent.Controls.Add(pnRevenue);
            pnContent.Controls.Add(pnAlertStock);
            pnContent.Controls.Add(lblDashboardTitle);
            pnContent.Controls.Add(stsMain);
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(157, 45);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(643, 405);
            pnContent.TabIndex = 2;
            // 
            // pnRevenue
            // 
            pnRevenue.Controls.Add(lblTodayRevenue);
            pnRevenue.Controls.Add(lblRevTitle);
            pnRevenue.Location = new Point(325, 78);
            pnRevenue.Name = "pnRevenue";
            pnRevenue.Size = new Size(228, 80);
            pnRevenue.TabIndex = 9;
            // 
            // lblTodayRevenue
            // 
            lblTodayRevenue.AutoSize = true;
            lblTodayRevenue.Location = new Point(161, 33);
            lblTodayRevenue.Name = "lblTodayRevenue";
            lblTodayRevenue.Size = new Size(49, 20);
            lblTodayRevenue.TabIndex = 1;
            lblTodayRevenue.Text = "15000";
            // 
            // lblRevTitle
            // 
            lblRevTitle.AutoSize = true;
            lblRevTitle.Location = new Point(19, 33);
            lblRevTitle.Name = "lblRevTitle";
            lblRevTitle.Size = new Size(114, 20);
            lblRevTitle.TabIndex = 0;
            lblRevTitle.Text = "Doanh thu ngày";
            // 
            // pnAlertStock
            // 
            pnAlertStock.Controls.Add(lblLowStockCount);
            pnAlertStock.Controls.Add(lblAlertTitle);
            pnAlertStock.Location = new Point(33, 78);
            pnAlertStock.Name = "pnAlertStock";
            pnAlertStock.Size = new Size(228, 80);
            pnAlertStock.TabIndex = 8;
            // 
            // lblLowStockCount
            // 
            lblLowStockCount.AutoSize = true;
            lblLowStockCount.Location = new Point(161, 33);
            lblLowStockCount.Name = "lblLowStockCount";
            lblLowStockCount.Size = new Size(33, 20);
            lblLowStockCount.TabIndex = 1;
            lblLowStockCount.Text = "5SP";
            lblLowStockCount.Click += lblLowStockCount_Click;
            // 
            // lblAlertTitle
            // 
            lblAlertTitle.AutoSize = true;
            lblAlertTitle.Location = new Point(3, 29);
            lblAlertTitle.Name = "lblAlertTitle";
            lblAlertTitle.Size = new Size(127, 20);
            lblAlertTitle.TabIndex = 0;
            lblAlertTitle.Text = "Sản phẩm sắp hết";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Location = new Point(215, 29);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(172, 20);
            lblDashboardTitle.TabIndex = 7;
            lblDashboardTitle.Text = "WELCOME DASHBOARD";
            // 
            // stsMain
            // 
            stsMain.BackColor = Color.LightSteelBlue;
            stsMain.ImageScalingSize = new Size(20, 20);
            stsMain.Items.AddRange(new ToolStripItem[] { tssUser, tssRole, tssClock });
            stsMain.Location = new Point(0, 379);
            stsMain.Name = "stsMain";
            stsMain.Size = new Size(643, 26);
            stsMain.TabIndex = 0;
            stsMain.Text = "statusStrip1";
            stsMain.ItemClicked += stsMain_ItemClicked;
            // 
            // tssUser
            // 
            tssUser.Name = "tssUser";
            tssUser.Size = new Size(170, 20);
            tssUser.Text = "Nhân viên: Quan Tri Vien";
            // 
            // tssRole
            // 
            tssRole.Name = "tssRole";
            tssRole.Size = new Size(102, 20);
            tssRole.Text = "Quyền: Admin";
            // 
            // tssClock
            // 
            tssClock.Name = "tssClock";
            tssClock.Size = new Size(74, 20);
            tssClock.Text = "Giờ: 15:30";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnContent);
            Controls.Add(pnTop);
            Controls.Add(pnSidebar);
            Name = "FormMain";
            Text = "FormMain";
            pnSidebar.ResumeLayout(false);
            pnSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnContent.ResumeLayout(false);
            pnContent.PerformLayout();
            pnRevenue.ResumeLayout(false);
            pnRevenue.PerformLayout();
            pnAlertStock.ResumeLayout(false);
            pnAlertStock.PerformLayout();
            stsMain.ResumeLayout(false);
            stsMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnSidebar;
        private Panel pnTop;
        private Panel pnContent;
        private StatusStrip stsMain;
        private Button btnReport;
        private Button btnInventory;
        private Button btnUser;
        private Button btnCustomer;
        private Button btnCategory;
        private Button btnProduct;
        private Button btnSales;
        private Button btnDashboard;
        private Label lblSearch;
        private Label label1;
        private PictureBox pictureBox1;
        private Label lblAdminName;
        private Button btnLogout;
        private Label lblWelcome;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblDashboardTitle;
        private Panel pnRevenue;
        private Label lblTodayRevenue;
        private Label lblRevTitle;
        private Panel pnAlertStock;
        private Label lblLowStockCount;
        private Label lblAlertTitle;
        private ToolStripStatusLabel tssUser;
        private ToolStripStatusLabel tssRole;
        private ToolStripStatusLabel tssClock;
    }
}