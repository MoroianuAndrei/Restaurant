using System.Windows;
using System.Windows.Input;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.Models.DataTransferLayer;
using Restaurant.Services;
using Restaurant.Views.PageViews;
using Wpf.Ui.Input;
using Wpf.Ui.Controls;
using System.Windows.Controls;

namespace Restaurant.ViewModels.PageViewModels;

public class LoginPageViewModel : BaseViewModel
{
    public ICommand LoginCommand { get; }
    public ICommand NavigateToSignInCommand { get; }
    public ICommand EnterAsGuestCommand { get; }

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
            HasError = !string.IsNullOrEmpty(value);
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
        NavigateToSignInCommand = new RelayCommand<object>(NavigateToSignIn);
        EnterAsGuestCommand = new RelayCommand<object>(EnterAsGuest);
    }

    private void Login(object? obj)
    {
        if (Email == "" || Password == "")
        {
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

    private void NavigateToSignIn(object? obj)
    {
        if (obj is not Page page) return;

        page.NavigationService?.Navigate(new SignInPage());
    }

    private void EnterAsGuest(object? obj)
    {
        if (obj is not Page page) return;

        // Creăm un utilizator temporar de tip client/guest
        var guestUser = new UserDTO
        {
            Id = -1,
            FirstName = "Guest",
            LastName = "User",
            Email = "guest@restaurant.com",
            UserType = "Client"
        };

        UserSession.Instance.SetUser(guestUser.ToViewModel());
        page.NavigationService?.Navigate(new Blank());
    }
}