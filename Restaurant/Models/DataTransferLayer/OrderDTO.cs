namespace Restaurant.Models.DataTransferLayer
{
    public class OrderDTO
    {
        public int Id { get; init; }
        public string? OrderCode { get; init; }
        public int UserId { get; init; }
        public DateTime OrderDate { get; init; }
        public string? Status { get; init; }
        public DateTime? EstimatedDeliveryTime { get; init; }
        public decimal SubtotalAmount { get; init; }
        public decimal DiscountAmount { get; init; }
        public decimal ShippingCost { get; init; }
        public decimal TotalAmount { get; init; }
    }
}