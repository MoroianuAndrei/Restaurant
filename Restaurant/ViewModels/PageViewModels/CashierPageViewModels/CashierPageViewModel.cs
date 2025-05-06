using System.Windows.Input;
using Restaurant.ViewModels.Commands;
using Restaurant.Views.PageViews;
using Restaurant.Views.PageViews.CashierPageViews;

namespace Restaurant.ViewModels.PageViewModels.CashierPageViewModels;

public class CashierPageViewModel : BaseViewModel
{
    public ICommand LogOutCommand { get; } = new RelayCommand<object?>(obj =>
    {
        if (obj is not CashierPage page) return;

        page.NavigationService?.Navigate(new LoginPage());
    });

    public ICommand NavigateToHomeCommand { get; } = new RelayCommand<object?>(obj =>
    {
        if (obj is not CashierPage page)
        {
            return;
        }

        var navigationView = page.CashierNavigationView;

        CashierHomePageViewModel.NavigationView = navigationView;
        CreateNewReceiptPageViewModel.NavigationView = navigationView;

        navigationView.Navigate("Home");
    });
}