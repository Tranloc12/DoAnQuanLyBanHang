using Microsoft.Data.SqlClient;
using DoAnQuanLyBanHang.DTO;
using System.Data;

namespace DoAnQuanLyBanHang.DAL
{
    public class CustomerDAL
    {
        // Lấy danh sách khách hàng
        public DataTable LayDanhSachKhachHang()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT CustomerID, CustomerName, Phone, Email, Address,
                                        TotalSpent, LoyaltyPoints
                                 FROM Customers ORDER BY CustomerID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Tìm kiếm khách hàng theo tên hoặc SĐT
        public DataTable TimKiemKhachHang(string tuKhoa)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT CustomerID, CustomerName, Phone, Email, Address,
                                        TotalSpent, LoyaltyPoints
                                 FROM Customers
                                 WHERE CustomerName LIKE @kw OR Phone LIKE @kw
                                 ORDER BY CustomerID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@kw", "%" + tuKhoa + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Tìm theo số điện thoại (dùng khi bán hàng)
        public CustomerDTO TimTheoSoDienThoai(string phone)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = @"SELECT CustomerID, CustomerName, Phone, Email, Address,
                                        TotalSpent, LoyaltyPoints
                                 FROM Customers WHERE Phone = @phone";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@phone", phone);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return DocDTOTuReader(reader);
            }
            return null;
        }

        // Thêm khách hàng
        public bool ThemKhachHang(CustomerDTO kh)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"INSERT INTO Customers (CustomerName, Phone, Email, Address)
                                 VALUES (@name, @phone, @email, @address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name",    kh.CustomerName);
                cmd.Parameters.AddWithValue("@phone",   kh.Phone);
                cmd.Parameters.AddWithValue("@email",   (object)kh.Email   ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@address", (object)kh.Address ?? System.DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Sửa khách hàng
        public bool SuaKhachHang(CustomerDTO kh)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"UPDATE Customers
                                 SET CustomerName = @name, Phone = @phone,
                                     Email = @email, Address = @address
                                 WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id",      kh.CustomerID);
                cmd.Parameters.AddWithValue("@name",    kh.CustomerName);
                cmd.Parameters.AddWithValue("@phone",   kh.Phone);
                cmd.Parameters.AddWithValue("@email",   (object)kh.Email   ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@address", (object)kh.Address ?? System.DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa khách hàng
        public bool XoaKhachHang(int customerId)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "DELETE FROM Customers WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", customerId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Trừ điểm khi khách dùng điểm
        public bool TruDiemKhachHang(int customerId, int soDiemDung)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"UPDATE Customers
                                 SET LoyaltyPoints = LoyaltyPoints - @diem
                                 WHERE CustomerID = @id AND LoyaltyPoints >= @diem";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id",   customerId);
                cmd.Parameters.AddWithValue("@diem", soDiemDung);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra số điện thoại đã tồn tại chưa
        public bool KiemTraSoDienThoai(string phone, int excludeCustomerId = 0)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE Phone = @phone AND CustomerID <> @id", conn);
                cmd.Parameters.AddWithValue("@phone", phone.Trim());
                cmd.Parameters.AddWithValue("@id",    excludeCustomerId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private CustomerDTO DocDTOTuReader(SqlDataReader reader)
        {
            return new CustomerDTO
            {
                CustomerID   = (int)reader["CustomerID"],
                CustomerName = reader["CustomerName"].ToString(),
                Phone        = reader["Phone"].ToString(),
                Email        = reader["Email"]   == System.DBNull.Value ? "" : reader["Email"].ToString(),
                Address      = reader["Address"] == System.DBNull.Value ? "" : reader["Address"].ToString(),
                TotalSpent   = (decimal)reader["TotalSpent"],
                LoyaltyPoints = (int)reader["LoyaltyPoints"]
            };
        }
    }
}
