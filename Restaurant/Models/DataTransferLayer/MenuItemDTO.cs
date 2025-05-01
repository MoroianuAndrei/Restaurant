namespace Restaurant.Models.DataTransferLayer
{
    public class MenuItemDTO
    {
        public int MenuId { get; init; }
        public int ProductId { get; init; }
        public decimal Quantity { get; init; }
    }
}