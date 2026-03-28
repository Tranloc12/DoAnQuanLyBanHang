namespace DoAnQuanLyBanHang.DTO
{
    public class CustomerDTO
    {
        public int     CustomerID   { get; set; }
        public string  CustomerName { get; set; } = string.Empty;
        public string  Phone        { get; set; } = string.Empty;
        public string  Email        { get; set; } = string.Empty;
        public string  Address      { get; set; } = string.Empty;
        public decimal TotalSpent   { get; set; }
        public int     LoyaltyPoints { get; set; }
    }
}