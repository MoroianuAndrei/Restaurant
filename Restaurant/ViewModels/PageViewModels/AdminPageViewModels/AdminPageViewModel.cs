using System.Windows.Input;
using Restaurant.ViewModels.Commands;
using Restaurant.Views.PageViews;
using Restaurant.Views.PageViews.AdminPageViews;

namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels;

public class AdminPageViewModel : BaseViewModel
{
    public ICommand LogOutCommand { get; } = new RelayCommand<object?>(obj =>
    {
        if (obj is not AdminPage page)
        {
            return;
        }
        
        page.NavigationService?.Navigate(new LoginPage());
    });
    
    public ICommand NavigateToHomeCommand { get; } = new RelayCommand<object?>(obj =>
    {
        if (obj is not AdminPage page)
        {
            return;
        }
        
        var navigationView = page.NavigationView;
        
        navigationView.Navigate("Home");
    });
}