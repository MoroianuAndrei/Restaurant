using System.Windows.Input;
using Restaurant.Extensions.Mapping;
using Restaurant.Model.BusinessLogicLayer;
using Restaurant.Model.DataTransferLayer;
using Restaurant.Services;
using Restaurant.Views.PageViews;
//using Restaurant.Views.PageViews.AdminPageViews;
//using Restaurant.Views.PageViews.CashierPageViews;
using Wpf.Ui.Input;

namespace Restaurant.ViewModels.PageViewModels;

public class LoginPageViewModel : BaseViewModel
{
    public ICommand LoginCommand { get; }
    public string Username { get; set; } = "";
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
        if (Username == "" || Password == "")
        {
            ErrorMessage = "Please enter username and password";
            HasError = true;
            return;
        }

        if (!UserBLL.IsValidAdmin(Username, Password) && !UserBLL.IsValidCashier(Username, Password))
        {
            ErrorMessage = "Invalid username or password";
            HasError = true;
            return;
        }

        if (obj is not LoginPage page) return;

        if (UserBLL.IsValidAdmin(Username, Password))
        {
            page.NavigationService?.Navigate(new AdminPage());
        }
        else
        {
            var user = (UserBLL.GetUsers().FirstOrDefault(u => u.Username == Username) ?? new UserDTO()).ToViewModel();
            UserSession.Instance.SetUser(user);
            page.NavigationService?.Navigate(new CashierPage());
        }
    }
}