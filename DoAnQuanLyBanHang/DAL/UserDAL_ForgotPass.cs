using System;
using Microsoft.Data.SqlClient;
using DoAnQuanLyBanHang.DTO;

namespace DoAnQuanLyBanHang.DAL
{
    public partial class UserDAL
    {
        // Kiểm tra UserName + (Email hoặc Phone) để lấy UserID phục vụ việc reset mật khẩu
        public int LayUserIdByEmail(string username, string contact)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                // Cho phép dùng Email hoặc Số điện thoại để xác minh
                string query = "SELECT UserID FROM Users WHERE UserName = @u AND (Email = @c OR Phone = @c) AND IsActive = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@c", contact);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? (int)result : 0;
            }
        }
    }
}
