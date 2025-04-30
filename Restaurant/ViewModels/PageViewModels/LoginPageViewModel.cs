using System.Windows;
using System.Windows.Input;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.Models.DataTransferLayer;
using Restaurant.Services;
using Restaurant.Views.PageViews;
//using Restaurant.Views.PageViews.AdminPageViews;
//using Restaurant.Views.PageViews.CashierPageViews;
using Wpf.Ui.Input;

namespace Restaurant.ViewModels.PageViewModels;

public class LoginPageViewModel : BaseViewModel
{
    public ICommand LoginCommand { get; }
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    private string? _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage ?? "";
        private set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    private bool _hasError;
    public bool HasError
    {
        get => _hasError;
        private set
        {
            _hasError = value;
            OnPropertyChanged();
        }
    }

    public LoginPageViewModel()
    {
        LoginCommand = new RelayCommand<object>(Login);
    }

    private void Login(object? obj)
    {
        if (Email == "" || Password == "")
        {
            MessageBox.Show(Email + " " + Password);
            ErrorMessage = "Please enter email and password";
            HasError = true;
            return;
        }

        if (!UserBLL.IsValidAdmin(Email, Password) && !UserBLL.IsValidCashier(Email, Password))
        {
            ErrorMessage = "Invalid email or password";
            HasError = true;
            return;
        }

        if (obj is not LoginPage page) return;

        if (UserBLL.IsValidAdmin(Email, Password))
        {
            page.NavigationService?.Navigate(new Blank());
        }
        else
        {
            var user = (UserBLL.GetUsers().FirstOrDefault(u => u.Email == Email) ?? new UserDTO()).ToViewModel();
            UserSession.Instance.SetUser(user);
            page.NavigationService?.Navigate(new Blank());
        }
    }
}