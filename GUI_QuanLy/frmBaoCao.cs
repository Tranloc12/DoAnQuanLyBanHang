using System;
using System.Data;
using System.Windows.Forms;
using BUS_QuanLy;

namespace GUI_QuanLy
{
    public partial class frmBaoCao : Form
    {
        private readonly OrderBUS     orderBUS     = new OrderBUS();
        private readonly DashboardBUS dashBUS      = new DashboardBUS();
        private readonly ProductBUS   productBUS   = new ProductBUS();
        private readonly InventoryBUS inventoryBUS = new InventoryBUS();

        public frmBaoCao()
        {
            InitializeComponent();
            
            // Đăng ký sự kiện tự động căn chỉnh các thẻ KPI khi thay đổi kích thước
            this.SizeChanged += (s, e) => CanhChinhCardKPI();
            this.Layout += (s, e) => CanhChinhCardKPI();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value  = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;
            TaiTongQuan();
            CanhChinhCardKPI();
        }

        private void TaiTongQuan()
        {
            try
            {
                lblDoanhThuHomNay.Text = dashBUS.LayDoanhThuDinhDang();
                lblTongDonHomNay.Text  = dashBUS.LayTongDonHangHomNay().ToString("N0") + " đơn";
                lblTongKhachHang.Text  = dashBUS.LayTongKhachHang().ToString("N0") + " khách";
                lblSanPhamSapHet.Text  = dashBUS.LaySoSanPhamSapHet().ToString("N0") + " sản phẩm";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // Đặt header tiếng Việt cho từng kiểu báo cáo
        private void DatHeaderDonHang()
        {
            var cols = dgvBaoCao.Columns;
            if (cols["OrderID"] != null)       cols["OrderID"].Visible       = false;
            if (cols["CustomerID"] != null)    cols["CustomerID"].Visible    = false;
            if (cols["UserID"] != null)        cols["UserID"].Visible        = false;
            if (cols["OrderCode"] != null)     cols["OrderCode"].HeaderText     = "Mã đơn hàng";
            if (cols["CustomerName"] != null)  cols["CustomerName"].HeaderText  = "Khách hàng";
            if (cols["UserName"] != null)      cols["UserName"].HeaderText      = "Nhân viên";
            if (cols["OrderDate"] != null)     cols["OrderDate"].HeaderText     = "Ngày đặt";
            if (cols["TotalAmount"] != null)   cols["TotalAmount"].HeaderText   = "Tổng tiền";
            if (cols["Discount"] != null)      cols["Discount"].HeaderText      = "Giảm giá";
            if (cols["FinalAmount"] != null)   cols["FinalAmount"].HeaderText   = "Thành tiền";
            if (cols["PaymentMethod"] != null) cols["PaymentMethod"].HeaderText = "Thanh toán";
            if (cols["OrderStatus"] != null)   cols["OrderStatus"].HeaderText   = "Trạng thái";
            if (cols["Notes"] != null)         cols["Notes"].HeaderText         = "Ghi chú";
        }

        private void DatHeaderSapHet()
        {
            var cols = dgvBaoCao.Columns;
            if (cols["ProductID"] != null)   cols["ProductID"].Visible    = false;
            if (cols["CategoryID"] != null)  cols["CategoryID"].Visible   = false;
            if (cols["SupplierID"] != null)  cols["SupplierID"].Visible   = false;
            if (cols["IsActive"] != null)    cols["IsActive"].Visible     = false;
            if (cols["ProductCode"] != null)  cols["ProductCode"].HeaderText  = "Mã SP";
            if (cols["ProductName"] != null)  cols["ProductName"].HeaderText  = "Tên sản phẩm";
            if (cols["CategoryName"] != null) cols["CategoryName"].HeaderText = "Loại hàng";
            if (cols["SupplierName"] != null) cols["SupplierName"].HeaderText = "Nhà cung cấp";
            if (cols["CostPrice"] != null)
            {
                if (DTO_QuanLy.SessionUser.CurrentUser?.Role == "Admin") cols["CostPrice"].HeaderText = "Giá nhập";
                else cols["CostPrice"].Visible = false;
            }
            if (cols["SellPrice"] != null)    cols["SellPrice"].HeaderText    = "Giá bán";
            if (cols["Quantity"] != null)     cols["Quantity"].HeaderText     = "Tồn kho";
            if (cols["MinQuantity"] != null)  cols["MinQuantity"].HeaderText  = "SL tối thiểu";
            if (cols["Unit"] != null)         cols["Unit"].HeaderText         = "Đơn vị";
            if (cols["LoiNhuan"] != null)
            {
                if (DTO_QuanLy.SessionUser.CurrentUser?.Role == "Admin") cols["LoiNhuan"].HeaderText = "Lợi nhuận";
                else cols["LoiNhuan"].Visible = false;
            }
            if (cols["SapHetHang"] != null)   cols["SapHetHang"].Visible      = false;
        }

        private void DatHeaderBanChay()
        {
            var cols = dgvBaoCao.Columns;
            if (cols["ProductID"] != null)    cols["ProductID"].Visible     = false;
            if (cols["ProductCode"] != null)  cols["ProductCode"].HeaderText  = "Mã SP";
            if (cols["ProductName"] != null)  cols["ProductName"].HeaderText  = "Tên sản phẩm";
            if (cols["CategoryName"] != null) cols["CategoryName"].HeaderText = "Loại hàng";
            if (cols["TongSoLuong"] != null)  cols["TongSoLuong"].HeaderText  = "SL đã bán";
            if (cols["DoanhThu"] != null)     cols["DoanhThu"].HeaderText     = "Doanh thu";
            if (cols["LoiNhuan"] != null)
            {
                if (DTO_QuanLy.SessionUser.CurrentUser?.Role == "Admin") cols["LoiNhuan"].HeaderText = "Lợi nhuận";
                else cols["LoiNhuan"].Visible = false;
            }
        }

        // Doanh thu theo khoảng ngày
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = orderBUS.LayDonHangTheoNgay(dtpTuNgay.Value, dtpDenNgay.Value);
                dgvBaoCao.Columns.Clear();
                dgvBaoCao.DataSource = dt;
                DatHeaderDonHang();
                decimal tongDT = 0;
                foreach (DataRow row in dt.Rows)
                    tongDT += Convert.ToDecimal(row["FinalAmount"]);
                lblKetQua.Text = $"📊 {dt.Rows.Count} đơn   |   Doanh thu: {tongDT:N0} VNĐ   ({dtpTuNgay.Value:dd/MM} – {dtpDenNgay.Value:dd/MM/yyyy})";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // Sản phẩm sắp hết
        private void btnXemSapHet_Click(object sender, EventArgs e)
        {
            dgvBaoCao.Columns.Clear();
            dgvBaoCao.DataSource = productBUS.LayDanhSachSapHet();
            DatHeaderSapHet();
            lblKetQua.Text = $"⚠ Sản phẩm tồn kho ≤ mức tối thiểu: {dgvBaoCao.Rows.Count} SP";
        }

        // Sản phẩm bán chạy
        private void btnBanChay_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = inventoryBUS.LayBanChay(dtpTuNgay.Value, dtpDenNgay.Value, 10);
                dgvBaoCao.Columns.Clear();
                dgvBaoCao.DataSource = dt;
                DatHeaderBanChay();
                lblKetQua.Text = $"🏆 Top 10 sản phẩm bán chạy ({dtpTuNgay.Value:dd/MM} – {dtpDenNgay.Value:dd/MM/yyyy})";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // Doanh thu ca hôm nay
        private void btnCaHomNay_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = orderBUS.LayDonHangTheoNgay(DateTime.Today, DateTime.Today);
                dgvBaoCao.Columns.Clear();
                dgvBaoCao.DataSource = dt;
                DatHeaderDonHang();
                decimal tongDT = 0;
                foreach (DataRow row in dt.Rows)
                    tongDT += Convert.ToDecimal(row["FinalAmount"]);
                lblKetQua.Text = $"📅 Ca hôm nay ({DateTime.Today:dd/MM/yyyy}): {dt.Rows.Count} đơn   |   {tongDT:N0} VNĐ";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiTongQuan();
            dgvBaoCao.DataSource = null;
            lblKetQua.Text = "";
        }

        private void CanhChinhCardKPI()
        {
            Panel[] cards = { pnlCard1, pnlCard2, pnlCard3, pnlCard4 };
            if (pnlKPI == null) return;
            int cardCount = cards.Length;
            int spacing = 15;
            int totalSpacing = spacing * (cardCount - 1);
            int cardWidth = (pnlKPI.Width - totalSpacing) / cardCount;
            int cardHeight = pnlKPI.Height - 10;

            for (int i = 0; i < cardCount; i++)
            {
                if (cards[i] == null) continue;
                cards[i].Size = new System.Drawing.Size(cardWidth, cardHeight);
                cards[i].Location = new System.Drawing.Point(i * (cardWidth + spacing), 5);

                // Cập nhật kích thước label bên trong card để không bị cắt chữ
                foreach (Control ctrl in cards[i].Controls)
                {
                    if (ctrl is Label lbl)
                    {
                        lbl.Width = cardWidth - 20;
                    }
                }
            }
        }
    }
}
