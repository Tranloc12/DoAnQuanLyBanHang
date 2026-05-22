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
        private static readonly string chuoiKetNoi =
            @"Data Source=.;Initial Catalog=Quanlybanhang;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(chuoiKetNoi);
        }
    }
}
