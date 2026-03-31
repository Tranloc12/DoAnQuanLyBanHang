using System.Data;
using DoAnQuanLyBanHang.DAL;
using DoAnQuanLyBanHang.DTO;
using DoAnQuanLyBanHang.Utils;

namespace DoAnQuanLyBanHang.BUS
{
    public class UserBUS
    {
        private readonly UserDAL userDAL = new UserDAL();

        // Đăng nhập — trả về UserDTO hoặc null
        public UserDTO KiemTraDangNhap(string userName, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(matKhau))
                return null;
            // Băm mật khẩu người dùng nhập vào để so khớp với DB
            string hashedMatKhau = PasswordHasher.HashPassword(matKhau);
            return userDAL.KiemTraDangNhap(userName, hashedMatKhau);
        }

        // Lấy danh sách nhân viên
        public DataTable LayDanhSachNhanVien()
        {
            return userDAL.LayDanhSachNhanVien();
        }

        // Kiểm tra username
        public bool KiemTraUserName(string userName)
        {
            return userDAL.KiemTraUserName(userName);
        }

        // Thêm nhân viên
        public bool ThemNhanVien(UserDTO user, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(matKhau))
                return false;
            
            // Ràng buộc tính duy nhất
            if (userDAL.KiemTraUserName(user.UserName)) return false;
            if (userDAL.KiemTraEmail(user.Email))       return false;
            if (userDAL.KiemTraPhone(user.Phone))       return false;

            if (string.IsNullOrWhiteSpace(user.Role))
                user.Role = "Staff";

            // Băm mật khẩu trước khi lưu xuống DB
            string hashedMatKhau = PasswordHasher.HashPassword(matKhau);
            return userDAL.ThemNhanVien(user, hashedMatKhau);
        }

        // Sửa nhân viên
        public bool SuaNhanVien(UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName))
                return false;

            // Ràng buộc tính duy nhất khi sửa
            if (userDAL.KiemTraEmail(user.Email, user.UserID)) return false;
            if (userDAL.KiemTraPhone(user.Phone, user.UserID)) return false;

            return userDAL.SuaNhanVien(user);
        }

        // Đổi mật khẩu
        public bool DoiMatKhau(int userId, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi))
                return false;
            // Băm mật khẩu mới trước khi cập nhật DB
            string hashedMatKhau = PasswordHasher.HashPassword(matKhauMoi);
            return userDAL.DoiMatKhau(userId, hashedMatKhau);
        }

        // Xóa nhân viên
        public bool XoaNhanVien(int userId)
        {
            return userDAL.XoaNhanVien(userId);
        }

        // Quên mật khẩu - Đặt lại mật khẩu mặc định là '123456'
        public bool QuenMatKhau(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email))
                return false;

            int userId = userDAL.LayUserIdByEmail(username, email);
            if (userId > 0)
            {
                // Reset mật khẩu về mặc định '123456'
                return DoiMatKhau(userId, "123456");
            }
            return false;
        }
    }
}