using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class AllergenME
{
    public static AllergenDTO ToDTO(this Allergen allergen)
    {
        return new AllergenDTO
        {
            Id = allergen.AllergenId,
            AllergenName = allergen.AllergenName,
            Description = allergen.Description
        };
    }

    public static AllergenDTO ToDTO(this AllergenViewModel allergenViewModel)
    {
        return new AllergenDTO
        {
            Id = allergenViewModel.Id,
            AllergenName = allergenViewModel.AllergenName,
            Description = allergenViewModel.Description
        };
    }

    public static Allergen ToEntity(this AllergenDTO allergenDTO)
    {
        return new Allergen
        {
            AllergenId = allergenDTO.Id,
            AllergenName = allergenDTO.AllergenName ?? "",
            Description = allergenDTO.Description
        };
    }

    public static AllergenViewModel ToViewModel(this AllergenDTO allergenDTO)
    {
        return new AllergenViewModel
        {
            Id = allergenDTO.Id,
            AllergenName = allergenDTO.AllergenName ?? "",
            Description = allergenDTO.Description ?? ""
        };
    }
}