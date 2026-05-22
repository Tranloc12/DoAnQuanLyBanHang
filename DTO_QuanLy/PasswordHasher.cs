using System;
using System.Security.Cryptography;
using System.Text;

namespace DTO_QuanLy
{
    public static class PasswordHasher
    {
        /// <summary>
        /// Băm mật khẩu bằng thuật toán SHA-256
        /// </summary>
        /// <param name="password">Mật khẩu thô</param>
        /// <returns>Chuỗi hex đã băm</returns>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Chuyển byte array sang chuỗi Hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Kiểm tra mật khẩu thô và mật khẩu đã băm có khớp nhau không
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string hashOfInput = HashPassword(password);
            return string.Equals(hashOfInput, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
