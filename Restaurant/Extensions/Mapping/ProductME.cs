using System.Collections.ObjectModel;
using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class ProductME
{
    public static ProductDTO ToDTO(this Product product)
    {
        return new ProductDTO
        {
            Id = product.ProductId,
            ProductName = product.ProductName,
            Price = product.Price,
            PortionQuantity = product.PortionQuantity,
            MeasurementUnit = product.MeasurementUnit,
            TotalQuantity = product.TotalQuantity,
            Category = product.Category?.ToDTO(),
            IsMenu = product.IsMenu,
            ImagePath = product.ImagePath,
            Allergens = product.Allergens != null ? new ObservableCollection<Allergen>(product.Allergens) : null
        };
    }

    public static ProductDTO ToDTO(this ProductViewModel productViewModel)
    {
        return new ProductDTO
        {
            Id = productViewModel.Id,
            ProductName = productViewModel.ProductName,
            Price = productViewModel.Price,
            PortionQuantity = productViewModel.PortionQuantity,
            MeasurementUnit = productViewModel.MeasurementUnit,
            TotalQuantity = productViewModel.TotalQuantity,
            Category = productViewModel.Category.ToDTO(),
            IsMenu = productViewModel.IsMenu,
            ImagePath = productViewModel.ImagePath,
            Allergens = productViewModel.Allergens != null ? new ObservableCollection<Allergen>(productViewModel.Allergens.ToList()) : null
        };
    }

    public static Product ToEntity(this ProductDTO productDTO)
    {
        return new Product
        {
            ProductId = productDTO.Id,
            ProductName = productDTO.ProductName ?? "",
            Price = productDTO.Price,
            PortionQuantity = productDTO.PortionQuantity,
            MeasurementUnit = productDTO.MeasurementUnit ?? "",
            TotalQuantity = productDTO.TotalQuantity,
            Category = productDTO.Category?.ToEntity(),
            IsMenu = productDTO.IsMenu,
            ImagePath = productDTO.ImagePath,
            Allergens = productDTO.Allergens != null ? productDTO.Allergens.ToList() : new List<Allergen>()
        };
    }

    public static ProductViewModel ToViewModel(this ProductDTO productDTO)
    {
        return new ProductViewModel
        {
            Id = productDTO.Id,
            ProductName = productDTO.ProductName ?? "",
            Price = productDTO.Price,
            PortionQuantity = productDTO.PortionQuantity,
            MeasurementUnit = productDTO.MeasurementUnit ?? "",
            TotalQuantity = productDTO.TotalQuantity,
            Category = productDTO.Category?.ToViewModel() ?? new CategoryViewModel(),
            IsMenu = productDTO.IsMenu,
            ImagePath = productDTO.ImagePath,
            Allergens = productDTO.Allergens?.ToViewModel()
        };
    }
}