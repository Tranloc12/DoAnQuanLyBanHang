using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DoAnQuanLyBanHang.DTO;
using System.Data;

namespace DoAnQuanLyBanHang.DAL
{
    public class ProductDAL
    {
        // Lấy danh sách tất cả sản phẩm đang hoạt động
        public DataTable LayDanhSachSanPham()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT p.ProductID, p.ProductCode, p.ProductName,
                                        p.CategoryID, c.CategoryName,
                                        p.SupplierID, s.SupplierName,
                                        p.CostPrice, p.SellPrice,
                                        p.Quantity, p.MinQuantity, p.Unit, p.IsActive
                                 FROM Products p
                                 LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                                 LEFT JOIN Suppliers  s ON p.SupplierID = s.SupplierID
                                 WHERE p.IsActive = 1
                                 ORDER BY p.ProductID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy sản phẩm theo ID — trả về DTO
        public ProductDTO LaySanPhamTheoID(int productId)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = @"SELECT p.ProductID, p.ProductCode, p.ProductName,
                                        p.CategoryID, c.CategoryName,
                                        p.SupplierID, s.SupplierName,
                                        p.CostPrice, p.SellPrice,
                                        p.Quantity, p.MinQuantity, p.Unit, p.IsActive
                                 FROM Products p
                                 LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                                 LEFT JOIN Suppliers  s ON p.SupplierID = s.SupplierID
                                 WHERE p.ProductID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", productId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return DocDTOTuReader(reader);
            }
            return null;
        }

        // Tìm kiếm theo tên hoặc mã sản phẩm
        public DataTable TimKiemSanPham(string tuKhoa)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT p.ProductID, p.ProductCode, p.ProductName,
                                        p.CategoryID, c.CategoryName,
                                        p.SupplierID, s.SupplierName,
                                        p.CostPrice, p.SellPrice,
                                        p.Quantity, p.MinQuantity, p.Unit, p.IsActive
                                 FROM Products p
                                 LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                                 LEFT JOIN Suppliers  s ON p.SupplierID = s.SupplierID
                                 WHERE p.IsActive = 1
                                   AND (p.ProductName LIKE @kw OR p.ProductCode LIKE @kw)
                                 ORDER BY p.ProductID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@kw", "%" + tuKhoa + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Thêm sản phẩm — nhận DTO
        public bool ThemSanPham(ProductDTO sp)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"INSERT INTO Products
                                    (ProductCode, ProductName, CategoryID, SupplierID,
                                     CostPrice, SellPrice, Quantity, MinQuantity, Unit, IsActive)
                                 VALUES
                                    (@code, @name, @catId, @supId,
                                     @cost, @sell, @qty,  @min,  @unit, 1)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code",  sp.ProductCode);
                cmd.Parameters.AddWithValue("@name",  sp.ProductName);
                cmd.Parameters.AddWithValue("@catId", sp.CategoryID);
                cmd.Parameters.AddWithValue("@supId", sp.SupplierID);
                cmd.Parameters.AddWithValue("@cost",  sp.CostPrice);
                cmd.Parameters.AddWithValue("@sell",  sp.SellPrice);
                cmd.Parameters.AddWithValue("@qty",   sp.Quantity);
                cmd.Parameters.AddWithValue("@min",   sp.MinQuantity);
                cmd.Parameters.AddWithValue("@unit",  (object)sp.Unit ?? System.DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Sửa sản phẩm — nhận DTO
        public bool SuaSanPham(ProductDTO sp)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"UPDATE Products
                                 SET ProductName = @name, CategoryID = @catId, SupplierID = @supId,
                                     CostPrice = @cost,  SellPrice = @sell,
                                     Quantity = @qty,    MinQuantity = @min, Unit = @unit
                                 WHERE ProductID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id",    sp.ProductID);
                cmd.Parameters.AddWithValue("@name",  sp.ProductName);
                cmd.Parameters.AddWithValue("@catId", sp.CategoryID);
                cmd.Parameters.AddWithValue("@supId", sp.SupplierID);
                cmd.Parameters.AddWithValue("@cost",  sp.CostPrice);
                cmd.Parameters.AddWithValue("@sell",  sp.SellPrice);
                cmd.Parameters.AddWithValue("@qty",   sp.Quantity);
                cmd.Parameters.AddWithValue("@min",   sp.MinQuantity);
                cmd.Parameters.AddWithValue("@unit",  (object)sp.Unit ?? System.DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa mềm sản phẩm
        public bool XoaSanPham(int productId)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE Products SET IsActive = 0 WHERE ProductID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", productId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra mã sản phẩm đã tồn tại chưa
        public bool KiemTraMaSanPham(string productCode)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Products WHERE ProductCode = @code";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", productCode);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Lấy sản phẩm sắp hết hàng
        public DataTable LayDanhSachSapHet()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT p.ProductID, p.ProductCode, p.ProductName,
                                        p.CategoryID, c.CategoryName,
                                        p.SupplierID, s.SupplierName,
                                        p.CostPrice, p.SellPrice,
                                        p.Quantity, p.MinQuantity, p.Unit, p.IsActive
                                 FROM Products p
                                 LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                                 LEFT JOIN Suppliers  s ON p.SupplierID = s.SupplierID
                                 WHERE p.IsActive = 1 AND p.Quantity <= p.MinQuantity
                                 ORDER BY p.Quantity ASC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy danh mục (cho ComboBox)
        public DataTable LayDanhMuc()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy nhà cung cấp (cho ComboBox)
        public DataTable LayNhaCungCap()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT SupplierID, SupplierName FROM Suppliers ORDER BY SupplierName", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Helper: đọc từ SqlDataReader → ProductDTO
        private ProductDTO DocDTOTuReader(SqlDataReader reader)
        {
            return new ProductDTO
            {
                ProductID   = (int)reader["ProductID"],
                ProductCode = reader["ProductCode"].ToString(),
                ProductName = reader["ProductName"].ToString(),
                CategoryID  = (int)reader["CategoryID"],
                CategoryName = reader["CategoryName"] == System.DBNull.Value ? "" : reader["CategoryName"].ToString(),
                SupplierID  = (int)reader["SupplierID"],
                SupplierName = reader["SupplierName"] == System.DBNull.Value ? "" : reader["SupplierName"].ToString(),
                CostPrice   = (decimal)reader["CostPrice"],
                SellPrice   = (decimal)reader["SellPrice"],
                Quantity    = (int)reader["Quantity"],
                MinQuantity = (int)reader["MinQuantity"],
                Unit        = reader["Unit"] == System.DBNull.Value ? "" : reader["Unit"].ToString(),
                IsActive    = (bool)reader["IsActive"]
            };
        }
    }
}