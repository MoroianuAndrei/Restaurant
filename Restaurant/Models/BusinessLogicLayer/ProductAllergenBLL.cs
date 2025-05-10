using System.Collections.ObjectModel;
using System.Windows;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;
using Restaurant.ViewModels.ObjectViewModels;

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

    // New method to sync allergens for a product
    public static bool AssignAllergenToProduct(int productId, ObservableCollection<AllergenViewModel> allergens)
    {
        if (productId <= 0)
            return false;

        try
        {
            // First get current allergens for this product
            var currentAllergens = ProductAllergenDAL.GetAllergensByProductId(productId);
            var currentAllergenIds = currentAllergens.Select(a => a.AllergenId).ToList();

            // Get new allergen IDs from the view models
            var newAllergenIds = allergens.Select(a => a.Id).ToList();

            // Find allergens to remove (in current but not in new)
            var allergensToRemove = currentAllergenIds.Except(newAllergenIds).ToList();

            // Find allergens to add (in new but not in current)
            var allergensToAdd = newAllergenIds.Except(currentAllergenIds).ToList();

            // Process removals
            foreach (var allergenId in allergensToRemove)
            {
                RemoveAllergenFromProduct(productId, allergenId);
            }

            // Process additions
            foreach (var allergenId in allergensToAdd)
            {
                AssignAllergenToProduct(productId, allergenId);
            }

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error syncing allergens: {ex.Message}");
            return false;
        }
    }
}