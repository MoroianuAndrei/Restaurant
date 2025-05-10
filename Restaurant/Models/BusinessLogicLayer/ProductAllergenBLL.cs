using System.Collections.ObjectModel;
using System.Windows;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;

namespace Restaurant.Models.BusinessLogicLayer;

public static class ProductAllergenBLL
{
    public static ObservableCollection<AllergenDTO> GetAllergensByProductId(int productId)
    {
        // Call the data access layer to get allergens for this product
        var allergens = ProductAllergenDAL.GetAllergensByProductId(productId);

        // Convert entities to DTOs
        var allergenDTOs = new ObservableCollection<AllergenDTO>();
        foreach (var allergen in allergens)
        {
            allergenDTOs.Add(allergen.ToDTO());
        }

        return allergenDTOs;
    }

    public static bool AssignAllergenToProduct(int productId, int allergenId)
    {
        return ProductAllergenDAL.AssignAllergenToProduct(productId, allergenId);
    }

    public static bool RemoveAllergenFromProduct(int productId, int allergenId)
    {
        return ProductAllergenDAL.RemoveAllergenFromProduct(productId, allergenId);
    }
}