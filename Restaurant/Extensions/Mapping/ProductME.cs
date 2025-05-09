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
            ImagePath = product.ImagePath
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
            ImagePath = productViewModel.ImagePath
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
            ImagePath = productDTO.ImagePath
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
            ImagePath = productDTO.ImagePath
        };
    }
}