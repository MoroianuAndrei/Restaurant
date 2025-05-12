using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

namespace Restaurant.Views.AdminItemEditPages;

public partial class MenuEditPage
{
    public MenuEditPage()
    {
        InitializeComponent();
    }

    public MenuEditPage(MenuViewModel menu)
    {
        InitializeComponent();
        DataContext = new MenuEditPageViewModel(menu);
    }
}