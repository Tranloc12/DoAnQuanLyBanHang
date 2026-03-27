using System;
using System.Data;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;

namespace DoAnQuanLyBanHang
{
    public partial class frmBaoCao : Form
    {
        private readonly OrderBUS     orderBUS     = new OrderBUS();
        private readonly DashboardBUS dashBUS      = new DashboardBUS();
        private readonly ProductBUS   productBUS   = new ProductBUS();
        private readonly InventoryBUS inventoryBUS = new InventoryBUS();

        public frmBaoCao() { InitializeComponent(); }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value  = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;
            TaiTongQuan();
        }

        private void TaiTongQuan()
        {
            try
            {
                lblDoanhThuHomNay.Text = dashBUS.LayDoanhThuDinhDang();
                lblTongDonHomNay.Text  = dashBUS.LayTongDonHangHomNay() + " đơn";
                lblTongKhachHang.Text  = dashBUS.LayTongKhachHang() + " khách";
                lblSanPhamSapHet.Text  = dashBUS.LaySoSanPhamSapHet() + " sản phẩm";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // Doanh thu theo khoảng ngày
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = orderBUS.LayDonHangTheoNgay(dtpTuNgay.Value, dtpDenNgay.Value);
                dgvBaoCao.DataSource = dt;
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
            dgvBaoCao.DataSource = productBUS.LayDanhSachSapHet();
            lblKetQua.Text = $"⚠ Sản phẩm tồn kho ≤ mức tối thiểu: {dgvBaoCao.Rows.Count} SP";
        }

        // Sản phẩm bán chạy
        private void btnBanChay_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = inventoryBUS.LayBanChay(dtpTuNgay.Value, dtpDenNgay.Value, 10);
                dgvBaoCao.DataSource = dt;
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
                dgvBaoCao.DataSource = dt;
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
    }
}
