namespace Restaurant.Models.DataTransferLayer
{
    public class OrderItemDTO
    {
        public int OrderId { get; init; }
        public int? ProductId { get; init; }
        public int? MenuId { get; init; } // Adăugat noul câmp MenuId
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
        public bool IsMenu { get; init; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}