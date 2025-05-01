using System.Collections.ObjectModel;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;

namespace Restaurant.Models.BusinessLogicLayer;

public static class MenuItemBLL
{
    public static ObservableCollection<MenuItemDTO> GetMenuItems()
    {
        var menuItems = new ObservableCollection<MenuItemDTO>();
        foreach (var menuItem in MenuItemDAL.GetMenuItems())
        {
            menuItems.Add(menuItem.ToDTO());
        }
        return menuItems;
    }

    public static ObservableCollection<MenuItemDTO> GetMenuItemsByMenuId(int menuId)
    {
        var menuItems = new ObservableCollection<MenuItemDTO>();
        foreach (var menuItem in MenuItemDAL.GetMenuItemsByMenuId(menuId))
        {
            menuItems.Add(menuItem.ToDTO());
        }
        return menuItems;
    }

    public static bool AddMenuItem(MenuItemDTO menuItemDTO)
    {
        ArgumentNullException.ThrowIfNull(menuItemDTO);

        MenuItemDAL.InsertMenuItem(menuItemDTO.ToEntity());
        return true;
    }

    public static bool EditMenuItem(MenuItemDTO menuItemDTO)
    {
        ArgumentNullException.ThrowIfNull(menuItemDTO);

        MenuItemDAL.UpdateMenuItem(menuItemDTO.ToEntity());
        return true;
    }

    public static bool DeleteMenuItem(MenuItemDTO menuItemDTO)
    {
        ArgumentNullException.ThrowIfNull(menuItemDTO);

        MenuItemDAL.DeleteMenuItem(menuItemDTO.ToEntity());
        return true;
    }
}