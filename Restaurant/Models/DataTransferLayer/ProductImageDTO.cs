namespace Restaurant.Models.DataTransferLayer
{
    public class ProductImageDTO
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public string? ImagePath { get; init; }
        public string? ImageDescription { get; init; }
        public string? ProductName { get; init; }
    }
}