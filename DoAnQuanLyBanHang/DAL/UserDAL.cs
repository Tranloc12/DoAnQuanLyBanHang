using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DoAnQuanLyBanHang.DTO;
using System.Data;
using System;

namespace DoAnQuanLyBanHang.DAL
{
    public partial class UserDAL
    {
        // Kiểm tra đăng nhập — trả về UserDTO hoặc null
        public UserDTO KiemTraDangNhap(string userName, string matKhau)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = @"SELECT UserID, UserName, FullName, Email, Phone, Role, IsActive
                                 FROM Users
                                 WHERE UserName = @user AND PasswordHash = @pass AND IsActive = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", userName);
                cmd.Parameters.AddWithValue("@pass", matKhau);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new UserDTO
                    {
                        UserID   = (int)reader["UserID"],
                        UserName = reader["UserName"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Email    = reader["Email"]  == System.DBNull.Value ? "" : reader["Email"].ToString(),
                        Phone    = reader["Phone"]  == System.DBNull.Value ? "" : reader["Phone"].ToString(),
                        Role     = reader["Role"].ToString(),
                        IsActive = (bool)reader["IsActive"]
                    };
                }
            }
            return null;
        }

        // Lấy danh sách tất cả nhân viên
        public DataTable LayDanhSachNhanVien()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT UserID, UserName, FullName, Email, Phone, Role, IsActive FROM Users ORDER BY UserID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Kiểm tra username đã tồn tại chưa
        public bool KiemTraUserName(string userName)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE UserName = @user";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", userName);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Thêm nhân viên mới
        public bool ThemNhanVien(UserDTO user, string matKhau)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"INSERT INTO Users (UserName, PasswordHash, FullName, Email, Phone, Role, IsActive)
                                 VALUES (@user, @pass, @name, @email, @phone, @role, 1)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user",  user.UserName);
                cmd.Parameters.AddWithValue("@pass",  matKhau);
                cmd.Parameters.AddWithValue("@name",  user.FullName);
                cmd.Parameters.AddWithValue("@email", (object)user.Email  ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@phone", (object)user.Phone  ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@role",  user.Role ?? "Staff");
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Sửa thông tin nhân viên
        public bool SuaNhanVien(UserDTO user)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"UPDATE Users SET FullName = @name, Email = @email, Phone = @phone, Role = @role
                                 WHERE UserID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id",    user.UserID);
                cmd.Parameters.AddWithValue("@name",  user.FullName);
                cmd.Parameters.AddWithValue("@email", (object)user.Email  ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@phone", (object)user.Phone  ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@role",  user.Role ?? "Staff");
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Đổi mật khẩu
        public bool DoiMatKhau(int userId, string matKhauMoi)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE Users SET PasswordHash = @pass WHERE UserID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id",   userId);
                cmd.Parameters.AddWithValue("@pass", matKhauMoi);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa nhân viên (Ưu tiên xóa hẳn, nếu vướng khóa ngoại thì vô hiệu hóa)
        public bool XoaNhanVien(int userId)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                try 
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET IsActive = 0 WHERE UserID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}