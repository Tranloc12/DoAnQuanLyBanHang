namespace DoAnQuanLyBanHang.DTO
{
    public class CustomerDTO
    {
        public int     CustomerID   { get; set; }
        public string  CustomerName { get; set; }
        public string  Phone        { get; set; }
        public string  Email        { get; set; }
        public string  Address      { get; set; }
        public decimal TotalSpent   { get; set; }
        public int     LoyaltyPoints { get; set; }
    }
}