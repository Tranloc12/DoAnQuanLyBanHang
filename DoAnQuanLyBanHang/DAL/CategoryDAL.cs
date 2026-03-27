using System.Data;
using Microsoft.Data.SqlClient;

namespace DoAnQuanLyBanHang.DAL
{
    public class CategoryDAL
    {
        public DataTable LayDanhSachLoaiHang()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT CategoryID, CategoryName, Description FROM Categories ORDER BY CategoryName", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool KiemTraTenLoai(string name)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories WHERE CategoryName = @name", conn);
                cmd.Parameters.AddWithValue("@name", name);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool ThemLoaiHang(string name, string description)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Categories (CategoryName, Description) VALUES (@name, @desc)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@desc", (object)description ?? System.DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool SuaLoaiHang(int id, string name, string description)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Categories SET CategoryName = @name, Description = @desc WHERE CategoryID = @id", conn);
                cmd.Parameters.AddWithValue("@id",   id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@desc", (object)description ?? System.DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaLoaiHang(int id)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                // Kiểm tra còn sản phẩm không
                SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM Products WHERE CategoryID = @id AND IsActive = 1", conn);
                check.Parameters.AddWithValue("@id", id);
                if ((int)check.ExecuteScalar() > 0) return false;

                SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
