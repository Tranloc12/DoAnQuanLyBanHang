using Microsoft.Data.SqlClient; 
using System.Data;             

namespace DoAnQuanLyBanHang.DAL
{
    internal class DataProvider
    {
        // 1. Chuỗi kết nối phải nằm TRONG class
        private string connectionString = @"Data Source=.;Initial Catalog=Quanlybanhang;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

    

    public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        // Hàm này dùng để Thêm, Xóa, Sửa (Lát nữa mình sẽ dùng)
        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
    }
}