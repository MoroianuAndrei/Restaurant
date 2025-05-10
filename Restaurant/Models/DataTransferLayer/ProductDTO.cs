using System.Collections.ObjectModel;
using Restaurant.Models.EntityLayer;

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
        public CategoryDTO? Category { get; init; }
        public ObservableCollection<Allergen>? Allergens {  get; init; }
        public bool? IsMenu { get; init; }
        public string? ImagePath { get; init; }
    }
}