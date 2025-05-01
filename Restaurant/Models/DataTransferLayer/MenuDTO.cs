namespace Restaurant.Models.DataTransferLayer
{
    public class MenuDTO
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public decimal? Discount { get; init; }
    }
}