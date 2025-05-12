using System.Collections.ObjectModel;
using System.Windows.Controls.Ribbon.Primitives;
using System.Windows.Input;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.Views.AdminItemEditPages;
using Restaurant.Views.AdminItemPageViews;
using Wpf.Ui.Controls;

namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels;

public class MenuPageViewModel : BaseViewModel
{
    public ObservableCollection<MenuViewModel> Menus { get; set; }
        = new(MenuBLL.GetMenus().Select(m => m.ToViewModel()));

    public ICommand AddNewCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand RemoveCommand { get; }

    public MenuPageViewModel()
    {
        foreach(var menu in Menus)
        {
            menu.MenuItems = MenuItemBLL.GetMenuItemsByMenuId(menu.Id).ToViewModelCollection();
        }

        AddNewCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not MenuPage currentPage)
            {
                return;
            }

            var menuEditPage = new MenuEditPage();

            currentPage.NavigationService?.Navigate(menuEditPage);
        });

        EditCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not object[] values) return;

            if (values[0] is not MenuViewModel menu || values[1] is not MenuPage currentPage)
            {
                return;
            }

            var menuEditPage = new MenuEditPage(menu);

            currentPage.NavigationService?.Navigate(menuEditPage);
        });

        RemoveCommand = new RelayCommand<object>(Remove);
    }

    private void Remove(object? obj)
    {
        if (obj is not MenuViewModel menu)
        {
            return;
        }

        var dialog = new MessageBox
        {
            Title = "Confirmation",
            Content = "Are you sure you want to delete this menu?",
            PrimaryButtonText = "Yes",
            CloseButtonText = "No"
        };

        var result = dialog.ShowDialogAsync().Result;

        if (result != MessageBoxResult.Primary) return;

        if (MenuBLL.DeleteMenu(menu.ToDTO()))
        {
            Menus.Remove(menu);
        }
    }
}