using System.Data;
using DoAnQuanLyBanHang.DAL;

namespace DoAnQuanLyBanHang.BUS
{
    public class CategoryBUS
    {
        private readonly CategoryDAL categoryDAL = new CategoryDAL();

        public DataTable LayDanhSachLoaiHang() => categoryDAL.LayDanhSachLoaiHang();

        public bool ThemLoaiHang(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (categoryDAL.KiemTraTenLoai(name)) return false;
            return categoryDAL.ThemLoaiHang(name, description);
        }

        public bool SuaLoaiHang(int id, string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            return categoryDAL.SuaLoaiHang(id, name, description);
        }

        public bool XoaLoaiHang(int id) => categoryDAL.XoaLoaiHang(id);
    }
}
