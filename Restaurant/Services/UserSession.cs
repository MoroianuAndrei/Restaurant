using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Services;

public class UserSession
{
    private static UserSession? _instance;
    private static readonly object Lock = new object();

    public UserViewModel? LoggedInUser { get; private set; }

    private UserSession() { }

    public static UserSession Instance
    {
        get
        {
            lock (Lock)
            {
                return _instance ??= new UserSession();
            }
        }
    }

    public void SetUser(UserViewModel user)
    {
        LoggedInUser = user;
    }

    public void ClearUser()
    {
        LoggedInUser = null;
    }
}