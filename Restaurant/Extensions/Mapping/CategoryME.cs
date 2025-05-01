using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class CategoryME
{
    public static CategoryDTO ToDTO(this Category category)
    {
        return new CategoryDTO
        {
            Id = category.CategoryId,
            CategoryName = category.CategoryName,
            Description = category.Description
        };
    }

    public static CategoryDTO ToDTO(this CategoryViewModel categoryViewModel)
    {
        return new CategoryDTO
        {
            Id = categoryViewModel.Id,
            CategoryName = categoryViewModel.CategoryName,
            Description = categoryViewModel.Description
        };
    }

    public static Category ToEntity(this CategoryDTO categoryDTO)
    {
        return new Category
        {
            CategoryId = categoryDTO.Id,
            CategoryName = categoryDTO.CategoryName ?? "",
            Description = categoryDTO.Description
        };
    }

    public static CategoryViewModel ToViewModel(this CategoryDTO categoryDTO)
    {
        return new CategoryViewModel
        {
            Id = categoryDTO.Id,
            CategoryName = categoryDTO.CategoryName ?? "",
            Description = categoryDTO.Description ?? ""
        };
    }
}