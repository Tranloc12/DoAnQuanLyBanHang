using System;

namespace DTO_QuanLy
{
    public class InventoryLogDTO
    {
        public int LogID { get; set; }
        public int ProductID { get; set; }
        public int? OrderID { get; set; } 
        public string ChangeType { get; set; } = string.Empty;
        public int QuantityChange { get; set; }
        public DateTime LogDate { get; set; } = DateTime.Now;
    }
}
