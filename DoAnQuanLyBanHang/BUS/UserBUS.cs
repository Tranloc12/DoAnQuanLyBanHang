using System.Data;
using DoAnQuanLyBanHang.DAL;
using DoAnQuanLyBanHang.DTO;

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
            return userDAL.KiemTraDangNhap(userName, matKhau);
        }

        // Lấy danh sách nhân viên
        public DataTable LayDanhSachNhanVien()
        {
            return userDAL.LayDanhSachNhanVien();
        }

        // Thêm nhân viên
        public bool ThemNhanVien(UserDTO user, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(matKhau))
                return false;
            if (userDAL.KiemTraUserName(user.UserName))
                return false;  // Username đã tồn tại
            if (string.IsNullOrWhiteSpace(user.Role))
                user.Role = "Staff";
            return userDAL.ThemNhanVien(user, matKhau);
        }

        // Sửa nhân viên
        public bool SuaNhanVien(UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName))
                return false;
            return userDAL.SuaNhanVien(user);
        }

        // Đổi mật khẩu
        public bool DoiMatKhau(int userId, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi))
                return false;
            return userDAL.DoiMatKhau(userId, matKhauMoi);
        }

        // Xóa nhân viên
        public bool XoaNhanVien(int userId)
        {
            return userDAL.XoaNhanVien(userId);
        }

        // Quên mật khẩu
        public string QuenMatKhau(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email))
                return null;
            return userDAL.LayMatKhau(username, email);
        }
    }
}