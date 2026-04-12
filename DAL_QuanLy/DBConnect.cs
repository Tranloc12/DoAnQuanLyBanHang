using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DBConnect
    {
        // Chỉnh sửa lại chuỗi kết nối cho phù hợp với máy của bạn
        protected SqlConnection _conn = new SqlConnection(@"Data Source=.;Initial Catalog=QLSV;Integrated Security=True;TrustServerCertificate=True");
    }
}
