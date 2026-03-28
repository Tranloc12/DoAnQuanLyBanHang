using Microsoft.Data.SqlClient;
using System.Data;

namespace DoAnQuanLyBanHang.DAL
{
    public class DashboardDAL
    {
        // Số sản phẩm sắp hết hàng
        public int LaySoSanPhamSapHet()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*) 
                    FROM Products 
                    WHERE Quantity <= MinQuantity AND IsActive = 1", conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        public DataTable LayDoanhThu30Ngay()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"
                    WITH DateList AS (
                        SELECT CAST(GETDATE() - 29 AS DATE) AS Ngay
                        UNION ALL
                        SELECT DATEADD(DAY, 1, Ngay) FROM DateList WHERE Ngay < CAST(GETDATE() AS DATE)
                    )
                    SELECT 
                        d.Ngay, 
                        ISNULL(SUM(o.FinalAmount), 0) AS DoanhThu,
                        (SELECT ISNULL(SUM(od.Quantity), 0) FROM OrderDetails od JOIN Orders od_o ON od.OrderID = od_o.OrderID WHERE CAST(od_o.OrderDate AS DATE) = d.Ngay AND od_o.OrderStatus = N'Hoàn thành') AS SoLuong
                    FROM DateList d
                    LEFT JOIN Orders o ON CAST(o.OrderDate AS DATE) = d.Ngay AND o.OrderStatus = N'Hoàn thành'
                    GROUP BY d.Ngay
                    ORDER BY d.Ngay ASC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Doanh thu hôm nay
        public decimal LayDoanhThuHomNay()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT ISNULL(SUM(FinalAmount), 0)
                      FROM Orders
                      WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)
                        AND OrderStatus = N'Hoàn thành'", conn);
                return System.Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        // Số đơn hàng hôm nay
        public int LayTongDonHangHomNay()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Orders WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)", conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        // Tổng số khách hàng
        public int LayTongKhachHang()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Customers", conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        // Lấy Top 5 sản phẩm bán chạy
        public DataTable LayTopSanPham()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"
                    SELECT TOP 5 p.ProductName, SUM(od.Quantity) as TotalQty
                    FROM OrderDetails od
                    JOIN Products p ON od.ProductID = p.ProductID
                    JOIN Orders o ON od.OrderID = o.OrderID
                    WHERE o.OrderStatus = N'Hoàn thành'
                    GROUP BY p.ProductName
                    ORDER BY TotalQty DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy 5 đơn hàng mới nhất
        public DataTable LayDonHangGanDay()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"
                    SELECT TOP 5 o.OrderCode, c.CustomerName, o.FinalAmount, o.OrderDate
                    FROM Orders o
                    LEFT JOIN Customers c ON o.CustomerID = c.CustomerID
                    ORDER BY o.OrderDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
