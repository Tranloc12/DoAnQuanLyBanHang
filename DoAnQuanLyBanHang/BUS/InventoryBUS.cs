using System;
using System.Data;
using DoAnQuanLyBanHang.DAL;

namespace DoAnQuanLyBanHang.BUS
{
    public class InventoryBUS
    {
        private readonly InventoryDAL inventoryDAL = new InventoryDAL();

        public DataTable LayTonKho() => inventoryDAL.LayTonKho();

        public DataTable LayBanChay(DateTime tuNgay, DateTime denNgay, int topN = 10)
            => inventoryDAL.LayBanChay(tuNgay, denNgay, topN);

        public bool NhapKho(int productId, int soLuong)
        {
            if (soLuong <= 0) return false;
            return inventoryDAL.NhapKho(productId, soLuong);
        }
    }
}
