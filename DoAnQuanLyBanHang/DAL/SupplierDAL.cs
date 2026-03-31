using System.Data;
using Microsoft.Data.SqlClient;

namespace DoAnQuanLyBanHang.DAL
{
    public class SupplierDAL
    {
        public DataTable LayDanhSachNhaCungCap()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT SupplierID, SupplierName, Phone, Address FROM Suppliers ORDER BY SupplierName", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Kiểm tra Tên NCC đã tồn tại chưa
        public bool KiemTraTenNCC(string name, int excludeSupplierId = 0)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Suppliers WHERE SupplierName = @name AND SupplierID <> @id", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id",   excludeSupplierId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Kiểm tra số điện thoại NCC đã tồn tại chưa
        public bool KiemTraSoDienThoai(string phone, int excludeSupplierId = 0)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Suppliers WHERE Phone = @phone AND SupplierID <> @id", conn);
                cmd.Parameters.AddWithValue("@phone", phone.Trim());
                cmd.Parameters.AddWithValue("@id",    excludeSupplierId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool ThemNhaCungCap(string name, string phone, string address)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Suppliers (SupplierName, Phone, Address) VALUES (@name, @phone, @addr)", conn);
                cmd.Parameters.AddWithValue("@name",  name);
                cmd.Parameters.AddWithValue("@phone", (object)phone   ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@addr",  (object)address ?? System.DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool SuaNhaCungCap(int id, string name, string phone, string address)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Suppliers SET SupplierName=@name, Phone=@phone, Address=@addr WHERE SupplierID=@id", conn);
                cmd.Parameters.AddWithValue("@id",    id);
                cmd.Parameters.AddWithValue("@name",  name);
                cmd.Parameters.AddWithValue("@phone", (object)phone   ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@addr",  (object)address ?? System.DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaNhaCungCap(int id)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM Products WHERE SupplierID = @id AND IsActive = 1", conn);
                check.Parameters.AddWithValue("@id", id);
                if ((int)check.ExecuteScalar() > 0) return false;

                SqlCommand cmd = new SqlCommand("DELETE FROM Suppliers WHERE SupplierID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
