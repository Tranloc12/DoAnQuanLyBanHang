using System;
using System.Collections.Generic;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class OrderBUS
    {
        private readonly OrderDAL orderDAL = new OrderDAL();

        public DataTable LayDanhSachDonHang()
        {
            return orderDAL.LayDanhSachDonHang();
        }

        public DataTable LayChiTietDonHang(int orderId)
        {
            return orderDAL.LayChiTietDonHang(orderId);
        }

        public DataTable LayDonHangTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            return orderDAL.LayDonHangTheoNgay(tuNgay, denNgay);
        }

        /// <summary>
        /// Tạo đơn hàng hoàn chỉnh (header + các dòng chi tiết) với Transaction.
        /// Trả về OrderID nếu thành công, -1 nếu thất bại (hết hàng, lỗi data).
        /// </summary>
        public int TaoDonHang(OrderDTO donHang, List<OrderDetailDTO> danhSachChiTiet)
        {
            if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
                return -1;

            donHang.OrderCode   = orderDAL.SinhMaDonHang();
            donHang.OrderStatus = "Hoàn thành";

            // Thay vì loop gọi từng cái dễ bị nửa vời, ta gọi thẳng hàm Transaction
            return orderDAL.TaoDonHangGiaoDich(donHang, danhSachChiTiet);
        }

        public bool HuyDonHang(int orderId)
        {
            return orderDAL.HuyDonHang(orderId);
        }

        public string SinhMaDonHang()
        {
            return orderDAL.SinhMaDonHang();
        }

        public OrderDTO? LayDonHangTheoID(int orderId)
        {
            return orderDAL.LayDonHangTheoID(orderId);
        }

        public DataTable TimKiemDonHang(string tuKhoa)
        {
            return orderDAL.TimKiemDonHang(tuKhoa);
        }
    }
}
