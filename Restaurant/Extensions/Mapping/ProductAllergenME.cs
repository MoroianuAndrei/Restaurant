using System.Collections.ObjectModel;
using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class ProductAllergenME
{
    // Method to convert collection of AllergenDTO to ObservableCollection<AllergenViewModel>
    public static ObservableCollection<AllergenViewModel> ToViewModelCollection(this ObservableCollection<AllergenDTO> allergenDTOs)
    {
        var result = new ObservableCollection<AllergenViewModel>();

        if (allergenDTOs != null)
        {
            foreach (var allergenDTO in allergenDTOs)
            {
                result.Add(allergenDTO.ToViewModel());
            }
        }

        return result;
    }

    // Method to convert a collection of Allergen entities to ObservableCollection<AllergenDTO>
    public static ObservableCollection<AllergenDTO> ToDTOCollection(this ObservableCollection<Allergen> allergens)
    {
        var result = new ObservableCollection<AllergenDTO>();

        if (allergens != null)
        {
            foreach (var allergen in allergens)
            {
                result.Add(allergen.ToDTO());
            }
        }

        return result;
    }
}