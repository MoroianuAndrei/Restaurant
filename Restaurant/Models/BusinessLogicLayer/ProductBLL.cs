using System.Collections.ObjectModel;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;

namespace Restaurant.Models.BusinessLogicLayer;

public static class ProductBLL
{
    public static ObservableCollection<ProductDTO> GetProducts()
    {
        var products = new ObservableCollection<ProductDTO>();
        foreach (var product in ProductDAL.GetProducts())
        {
            products.Add(product.ToDTO());
        }
        return products;
    }

    public static ProductDTO? GetProductById(int id)
    {
        var product = ProductDAL.GetProductById(id);
        return product.ProductId > 0 ? product.ToDTO() : null;
    }

    public static bool AddProduct(ProductDTO productDTO)
    {
        ArgumentNullException.ThrowIfNull(productDTO);
        ArgumentNullException.ThrowIfNull(productDTO.ProductName);
        ArgumentNullException.ThrowIfNull(productDTO.MeasurementUnit);

        return ProductDAL.InsertProduct(productDTO.ToEntity());
    }

    public static bool EditProduct(ProductDTO productDTO)
    {
        ArgumentNullException.ThrowIfNull(productDTO);
        ArgumentNullException.ThrowIfNull(productDTO.ProductName);
        ArgumentNullException.ThrowIfNull(productDTO.MeasurementUnit);

        return ProductDAL.UpdateProduct(productDTO.ToEntity());
    }

    public static bool DeleteProduct(ProductDTO productDTO)
    {
        ArgumentNullException.ThrowIfNull(productDTO);

        return ProductDAL.DeleteProduct(productDTO.ToEntity());
    }

    public static ObservableCollection<ProductDTO> GetMenuProducts()
    {
        var products = new ObservableCollection<ProductDTO>();
        foreach (var product in ProductDAL.GetMenuProducts())
        {
            products.Add(product.ToDTO());
        }
        return products;
    }

    public static ObservableCollection<ProductDTO> GetNonMenuProducts()
    {
        var products = new ObservableCollection<ProductDTO>();
        foreach (var product in ProductDAL.GetNonMenuProducts())
        {
            products.Add(product.ToDTO());
        }
        return products;
    }

    public static ObservableCollection<ProductDTO> GetProductsByCategory(int categoryId)
    {
        var products = new ObservableCollection<ProductDTO>();
        foreach (var product in ProductDAL.GetProductsByCategory(categoryId))
        {
            products.Add(product.ToDTO());
        }
        return products;
    }
}