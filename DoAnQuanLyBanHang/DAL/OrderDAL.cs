using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DoAnQuanLyBanHang.DTO;
using System.Data;

namespace DoAnQuanLyBanHang.DAL
{
    public class OrderDAL
    {
        // Lấy tất cả đơn hàng
        public DataTable LayDanhSachDonHang()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT o.OrderID, o.OrderCode,
                                        o.CustomerID, ISNULL(c.CustomerName, N'Khách lẻ') AS CustomerName,
                                        o.UserID,     u.FullName AS UserName,
                                        o.OrderDate,  o.TotalAmount, o.Discount, o.FinalAmount,
                                        o.PaymentMethod, o.OrderStatus, o.Notes
                                 FROM Orders o
                                 LEFT JOIN Customers c ON o.CustomerID = c.CustomerID
                                 INNER JOIN Users    u ON o.UserID     = u.UserID
                                 ORDER BY o.OrderDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy chi tiết đơn hàng theo OrderID
        public DataTable LayChiTietDonHang(int orderId)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT od.OrderDetailID, od.OrderID,
                                        od.ProductID, p.ProductCode, p.ProductName,
                                        od.Quantity, od.UnitPrice, od.LineTotal
                                 FROM OrderDetails od
                                 INNER JOIN Products p ON od.ProductID = p.ProductID
                                 WHERE od.OrderID = @id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@id", orderId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy đơn hàng theo ngày
        public DataTable LayDonHangTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT o.OrderID, o.OrderCode,
                                        o.CustomerID, ISNULL(c.CustomerName, N'Khách lẻ') AS CustomerName,
                                        o.UserID,     u.FullName AS UserName,
                                        o.OrderDate,  o.TotalAmount, o.Discount, o.FinalAmount,
                                        o.PaymentMethod, o.OrderStatus, o.Notes
                                 FROM Orders o
                                 LEFT JOIN Customers c ON o.CustomerID = c.CustomerID
                                 INNER JOIN Users    u ON o.UserID     = u.UserID
                                 WHERE CAST(o.OrderDate AS DATE) BETWEEN @tu AND @den
                                 ORDER BY o.OrderDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@tu",  tuNgay.Date);
                da.SelectCommand.Parameters.AddWithValue("@den", denNgay.Date);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Tạo đơn hàng — trả về OrderID vừa tạo
        public int TaoDonHang(OrderDTO donHang)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"INSERT INTO Orders
                                    (OrderCode, CustomerID, UserID, TotalAmount, Discount, FinalAmount,
                                     PaymentMethod, OrderStatus, Notes)
                                 VALUES
                                    (@code, @custId, @userId, @total, @discount, @final,
                                     @payment, @status, @notes);
                                 
                                 IF @custId IS NOT NULL
                                 BEGIN
                                     UPDATE Customers 
                                     SET LoyaltyPoints = LoyaltyPoints + CAST((@final / 100000) AS int)
                                     WHERE CustomerID = @custId
                                 END
                                 
                                 SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code",     donHang.OrderCode);
                cmd.Parameters.AddWithValue("@custId",   (object)donHang.CustomerID ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@userId",   donHang.UserID);
                cmd.Parameters.AddWithValue("@total",    donHang.TotalAmount);
                cmd.Parameters.AddWithValue("@discount", donHang.Discount);
                cmd.Parameters.AddWithValue("@final",    donHang.FinalAmount);
                cmd.Parameters.AddWithValue("@payment",  (object)donHang.PaymentMethod ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@status",   donHang.OrderStatus ?? "Hoàn thành");
                cmd.Parameters.AddWithValue("@notes",    (object)donHang.Notes ?? System.DBNull.Value);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Thêm chi tiết đơn hàng (trigger sẽ tự trừ kho)
        public bool ThemChiTietDonHang(OrderDetailDTO chiTiet)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
                                 VALUES (@orderId, @prodId, @qty, @price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", chiTiet.OrderID);
                cmd.Parameters.AddWithValue("@prodId",  chiTiet.ProductID);
                cmd.Parameters.AddWithValue("@qty",     chiTiet.Quantity);
                cmd.Parameters.AddWithValue("@price",   chiTiet.UnitPrice);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Hủy đơn hàng
        public bool HuyDonHang(int orderId)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE Orders SET OrderStatus = N'Hủy' WHERE OrderID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", orderId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Sinh mã đơn hàng tự động: HD-yyyyMMdd-001
        public string SinhMaDonHang()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string dateStr = DateTime.Now.ToString("yyyyMMdd");
                string query   = $"SELECT COUNT(*) FROM Orders WHERE OrderCode LIKE 'HD-{dateStr}%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                int seq = (int)cmd.ExecuteScalar() + 1;
                return $"HD-{dateStr}-{seq:000}";
            }
        }
    }
}
