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
            btnSupplier = new Button();
            btnDashboard = new Button();
            pnTop = new Panel();
            cboFilter = new ComboBox();
            btnLogout = new Button();
            btnSearch = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            pnContent = new Panel();
            pnlDashboardHome = new Panel();

            pnlChartContainer = new Panel();
            crtRevenue = new LiveCharts.WinForms.CartesianChart();
            lblChartTitle = new Label();
            pnlKPIContainer = new Panel();
            pnlCardStock = new Panel();
            lblCardStockVal = new Label();
            lblCardStockTitle = new Label();
            pnlCardCustomers = new Panel();
            lblCardCustVal = new Label();
            lblCardCustTitle = new Label();
            pnlCardOrders = new Panel();
            lblCardOrdersVal = new Label();
            lblCardOrdersTitle = new Label();
            pnlCardRevenue = new Panel();
            lblCardRevVal = new Label();
            lblCardRevTitle = new Label();
            lblDashboardTitle = new Label();
            stsMain = new StatusStrip();
            tssUser = new ToolStripStatusLabel();
            tssRole = new ToolStripStatusLabel();
            tssClock = new ToolStripStatusLabel();
            pnRevenue = new Panel();
            lblTodayRevenue = new Label();
            lblRevTitle = new Label();
            pnAlertStock = new Panel();
            lblLowStockCount = new Label();
            lblAlertTitle = new Label();
            lblAdminName = new Label();
            lblWelcome = new Label();
            pnSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnTop.SuspendLayout();
            pnContent.SuspendLayout();
            pnlChartContainer.SuspendLayout();
            pnlKPIContainer.SuspendLayout();
            pnlCardStock.SuspendLayout();
            pnlCardCustomers.SuspendLayout();
            pnlCardOrders.SuspendLayout();
            pnlCardRevenue.SuspendLayout();
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
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.ForestGreen;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDashboard.Location = new Point(0, 85);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(157, 40);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "  TRANG CHỦ";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnSales
            // 
            btnSales.BackColor = Color.ForestGreen;
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.ForeColor = Color.White;
            btnSales.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSales.Location = new Point(0, 125);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(157, 40);
            btnSales.TabIndex = 2;
            btnSales.Text = "  BÁN HÀNG (POS)";
            btnSales.TextAlign = ContentAlignment.MiddleLeft;
            btnSales.UseVisualStyleBackColor = false;
            btnSales.Click += btnSales_Click;
            // 
            // btnProduct
            // 
            btnProduct.BackColor = Color.Transparent;
            btnProduct.FlatAppearance.BorderSize = 0;
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.ForeColor = Color.White;
            btnProduct.Location = new Point(0, 165);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(157, 35);
            btnProduct.TabIndex = 3;
            btnProduct.Text = "   Sản Phẩm";
            btnProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnProduct.UseVisualStyleBackColor = false;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnCategory
            // 
            btnCategory.BackColor = Color.Transparent;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.ForeColor = Color.White;
            btnCategory.Location = new Point(0, 200);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(157, 35);
            btnCategory.TabIndex = 4;
            btnCategory.Text = "   Loại Hàng";
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.UseVisualStyleBackColor = false;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.BackColor = Color.Transparent;
            btnSupplier.FlatAppearance.BorderSize = 0;
            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.ForeColor = Color.White;
            btnSupplier.Location = new Point(0, 235);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(157, 35);
            btnSupplier.TabIndex = 13;
            btnSupplier.Text = "   Nhà Cung Cấp";
            btnSupplier.TextAlign = ContentAlignment.MiddleLeft;
            btnSupplier.UseVisualStyleBackColor = false;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnInventory
            // 
            btnInventory.BackColor = Color.Transparent;
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.ForeColor = Color.White;
            btnInventory.Location = new Point(0, 270);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(157, 35);
            btnInventory.TabIndex = 7;
            btnInventory.Text = "   Kho Hàng";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.UseVisualStyleBackColor = false;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.BackColor = Color.Transparent;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.ForeColor = Color.White;
            btnCustomer.Location = new Point(0, 305);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(157, 35);
            btnCustomer.TabIndex = 5;
            btnCustomer.Text = "   Khách Hàng";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.UseVisualStyleBackColor = false;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.Transparent;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.ForeColor = Color.White;
            btnUser.Location = new Point(0, 340);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(157, 35);
            btnUser.TabIndex = 6;
            btnUser.Text = "   Nhân Viên";
            btnUser.TextAlign = ContentAlignment.MiddleLeft;
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // btnReport
            // 
            btnReport.BackColor = Color.Transparent;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(0, 375);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(157, 35);
            btnReport.TabIndex = 8;
            btnReport.Text = "   Báo Cáo";
            btnReport.TextAlign = ContentAlignment.MiddleLeft;
            btnReport.UseVisualStyleBackColor = false;
            btnReport.Click += btnReport_Click;
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
            pnTop.Size = new Size(643, 60); // Đảm bảo chiều cao TopBar cố định 60
            pnTop.TabIndex = 1;
            // 
            // cboFilter
            // 
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.FormattingEnabled = true;
            cboFilter.Items.AddRange(new object[] { "7 ngày gần nhất", "30 ngày gần nhất", "Hôm nay" });
            cboFilter.Location = new Point(350, 10);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(130, 28);
            cboFilter.TabIndex = 15;
            cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;

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
            pnContent.Controls.Add(pnlDashboardHome);
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(157, 60);
            pnContent.Name = "pnContent";
            pnContent.Padding = new Padding(15); // Tạo lề để không sát sạt các cạnh
            pnContent.Size = new Size(643, 405);
            pnContent.TabIndex = 2;
            pnContent.AutoScroll = true; // Cho phép cuộn nếu màn hình nhỏ
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
            crtRevenue.Location = new Point(0, 0);
            crtRevenue.Name = "crtRevenue";
            crtRevenue.Size = new Size(598, 178);
            crtRevenue.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChartTitle.Location = new Point(15, 10);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(229, 23);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "Doanh thu 7 ngày gần nhất";
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
            lblCardStockTitle.Size = new Size(66, 19);
            lblCardStockTitle.TabIndex = 0;
            lblCardStockTitle.Text = "SẮP HẾT";
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
            lblCardCustTitle.Size = new Size(105, 19);
            lblCardCustTitle.TabIndex = 0;
            lblCardCustTitle.Text = "KHÁCH HÀNG";
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
            lblCardOrdersTitle.Size = new Size(87, 19);
            lblCardOrdersTitle.TabIndex = 0;
            lblCardOrdersTitle.Text = "ĐƠN HÀNG";
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
            lblCardRevTitle.Size = new Size(95, 19);
            lblCardRevTitle.TabIndex = 0;
            lblCardRevTitle.Text = "DOANH THU";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDashboardTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblDashboardTitle.Location = new Point(20, 20);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(290, 32);
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
            // pnRevenue
            // 
            pnRevenue.Location = new Point(0, 0);
            pnRevenue.Name = "pnRevenue";
            pnRevenue.Size = new Size(200, 100);
            pnRevenue.TabIndex = 0;
            // 
            // lblTodayRevenue
            // 
            lblTodayRevenue.Location = new Point(0, 0);
            lblTodayRevenue.Name = "lblTodayRevenue";
            lblTodayRevenue.Size = new Size(100, 23);
            lblTodayRevenue.TabIndex = 0;
            // 
            // lblRevTitle
            // 
            lblRevTitle.Location = new Point(0, 0);
            lblRevTitle.Name = "lblRevTitle";
            lblRevTitle.Size = new Size(100, 23);
            lblRevTitle.TabIndex = 0;
            // 
            // pnAlertStock
            // 
            pnAlertStock.Location = new Point(0, 0);
            pnAlertStock.Name = "pnAlertStock";
            pnAlertStock.Size = new Size(200, 100);
            pnAlertStock.TabIndex = 0;
            // 
            // lblLowStockCount
            // 
            lblLowStockCount.Location = new Point(0, 0);
            lblLowStockCount.Name = "lblLowStockCount";
            lblLowStockCount.Size = new Size(100, 23);
            lblLowStockCount.TabIndex = 0;
            // 
            // lblAlertTitle
            // 
            lblAlertTitle.Location = new Point(0, 0);
            lblAlertTitle.Name = "lblAlertTitle";
            lblAlertTitle.Size = new Size(100, 23);
            lblAlertTitle.TabIndex = 0;
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
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnContent);
            Controls.Add(pnTop);
            Controls.Add(pnSidebar);
            Controls.Add(stsMain);
            Name = "FormMain";
            Text = "Hệ thống quản lý bán hàng cho cửa hàng tiện lợi";
            Load += FormMain_Load;
            pnSidebar.ResumeLayout(false);
            pnSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnContent.ResumeLayout(false);
            pnContent.PerformLayout();
            pnlChartContainer.ResumeLayout(false);
            pnlChartContainer.PerformLayout();
            pnlKPIContainer.ResumeLayout(false);
            pnlCardStock.ResumeLayout(false);
            pnlCardStock.PerformLayout();
            pnlCardCustomers.ResumeLayout(false);
            pnlCardCustomers.PerformLayout();
            pnlCardOrders.ResumeLayout(false);
            pnlCardOrders.PerformLayout();
            pnlCardRevenue.ResumeLayout(false);
            pnlCardRevenue.PerformLayout();
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
        private Button btnLogout;
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
        private Label lblAdminName;
        private Label lblWelcome;
        private ComboBox cboFilter;
        private Panel pnlDashboardHome;
    }
}
