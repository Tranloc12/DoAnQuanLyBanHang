namespace DoAnQuanLyBanHang.DTO
{
    public class UserDTO
    {
        public int    UserID    { get; set; }
        public string UserName  { get; set; } = string.Empty;
        public string FullName  { get; set; } = string.Empty;
        public string Email     { get; set; } = string.Empty;
        public string Phone     { get; set; } = string.Empty;
        public string Role      { get; set; } = string.Empty;   // "Admin" hoặc "Staff"
        public bool   IsActive  { get; set; }
    }
}