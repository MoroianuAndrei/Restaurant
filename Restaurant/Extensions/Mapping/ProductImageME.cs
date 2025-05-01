using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class ProductImageME
{
    public static ProductImageDTO ToDTO(this ProductImage productImage)
    {
        return new ProductImageDTO
        {
            Id = productImage.ImageId,
            ProductId = productImage.ProductId,
            ImagePath = productImage.ImagePath,
            ImageDescription = productImage.ImageDescription,
            ProductName = productImage.Product?.ProductName
        };
    }

    public static ProductImageDTO ToDTO(this ProductImageViewModel productImageViewModel)
    {
        return new ProductImageDTO
        {
            Id = productImageViewModel.Id,
            ProductId = productImageViewModel.ProductId,
            ImagePath = productImageViewModel.ImagePath,
            ImageDescription = productImageViewModel.ImageDescription,
            ProductName = productImageViewModel.ProductName
        };
    }

    public static ProductImage ToEntity(this ProductImageDTO productImageDTO)
    {
        return new ProductImage
        {
            ImageId = productImageDTO.Id,
            ProductId = productImageDTO.ProductId,
            ImagePath = productImageDTO.ImagePath ?? "",
            ImageDescription = productImageDTO.ImageDescription
        };
    }

    public static ProductImageViewModel ToViewModel(this ProductImageDTO productImageDTO)
    {
        return new ProductImageViewModel
        {
            Id = productImageDTO.Id,
            ProductId = productImageDTO.ProductId,
            ImagePath = productImageDTO.ImagePath ?? "",
            ImageDescription = productImageDTO.ImageDescription ?? "",
            ProductName = productImageDTO.ProductName ?? ""
        };
    }
}