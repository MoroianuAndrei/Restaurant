using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class MenuItemME
{
    public static MenuItemDTO ToDTO(this MenuItem menuItem)
    {
        return new MenuItemDTO
        {
            MenuId = menuItem.MenuId,
            ProductId = menuItem.ProductId,
            Quantity = menuItem.Quantity
        };
    }

    public static MenuItemDTO ToDTO(this MenuItemViewModel menuItemViewModel)
    {
        return new MenuItemDTO
        {
            MenuId = menuItemViewModel.MenuId,
            ProductId = menuItemViewModel.ProductId,
            Quantity = menuItemViewModel.Quantity
        };
    }

    public static MenuItem ToEntity(this MenuItemDTO menuItemDTO)
    {
        return new MenuItem
        {
            MenuId = menuItemDTO.MenuId,
            ProductId = menuItemDTO.ProductId,
            Quantity = menuItemDTO.Quantity
        };
    }

    public static MenuItemViewModel ToViewModel(this MenuItemDTO menuItemDTO)
    {
        return new MenuItemViewModel
        {
            MenuId = menuItemDTO.MenuId,
            ProductId = menuItemDTO.ProductId,
            Quantity = menuItemDTO.Quantity
        };
    }
}