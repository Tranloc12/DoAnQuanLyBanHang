using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DoAnQuanLyBanHang.DAL
{
    public class InventoryDAL
    {
        // Toàn bộ tồn kho hiện tại
        public DataTable LayTonKho()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"
                    SELECT p.ProductID, p.ProductCode, p.ProductName,
                           c.CategoryName, s.SupplierName,
                           p.Quantity       AS TonKho,
                           p.MinQuantity    AS TonToiThieu,
                           p.SellPrice,
                           CASE
                               WHEN p.Quantity = 0        THEN N'Hết hàng'
                               WHEN p.Quantity <= p.MinQuantity THEN N'Sắp hết'
                               ELSE N'Còn hàng'
                           END AS TrangThai
                    FROM Products p
                    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                    LEFT JOIN Suppliers  s ON p.SupplierID = s.SupplierID
                    WHERE p.IsActive = 1
                    ORDER BY p.Quantity ASC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Sản phẩm bán chạy theo khoảng ngày
        public DataTable LayBanChay(DateTime tuNgay, DateTime denNgay, int topN = 10)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = $@"
                    SELECT TOP {topN}
                           p.ProductCode, p.ProductName,
                           SUM(od.Quantity)              AS TongBan,
                           SUM(od.Quantity * od.UnitPrice) AS DoanhThu
                    FROM OrderDetails od
                    INNER JOIN Products p ON od.ProductID = p.ProductID
                    INNER JOIN Orders   o ON od.OrderID   = o.OrderID
                    WHERE o.OrderStatus = N'Hoàn thành'
                      AND CAST(o.OrderDate AS DATE) BETWEEN @tu AND @den
                    GROUP BY p.ProductCode, p.ProductName
                    ORDER BY TongBan DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@tu",  tuNgay.Date);
                da.SelectCommand.Parameters.AddWithValue("@den", denNgay.Date);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Nhập thêm hàng vào kho
        public bool NhapKho(int productId, int soLuongNhap)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Products SET Quantity = Quantity + @sl WHERE ProductID = @id", conn);
                cmd.Parameters.AddWithValue("@sl", soLuongNhap);
                cmd.Parameters.AddWithValue("@id", productId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
