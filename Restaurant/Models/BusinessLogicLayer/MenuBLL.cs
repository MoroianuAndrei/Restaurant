using System.Collections.ObjectModel;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;

namespace Restaurant.Models.BusinessLogicLayer;

public static class MenuBLL
{
    public static ObservableCollection<MenuDTO> GetMenus()
    {
        var menus = new ObservableCollection<MenuDTO>();
        foreach (var menu in MenuDAL.GetMenus())
        {
            menus.Add(menu.ToDTO());
        }
        return menus;
    }

    public static MenuDTO GetMenuById(int menuId)
    {
        return MenuDAL.GetMenuById(menuId).ToDTO();
    }

    public static bool AddMenu(MenuDTO menuDTO)
    {
        ArgumentNullException.ThrowIfNull(menuDTO);
        ArgumentNullException.ThrowIfNull(menuDTO.Name);

        return MenuDAL.InsertMenu(menuDTO.ToEntity());
    }

    public static bool EditMenu(MenuDTO menuDTO)
    {
        ArgumentNullException.ThrowIfNull(menuDTO);
        ArgumentNullException.ThrowIfNull(menuDTO.Id);
        ArgumentNullException.ThrowIfNull(menuDTO.Name);

        return MenuDAL.UpdateMenu(menuDTO.ToEntity());
    }

    public static bool DeleteMenu(MenuDTO menuDTO)
    {
        ArgumentNullException.ThrowIfNull(menuDTO);
        ArgumentNullException.ThrowIfNull(menuDTO.Id);

        return MenuDAL.DeleteMenu(menuDTO.ToEntity());
    }

    // New methods to match what the ViewModel is trying to call
    public static ObservableCollection<MenuDTO> GetAll()
    {
        return GetMenus();
    }

    public static MenuDTO GetById(int menuId)
    {
        return GetMenuById(menuId);
    }
}