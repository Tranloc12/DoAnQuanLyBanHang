using System;
using Microsoft.Data.SqlClient;
using DoAnQuanLyBanHang.DTO;

namespace DoAnQuanLyBanHang.DAL
{
    public partial class UserDAL
    {
        // Kiểm tra Username + Email để khôi phục mật khẩu
        public string LayMatKhau(string username, string email)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT PasswordHash FROM Users WHERE UserName = @u AND Email = @e AND IsActive = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@e", email);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }
    }
}
