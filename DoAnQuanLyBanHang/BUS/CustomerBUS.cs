using System.Data;
using DoAnQuanLyBanHang.DAL;
using DoAnQuanLyBanHang.DTO;

namespace DoAnQuanLyBanHang.BUS
{
    public class CustomerBUS
    {
        private readonly CustomerDAL customerDAL = new CustomerDAL();

        public DataTable LayDanhSachKhachHang()
        {
            return customerDAL.LayDanhSachKhachHang();
        }

        public DataTable TimKiemKhachHang(string tuKhoa)
        {
            return customerDAL.TimKiemKhachHang(tuKhoa);
        }

        public CustomerDTO TimTheoSoDienThoai(string phone)
        {
            return customerDAL.TimTheoSoDienThoai(phone);
        }

        public bool ThemKhachHang(CustomerDTO kh)
        {
            if (string.IsNullOrWhiteSpace(kh.CustomerName) || string.IsNullOrWhiteSpace(kh.Phone))
                return false;
            if (customerDAL.KiemTraSoDienThoai(kh.Phone))
                return false;  // SĐT đã tồn tại
            return customerDAL.ThemKhachHang(kh);
        }

        public bool SuaKhachHang(CustomerDTO kh)
        {
            if (string.IsNullOrWhiteSpace(kh.CustomerName) || string.IsNullOrWhiteSpace(kh.Phone))
                return false;
            return customerDAL.SuaKhachHang(kh);
        }

        public bool XoaKhachHang(int customerId)
        {
            return customerDAL.XoaKhachHang(customerId);
        }
    }
}
