using System.Data;
using DoAnQuanLyBanHang.DAL;
using DoAnQuanLyBanHang.DTO;

namespace DoAnQuanLyBanHang.BUS
{
    public class ProductBUS
    {
        private readonly ProductDAL productDAL = new ProductDAL();

        public DataTable LayDanhSachSanPham()
        {
            return productDAL.LayDanhSachSanPham();
        }

        public DataTable TimKiemSanPham(string tuKhoa)
        {
            return productDAL.TimKiemSanPham(tuKhoa);
        }

        public ProductDTO LaySanPhamTheoID(int productId)
        {
            return productDAL.LaySanPhamTheoID(productId);
        }

        public bool ThemSanPham(ProductDTO sp)
        {
            if (string.IsNullOrWhiteSpace(sp.ProductCode) || string.IsNullOrWhiteSpace(sp.ProductName))
                return false;
            if (productDAL.KiemTraMaSanPham(sp.ProductCode))
                return false;  // Mã đã tồn tại
            return productDAL.ThemSanPham(sp);
        }

        public bool SuaSanPham(ProductDTO sp)
        {
            if (string.IsNullOrWhiteSpace(sp.ProductName))
                return false;
            return productDAL.SuaSanPham(sp);
        }

        public bool XoaSanPham(int productId)
        {
            return productDAL.XoaSanPham(productId);
        }

        public DataTable LayDanhSachSapHet()
        {
            return productDAL.LayDanhSachSapHet();
        }

        // Cho ComboBox
        public DataTable LayDanhMuc()    => productDAL.LayDanhMuc();
        public DataTable LayNhaCungCap() => productDAL.LayNhaCungCap();
    }
}