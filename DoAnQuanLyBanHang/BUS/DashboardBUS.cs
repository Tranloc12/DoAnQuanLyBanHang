using DoAnQuanLyBanHang.DAL;

namespace DoAnQuanLyBanHang.BUS
{
    public class DashboardBUS
    {
        private readonly DashboardDAL dashboardDAL = new DashboardDAL();

        public int LaySoSanPhamSapHet()          => dashboardDAL.LaySoSanPhamSapHet();
        public decimal LayDoanhThuHomNay()        => dashboardDAL.LayDoanhThuHomNay();
        public int LayTongDonHangHomNay()          => dashboardDAL.LayTongDonHangHomNay();
        public int LayTongKhachHang()              => dashboardDAL.LayTongKhachHang();

        // Định dạng doanh thu để hiển thị
        public string LayDoanhThuDinhDang()
        {
            return dashboardDAL.LayDoanhThuHomNay().ToString("N0") + " VNĐ";
        }

        public System.Data.DataTable LayDoanhThu7Ngay()
        {
            return dashboardDAL.LayDoanhThu7Ngay();
        }
    }
}
