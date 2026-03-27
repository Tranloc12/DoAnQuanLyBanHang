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

        public DataTable LayDoanhThu7Ngay()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"
                    WITH DateList AS (
                        SELECT CAST(GETDATE() - 6 AS DATE) AS Ngay
                        UNION ALL
                        SELECT DATEADD(DAY, 1, Ngay) FROM DateList WHERE Ngay < CAST(GETDATE() AS DATE)
                    )
                    SELECT 
                        d.Ngay, 
                        ISNULL(SUM(o.FinalAmount), 0) AS DoanhThu
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
    }
}
