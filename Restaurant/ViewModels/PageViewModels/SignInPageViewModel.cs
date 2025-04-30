using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.Models.DataTransferLayer;
using Restaurant.Views.PageViews;
using Wpf.Ui.Controls;
using Wpf.Ui.Input;

namespace Restaurant.ViewModels.PageViewModels;

public class SignInPageViewModel : BaseViewModel
{
    private string _firstName = "";
    private string _lastName = "";
    private string _email = "";
    private string _phone = "";
    private string _deliveryAddress = "";
    private string _password = "";
    private string _confirmPassword = "";
    private string _errorMessage = "";
    private bool _hasError;

    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged();
        }
    }

    public string DeliveryAddress
    {
        get => _deliveryAddress;
        set
        {
            _deliveryAddress = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            _confirmPassword = value;
            OnPropertyChanged();
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged();
            HasError = !string.IsNullOrEmpty(value);
        }
    }

    public bool HasError
    {
        get => _hasError;
        set
        {
            _hasError = value;
            OnPropertyChanged();
        }
    }

    public ICommand SignInCommand { get; }
    public ICommand BackToLoginCommand { get; }

    public SignInPageViewModel()
    {
        SignInCommand = new RelayCommand<object>(OnSignIn);
        BackToLoginCommand = new RelayCommand<object>(OnBackToLogin);
    }

    private void OnSignIn(object? parameter)
    {
        // Validare
        if (string.IsNullOrWhiteSpace(FirstName))
        {
            ErrorMessage = "First name is required";
            return;
        }

        if (string.IsNullOrWhiteSpace(LastName))
        {
            ErrorMessage = "Last name is required";
            return;
        }

        if (string.IsNullOrWhiteSpace(Email))
        {
            ErrorMessage = "Email is required";
            return;
        }

        if (string.IsNullOrWhiteSpace(Phone))
        {
            ErrorMessage = "Phone is required";
            return;
        }

        if (string.IsNullOrWhiteSpace(DeliveryAddress))
        {
            ErrorMessage = "Delivery address is required";
            return;
        }

        if (string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Password is required";
            return;
        }

        if (Password != ConfirmPassword)
        {
            ErrorMessage = "Passwords do not match";
            return;
        }

        // Verificăm dacă există deja un utilizator cu acest email
        var existingUsers = UserBLL.GetUsers();
        if (existingUsers.Any(u => u.Email == Email))
        {
            ErrorMessage = "An account with this email already exists";
            return;
        }

        // Creăm noul utilizator DTO
        var userDTO = new UserDTO
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Phone = Phone,
            DeliveryAddress = DeliveryAddress,
            Password = Password,
            UserType = "Client" // Setăm tipul utilizatorului ca Client
        };

        // Încercăm să inserăm utilizatorul în baza de date
        if (UserBLL.AddUser(userDTO))
        {
            System.Windows.MessageBox.Show("Account created successfully!");

            // Navigare înapoi la pagina de login
            if (parameter is Page page)
            {
                page.NavigationService?.Navigate(new LoginPage());
            }
        }
        else
        {
            ErrorMessage = "Failed to create account.";
        }
    }

    private void OnBackToLogin(object? parameter)
    {
        if (parameter is Page page)            
        {
            page.NavigationService?.Navigate(new LoginPage());
        }
    }
}