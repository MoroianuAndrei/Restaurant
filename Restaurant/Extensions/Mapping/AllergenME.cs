using System.Collections.ObjectModel;
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
    public static ObservableCollection<AllergenViewModel> ToViewModel(this ObservableCollection<Allergen> allergens)
    {
        if (allergens == null)
            return null;

        var viewModels = new ObservableCollection<AllergenViewModel>();
        foreach (var allergen in allergens)
        {
            viewModels.Add(new AllergenViewModel
            {
                Id = allergen.AllergenId,
                AllergenName = allergen.AllergenName,
                Description = allergen.Description ?? ""
            });
        }
        return viewModels;
    }

    public static List<Allergen> ToList(this ObservableCollection<AllergenViewModel> allergenViewModels)
    {
        if (allergenViewModels == null)
            return new List<Allergen>();

        var entities = new List<Allergen>();
        foreach (var vm in allergenViewModels)
        {
            entities.Add(new Allergen
            {
                AllergenId = vm.Id,
                AllergenName = vm.AllergenName,
                Description = vm.Description
            });
        }
        return entities;
    }

}