using System.Collections.ObjectModel;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;

namespace Restaurant.Models.BusinessLogicLayer;

public static class AllergenBLL
{
    public static ObservableCollection<AllergenDTO> GetAllergens()
    {
        var allergens = new ObservableCollection<AllergenDTO>();
        foreach (var allergen in AllergenDAL.GetAllergens())
        {
            allergens.Add(allergen.ToDTO());
        }
        return allergens;
    }

    public static ObservableCollection<AllergenDTO> GetAllergensForProduct(int productId)
    {
        var allergens = new ObservableCollection<AllergenDTO>();
        foreach (var allergen in AllergenDAL.GetAllergensForProduct(productId))
        {
            allergens.Add(allergen.ToDTO());
        }
        return allergens;
    }

    public static AllergenDTO GetAllergenById(int id)
    {
        return AllergenDAL.GetAllergenById(id).ToDTO();
    }

    public static bool AddAllergen(AllergenDTO allergenDTO)
    {
        ArgumentNullException.ThrowIfNull(allergenDTO);
        ArgumentNullException.ThrowIfNull(allergenDTO.AllergenName);

        AllergenDAL.InsertAllergen(allergenDTO.ToEntity());
        return true;
    }

    public static bool EditAllergen(AllergenDTO allergenDTO)
    {
        ArgumentNullException.ThrowIfNull(allergenDTO);
        ArgumentNullException.ThrowIfNull(allergenDTO.Id);
        ArgumentNullException.ThrowIfNull(allergenDTO.AllergenName);

        AllergenDAL.UpdateAllergen(allergenDTO.ToEntity());
        return true;
    }

    public static bool DeleteAllergen(AllergenDTO allergenDTO)
    {
        ArgumentNullException.ThrowIfNull(allergenDTO);
        ArgumentNullException.ThrowIfNull(allergenDTO.Id);

        return AllergenDAL.DeleteAllergen(allergenDTO.ToEntity());
    }
}