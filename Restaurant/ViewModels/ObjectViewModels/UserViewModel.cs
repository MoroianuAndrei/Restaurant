namespace Restaurant.ViewModels.ObjectViewModels;

public class UserViewModel : BaseViewModel
{
    private readonly int? _id;
    public int? Id
    {
        get => _id;
        init
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    private string? _username;
    public string Username
    {
        get => _username ?? "";
        set
        {
            _username = value;
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