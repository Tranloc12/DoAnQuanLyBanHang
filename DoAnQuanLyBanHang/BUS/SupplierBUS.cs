using System.Data;
using DoAnQuanLyBanHang.DAL;

namespace DoAnQuanLyBanHang.BUS
{
    public class SupplierBUS
    {
        private readonly SupplierDAL supplierDAL = new SupplierDAL();

        public DataTable LayDanhSachNhaCungCap() => supplierDAL.LayDanhSachNhaCungCap();

        public bool ThemNhaCungCap(string name, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (supplierDAL.KiemTraTenNCC(name)) return false;
            return supplierDAL.ThemNhaCungCap(name, phone, address);
        }

        public bool SuaNhaCungCap(int id, string name, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            return supplierDAL.SuaNhaCungCap(id, name, phone, address);
        }

        public bool XoaNhaCungCap(int id) => supplierDAL.XoaNhaCungCap(id);
    }
}
