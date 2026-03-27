using System;
using System.Collections.Generic;
using System.Data;
using DoAnQuanLyBanHang.DAL;
using DoAnQuanLyBanHang.DTO;

namespace DoAnQuanLyBanHang.BUS
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
        /// Tạo đơn hàng hoàn chỉnh (header + các dòng chi tiết).
        /// Trả về OrderID nếu thành công, -1 nếu thất bại.
        /// </summary>
        public int TaoDonHang(OrderDTO donHang, List<OrderDetailDTO> danhSachChiTiet)
        {
            if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
                return -1;

            donHang.OrderCode   = orderDAL.SinhMaDonHang();
            donHang.OrderStatus = "Hoàn thành";

            int orderId = orderDAL.TaoDonHang(donHang);
            if (orderId <= 0) return -1;

            foreach (var chiTiet in danhSachChiTiet)
            {
                chiTiet.OrderID = orderId;
                orderDAL.ThemChiTietDonHang(chiTiet);
            }
            return orderId;
        }

        public bool HuyDonHang(int orderId)
        {
            return orderDAL.HuyDonHang(orderId);
        }

        public string SinhMaDonHang()
        {
            return orderDAL.SinhMaDonHang();
        }
    }
}
