using System.Data;
using DAL_QuanLy;

namespace BUS_QuanLy
{
    public class SupplierBUS
    {
        private readonly SupplierDAL supplierDAL = new SupplierDAL();

        public DataTable LayDanhSachNhaCungCap() => supplierDAL.LayDanhSachNhaCungCap();

        public bool ThemNhaCungCap(string name, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (supplierDAL.KiemTraTenNCC(name)) return false;
            if (supplierDAL.KiemTraSoDienThoai(phone)) return false;
            return supplierDAL.ThemNhaCungCap(name, phone, address);
        }

        public bool SuaNhaCungCap(int id, string name, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (supplierDAL.KiemTraTenNCC(name, id))     return false;
            if (supplierDAL.KiemTraSoDienThoai(phone, id)) return false;
            return supplierDAL.SuaNhaCungCap(id, name, phone, address);
        }

        public bool XoaNhaCungCap(int id) => supplierDAL.XoaNhaCungCap(id);
    }
}
