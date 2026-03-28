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
            btnSupplier = new Button();
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
            pnlKPIContainer = new Panel();
            pnlCardRevenue = new Panel();
            lblCardRevVal = new Label();
            lblCardRevTitle = new Label();
            pnlCardOrders = new Panel();
            lblCardOrdersVal = new Label();
            lblCardOrdersTitle = new Label();
            pnlCardCustomers = new Panel();
            lblCardCustVal = new Label();
            lblCardCustTitle = new Label();
            pnlCardStock = new Panel();
            lblCardStockVal = new Label();
            lblCardStockTitle = new Label();
            pnlChartContainer = new Panel();
            lblChartTitle = new Label();
            crtRevenue = new LiveCharts.WinForms.CartesianChart();
            pnSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnTop.SuspendLayout();
            pnContent.SuspendLayout();
            pnlKPIContainer.SuspendLayout();
            pnlCardRevenue.SuspendLayout();
            pnlCardOrders.SuspendLayout();
            pnlCardCustomers.SuspendLayout();
            pnlCardStock.SuspendLayout();
            pnlChartContainer.SuspendLayout();
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
            pnSidebar.Controls.Add(btnSupplier);
            pnSidebar.Controls.Add(btnDashboard);
            pnSidebar.Dock = DockStyle.Left;
            pnSidebar.Location = new Point(0, 0);
            pnSidebar.Name = "pnSidebar";
            pnSidebar.Size = new Size(157, 450);
            pnSidebar.TabIndex = 0;

            // 
            // btnSupplier
            // 
            btnSupplier.Location = new Point(17, 360);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(130, 29);
            btnSupplier.TabIndex = 13;
            btnSupplier.Text = "NHÀ CUNG CẤP";
            btnSupplier.UseVisualStyleBackColor = true;
            btnSupplier.Click += btnSupplier_Click;

            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;

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
            btnInventory.Click += btnInventory_Click;

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
            btnSearch.Click += btnSearch_Click;
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
            pnContent.BackColor = Color.FromArgb(244, 246, 249);
            pnContent.Controls.Add(pnlChartContainer);
            pnContent.Controls.Add(pnlKPIContainer);
            pnContent.Controls.Add(lblDashboardTitle);
            pnContent.Controls.Add(stsMain);
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(157, 45);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(643, 405);
            pnContent.TabIndex = 2;
            // 
            // pnlKPIContainer
            // 
            pnlKPIContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlKPIContainer.Controls.Add(pnlCardStock);
            pnlKPIContainer.Controls.Add(pnlCardCustomers);
            pnlKPIContainer.Controls.Add(pnlCardOrders);
            pnlKPIContainer.Controls.Add(pnlCardRevenue);
            pnlKPIContainer.Location = new Point(20, 65);
            pnlKPIContainer.Name = "pnlKPIContainer";
            pnlKPIContainer.Size = new Size(600, 100);
            pnlKPIContainer.TabIndex = 8;
            // 
            // pnlCardRevenue
            // 
            pnlCardRevenue.BackColor = Color.White;
            pnlCardRevenue.BorderStyle = BorderStyle.FixedSingle;
            pnlCardRevenue.Controls.Add(lblCardRevVal);
            pnlCardRevenue.Controls.Add(lblCardRevTitle);
            pnlCardRevenue.Location = new Point(0, 0);
            pnlCardRevenue.Name = "pnlCardRevenue";
            pnlCardRevenue.Size = new Size(140, 90);
            pnlCardRevenue.TabIndex = 0;
            // 
            // lblCardRevVal
            // 
            lblCardRevVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCardRevVal.ForeColor = Color.SeaGreen;
            lblCardRevVal.Location = new Point(5, 40);
            lblCardRevVal.Name = "lblCardRevVal";
            lblCardRevVal.Size = new Size(130, 30);
            lblCardRevVal.TabIndex = 1;
            lblCardRevVal.Text = "0";
            lblCardRevVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCardRevTitle
            // 
            lblCardRevTitle.AutoSize = true;
            lblCardRevTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCardRevTitle.ForeColor = Color.Gray;
            lblCardRevTitle.Location = new Point(10, 10);
            lblCardRevTitle.Name = "lblCardRevTitle";
            lblCardRevTitle.Size = new Size(92, 19);
            lblCardRevTitle.TabIndex = 0;
            lblCardRevTitle.Text = "DOANH THU";
            // 
            // pnlCardOrders
            // 
            pnlCardOrders.BackColor = Color.White;
            pnlCardOrders.BorderStyle = BorderStyle.FixedSingle;
            pnlCardOrders.Controls.Add(lblCardOrdersVal);
            pnlCardOrders.Controls.Add(lblCardOrdersTitle);
            pnlCardOrders.Location = new Point(155, 0);
            pnlCardOrders.Name = "pnlCardOrders";
            pnlCardOrders.Size = new Size(140, 90);
            pnlCardOrders.TabIndex = 1;
            // 
            // lblCardOrdersVal
            // 
            lblCardOrdersVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCardOrdersVal.ForeColor = Color.RoyalBlue;
            lblCardOrdersVal.Location = new Point(5, 40);
            lblCardOrdersVal.Name = "lblCardOrdersVal";
            lblCardOrdersVal.Size = new Size(130, 30);
            lblCardOrdersVal.TabIndex = 1;
            lblCardOrdersVal.Text = "0";
            lblCardOrdersVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCardOrdersTitle
            // 
            lblCardOrdersTitle.AutoSize = true;
            lblCardOrdersTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCardOrdersTitle.ForeColor = Color.Gray;
            lblCardOrdersTitle.Location = new Point(10, 10);
            lblCardOrdersTitle.Name = "lblCardOrdersTitle";
            lblCardOrdersTitle.Size = new Size(84, 19);
            lblCardOrdersTitle.TabIndex = 0;
            lblCardOrdersTitle.Text = "ĐƠN HÀNG";
            // 
            // pnlCardCustomers
            // 
            pnlCardCustomers.BackColor = Color.White;
            pnlCardCustomers.BorderStyle = BorderStyle.FixedSingle;
            pnlCardCustomers.Controls.Add(lblCardCustVal);
            pnlCardCustomers.Controls.Add(lblCardCustTitle);
            pnlCardCustomers.Location = new Point(310, 0);
            pnlCardCustomers.Name = "pnlCardCustomers";
            pnlCardCustomers.Size = new Size(140, 90);
            pnlCardCustomers.TabIndex = 2;
            // 
            // lblCardCustVal
            // 
            lblCardCustVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCardCustVal.ForeColor = Color.DarkOrange;
            lblCardCustVal.Location = new Point(5, 40);
            lblCardCustVal.Name = "lblCardCustVal";
            lblCardCustVal.Size = new Size(130, 30);
            lblCardCustVal.TabIndex = 1;
            lblCardCustVal.Text = "0";
            lblCardCustVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCardCustTitle
            // 
            lblCardCustTitle.AutoSize = true;
            lblCardCustTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCardCustTitle.ForeColor = Color.Gray;
            lblCardCustTitle.Location = new Point(10, 10);
            lblCardCustTitle.Name = "lblCardCustTitle";
            lblCardCustTitle.Size = new Size(103, 19);
            lblCardCustTitle.TabIndex = 0;
            lblCardCustTitle.Text = "KHÁCH HÀNG";
            // 
            // pnlCardStock
            // 
            pnlCardStock.BackColor = Color.White;
            pnlCardStock.BorderStyle = BorderStyle.FixedSingle;
            pnlCardStock.Controls.Add(lblCardStockVal);
            pnlCardStock.Controls.Add(lblCardStockTitle);
            pnlCardStock.Location = new Point(465, 0);
            pnlCardStock.Name = "pnlCardStock";
            pnlCardStock.Size = new Size(140, 90);
            pnlCardStock.TabIndex = 3;
            // 
            // lblCardStockVal
            // 
            lblCardStockVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCardStockVal.ForeColor = Color.Crimson;
            lblCardStockVal.Location = new Point(5, 40);
            lblCardStockVal.Name = "lblCardStockVal";
            lblCardStockVal.Size = new Size(130, 30);
            lblCardStockVal.TabIndex = 1;
            lblCardStockVal.Text = "0";
            lblCardStockVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCardStockTitle
            // 
            lblCardStockTitle.AutoSize = true;
            lblCardStockTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCardStockTitle.ForeColor = Color.Gray;
            lblCardStockTitle.Location = new Point(10, 10);
            lblCardStockTitle.Name = "lblCardStockTitle";
            lblCardStockTitle.Size = new Size(71, 19);
            lblCardStockTitle.TabIndex = 0;
            lblCardStockTitle.Text = "SẮP HẾT";
            // 
            // pnlChartContainer
            // 
            pnlChartContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlChartContainer.BackColor = Color.White;
            pnlChartContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlChartContainer.Controls.Add(crtRevenue);
            pnlChartContainer.Controls.Add(lblChartTitle);
            pnlChartContainer.Location = new Point(20, 180);
            pnlChartContainer.Name = "pnlChartContainer";
            pnlChartContainer.Size = new Size(600, 180);
            pnlChartContainer.TabIndex = 10;
            // 
            // crtRevenue
            // 
            crtRevenue.Dock = DockStyle.Fill;
            crtRevenue.Location = new Point(0, 40);
            crtRevenue.Name = "crtRevenue";
            crtRevenue.Size = new Size(600, 140);
            crtRevenue.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChartTitle.Location = new Point(15, 10);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(224, 23);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "Doanh thu 7 ngày gần nhất";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDashboardTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblDashboardTitle.Location = new Point(20, 20);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(295, 32);
            lblDashboardTitle.TabIndex = 7;
            lblDashboardTitle.Text = "TỔNG QUAN HỆ THỐNG";
            // 
            // stsMain
            // 
            stsMain.BackColor = Color.FromArgb(233, 236, 239);
            stsMain.ImageScalingSize = new Size(20, 20);
            stsMain.Items.AddRange(new ToolStripItem[] { tssUser, tssRole, tssClock });
            stsMain.Location = new Point(0, 379);
            stsMain.Name = "stsMain";
            stsMain.Size = new Size(643, 26);
            stsMain.TabIndex = 0;
            stsMain.Text = "statusStrip1";

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
            Text = "Hệ Thống Quản Lý Bán Hàng Presitge";
            Load += FormMain_Load;
            pnSidebar.ResumeLayout(false);
            pnSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnContent.ResumeLayout(false);
            pnContent.PerformLayout();
            pnlKPIContainer.ResumeLayout(false);
            pnlCardRevenue.ResumeLayout(false);
            pnlCardRevenue.PerformLayout();
            pnlCardOrders.ResumeLayout(false);
            pnlCardOrders.PerformLayout();
            pnlCardCustomers.ResumeLayout(false);
            pnlCardCustomers.PerformLayout();
            pnlCardStock.ResumeLayout(false);
            pnlCardStock.PerformLayout();
            pnlChartContainer.ResumeLayout(false);
            pnlChartContainer.PerformLayout();
            stsMain.ResumeLayout(false);
            stsMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnSidebar;
        private Panel pnTop;
        private Label lblDashboardTitle;
        private Panel pnlKPIContainer;
        private Panel pnlCardRevenue;
        private Label lblCardRevVal;
        private Label lblCardRevTitle;
        private Panel pnlCardOrders;
        private Label lblCardOrdersVal;
        private Label lblCardOrdersTitle;
        private Panel pnlCardCustomers;
        private Label lblCardCustVal;
        private Label lblCardCustTitle;
        private Panel pnlCardStock;
        private Label lblCardStockVal;
        private Label lblCardStockTitle;
        private Panel pnlChartContainer;
        private Label lblChartTitle;
        private ToolStripStatusLabel tssUser;
        private ToolStripStatusLabel tssRole;
        private ToolStripStatusLabel tssClock;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnReport;
        private Button btnInventory;
        private Button btnUser;
        private Button btnCustomer;
        private Button btnCategory;
        private Button btnProduct;
        private Button btnSales;
        private Button btnDashboard;
        private Button btnSupplier;
        private Label lblAdminName;
        private Button btnLogout;
        private Label lblWelcome;
        private Button btnSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Panel pnContent;
        private Panel pnRevenue;
        private Label lblTodayRevenue;
        private Label lblRevTitle;
        private Panel pnAlertStock;
        private Label lblLowStockCount;
        private Label lblAlertTitle;
        private StatusStrip stsMain;
        private LiveCharts.WinForms.CartesianChart crtRevenue;
    }
}
