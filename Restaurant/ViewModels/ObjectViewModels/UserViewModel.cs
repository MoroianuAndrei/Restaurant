namespace Restaurant.ViewModels.ObjectViewModels;

public class UserViewModel : BaseViewModel
{
    private readonly int _id;
    public int Id
    {
        get => _id;
        init
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    private string? _firstName;
    public string FirstName
    {
        get => _firstName ?? "";
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }

    private string? _lastName;
    public string LastName
    {
        get => _lastName ?? "";
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }

    private string? _email;
    public string Email
    {
        get => _email ?? "";
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    private string? _phone;
    public string Phone
    {
        get => _phone ?? "";
        set
        {
            _phone = value;
            OnPropertyChanged();
        }
    }

    private string? _deliveryAddress;
    public string DeliveryAddress
    {
        get => _deliveryAddress ?? "";
        set
        {
            _deliveryAddress = value;
            OnPropertyChanged();
        }
    }

    private string? _password;
    public string Password
    {
        get => _password ?? "";
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    private string? _userType;
    public string UserType
    {
        get => _userType ?? "";
        set
        {
            _userType = value;
            OnPropertyChanged();
        }
    }
}