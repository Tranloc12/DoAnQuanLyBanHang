using Microsoft.Data.SqlClient;

namespace DoAnQuanLyBanHang.DAL
{
    /// <summary>
    /// Lớp tạo kết nối CSDL dùng chung — theo đúng pattern của QLThuVien.
    /// </summary>
    public static class KetNoiChung
    {
        private static readonly string chuoiKetNoi =
            @"Data Source=.;Initial Catalog=Quanlybanhang;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        /// <summary>Trả về một SqlConnection mới (chưa mở).</summary>
        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(chuoiKetNoi);
        }
    }
}
