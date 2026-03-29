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
        public int LayTongDonHangTheoNgay(int days) => dashboardDAL.LayTongDonHangKhoangNgay(days);

        // Định dạng doanh thu để hiển thị
        public string LayDoanhThuDinhDang()
        {
            return dashboardDAL.LayDoanhThuHomNay().ToString("N0") + " VNĐ";
        }

        public System.Data.DataTable LayDoanhThu30Ngay() => dashboardDAL.LayDoanhThuKhoangNgay(30);
        public System.Data.DataTable LayDoanhThuTheoNgay(int days) => dashboardDAL.LayDoanhThuKhoangNgay(days);

        public System.Data.DataTable LayTopSanPham()
        {
            return dashboardDAL.LayTopSanPham();
        }

        public System.Data.DataTable LayDonHangGanDay()
        {
            return dashboardDAL.LayDonHangGanDay();
        }
    }
}
