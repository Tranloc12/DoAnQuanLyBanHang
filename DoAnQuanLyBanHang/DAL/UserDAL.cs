using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyBanHang.DAL
{
    public class UserDAL
    {
        DataProvider provider = new DataProvider();

        public DataTable Login(string user, string pass)
        {
            // Truy vấn đúng bảng Users mà Lộc đã tạo bên SSMS
            string query = string.Format("SELECT * FROM Users WHERE UserName = '{0}' AND PasswordHash = '{1}'", user, pass);
            return provider.ExecuteQuery(query);
        }
    }
}
