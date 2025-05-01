using System.Collections.ObjectModel;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;

namespace Restaurant.Models.BusinessLogicLayer;

public static class ProductImageBLL
{
    public static ObservableCollection<ProductImageDTO> GetProductImages()
    {
        var productImages = new ObservableCollection<ProductImageDTO>();
        foreach (var productImage in ProductImageDAL.GetProductImages())
        {
            productImages.Add(productImage.ToDTO());
        }
        return productImages;
    }

    public static ProductImageDTO? GetProductImageById(int id)
    {
        var productImage = ProductImageDAL.GetProductImageById(id);
        return productImage.ImageId > 0 ? productImage.ToDTO() : null;
    }

    public static ObservableCollection<ProductImageDTO> GetProductImagesByProductId(int productId)
    {
        var productImages = new ObservableCollection<ProductImageDTO>();
        foreach (var productImage in ProductImageDAL.GetProductImagesByProductId(productId))
        {
            productImages.Add(productImage.ToDTO());
        }
        return productImages;
    }

    public static bool AddProductImage(ProductImageDTO productImageDTO)
    {
        ArgumentNullException.ThrowIfNull(productImageDTO);
        ArgumentNullException.ThrowIfNull(productImageDTO.ImagePath);

        return ProductImageDAL.InsertProductImage(productImageDTO.ToEntity());
    }

    public static bool EditProductImage(ProductImageDTO productImageDTO)
    {
        ArgumentNullException.ThrowIfNull(productImageDTO);
        ArgumentNullException.ThrowIfNull(productImageDTO.ImagePath);

        return ProductImageDAL.UpdateProductImage(productImageDTO.ToEntity());
    }

    public static bool DeleteProductImage(ProductImageDTO productImageDTO)
    {
        ArgumentNullException.ThrowIfNull(productImageDTO);

        return ProductImageDAL.DeleteProductImage(productImageDTO.ToEntity());
    }

    public static bool DeleteProductImagesByProductId(int productId)
    {
        return ProductImageDAL.DeleteProductImagesByProductId(productId);
    }
}