﻿using System.Collections.ObjectModel;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;

namespace Restaurant.Models.BusinessLogicLayer;

public static class CategoryBLL
{
    public static ObservableCollection<CategoryDTO> GetCategories()
    {
        var categories = new ObservableCollection<CategoryDTO>();
        foreach (var category in CategoryDAL.GetCategories())
        {
            categories.Add(category.ToDTO());
        }
        return categories;
    }

    public static CategoryDTO GetCategoryById(int id)
    {
        return CategoryDAL.GetCategoryById(id).ToDTO();
    }

    public static bool AddCategory(CategoryDTO categoryDTO)
    {
        ArgumentNullException.ThrowIfNull(categoryDTO);
        ArgumentNullException.ThrowIfNull(categoryDTO.CategoryName);

        CategoryDAL.InsertCategory(categoryDTO.ToEntity());
        return true;
    }

    public static bool EditCategory(CategoryDTO categoryDTO)
    {
        ArgumentNullException.ThrowIfNull(categoryDTO);
        ArgumentNullException.ThrowIfNull(categoryDTO.Id);
        ArgumentNullException.ThrowIfNull(categoryDTO.CategoryName);

        CategoryDAL.UpdateCategory(categoryDTO.ToEntity());
        return true;
    }

    public static bool DeleteCategory(CategoryDTO categoryDTO)
    {
        ArgumentNullException.ThrowIfNull(categoryDTO);
        ArgumentNullException.ThrowIfNull(categoryDTO.Id);

        return CategoryDAL.DeleteCategory(categoryDTO.ToEntity());
    }

    // New methods to match what the ViewModel is trying to call
    public static ObservableCollection<CategoryDTO> GetAll()
    {
        return GetCategories();
    }

    public static CategoryDTO GetById(int id)
    {
        return GetCategoryById(id);
    }
}