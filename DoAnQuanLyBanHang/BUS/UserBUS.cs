using DoAnQuanLyBanHang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyBanHang.BUS
{
    public class UserBUS
    {
        UserDAL dal = new UserDAL();

        // Đổi từ DataTable thành bool để lệnh IF bên Form hiểu được
        public bool KiemTraDangNhap(string user, string pass)
        {
            // 1. Chặn lỗi nhập trống
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return false;

            // 2. Lấy kết quả từ DAL
            DataTable dt = dal.Login(user, pass);

            // 3. Trả về true nếu bảng có dữ liệu (đăng nhập đúng), ngược lại trả về false
            return dt != null && dt.Rows.Count > 0;
        }
    }
}
