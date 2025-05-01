namespace Restaurant.Models.DataTransferLayer
{
    public class ProductDTO
    {
        public int Id { get; init; }
        public string? ProductName { get; init; }
        public decimal Price { get; init; }
        public decimal PortionQuantity { get; init; }
        public string? MeasurementUnit { get; init; }
        public decimal TotalQuantity { get; init; }
        public int CategoryId { get; init; }
        public bool IsMenu { get; init; }
        public string? CategoryName { get; init; }
    }
}