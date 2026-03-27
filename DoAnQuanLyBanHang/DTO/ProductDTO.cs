namespace DoAnQuanLyBanHang.DTO
{
    public class ProductDTO
    {
        // Mã
        public int    ProductID   { get; set; }
        public string ProductCode { get; set; }
        public int    CategoryID  { get; set; }
        public int    SupplierID  { get; set; }

        // Tên
        public string ProductName  { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }

        // Thông tin giá & kho
        public decimal CostPrice   { get; set; }
        public decimal SellPrice   { get; set; }
        public int     Quantity    { get; set; }
        public int     MinQuantity { get; set; }
        public string  Unit        { get; set; }
        public bool    IsActive    { get; set; }

        // Thuộc tính tính toán
        public decimal LoiNhuan  => SellPrice - CostPrice;
        public bool    SapHetHang => Quantity <= MinQuantity;
    }
}