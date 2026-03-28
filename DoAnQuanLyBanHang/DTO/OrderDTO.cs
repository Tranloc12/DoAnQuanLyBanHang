using System;

namespace DoAnQuanLyBanHang.DTO
{
    public class OrderDTO
    {
        // Mã
        public int     OrderID    { get; set; }
        public string  OrderCode  { get; set; } = string.Empty;
        public int?    CustomerID { get; set; }
        public int     UserID     { get; set; }

        // Tên (join từ bảng khác)
        public string CustomerName { get; set; } = string.Empty;
        public string UserName     { get; set; } = string.Empty;

        // Thông tin đơn hàng
        public DateTime OrderDate     { get; set; }
        public decimal  TotalAmount   { get; set; }
        public decimal  Discount      { get; set; }
        public decimal  FinalAmount   { get; set; }
        public string   PaymentMethod { get; set; } = "Tiền mặt";  // "Tiền mặt", "Thẻ", "Chuyển khoản"
        public string   OrderStatus   { get; set; } = "Hoàn thành";  // "Hoàn thành", "Hủy"
        public string   Notes         { get; set; } = string.Empty;
    }

    public class OrderDetailDTO
    {
        public int     OrderDetailID { get; set; }
        public int     OrderID       { get; set; }
        public int     ProductID     { get; set; }
        public string  ProductCode   { get; set; } = string.Empty;
        public string  ProductName   { get; set; } = string.Empty;
        public int     Quantity      { get; set; }
        public decimal UnitPrice     { get; set; }
        public decimal LineTotal     => Quantity * UnitPrice;
    }
}