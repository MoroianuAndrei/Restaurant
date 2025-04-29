using System.Collections.ObjectModel;
using Restaurant.Extensions.Mapping;
using Restaurant.Model.DataAccessLayer;
using Restaurant.Model.DataTransferLayer;

namespace Restaurant.Model.BusinessLogicLayer;

public static class UserBLL
{
    public static ObservableCollection<UserDTO> GetUsers()
    {
        var users = new ObservableCollection<UserDTO>();
        foreach (var user in UserDAL.GetUsers())
        {
            users.Add(user.ToDTO());
        }
        return users;
    }

    public static bool AddUser(UserDTO userDTO)
    {
        ArgumentNullException.ThrowIfNull(userDTO);
        ArgumentNullException.ThrowIfNull(userDTO.Username);
        ArgumentNullException.ThrowIfNull(userDTO.Password);
        ArgumentNullException.ThrowIfNull(userDTO.UserType);

        UserDAL.InsertUser(userDTO.ToEntity());
        return true;
    }

    public static bool EditUser(UserDTO userDTO)
    {
        ArgumentNullException.ThrowIfNull(userDTO);
        ArgumentNullException.ThrowIfNull(userDTO.Id);
        ArgumentNullException.ThrowIfNull(userDTO.Username);
        ArgumentNullException.ThrowIfNull(userDTO.Password);
        ArgumentNullException.ThrowIfNull(userDTO.UserType);

        UserDAL.UpdateUser(userDTO.ToEntity());
        return true;
    }

    public static bool DeleteUser(UserDTO userDTO)
    {
        ArgumentNullException.ThrowIfNull(userDTO);
        ArgumentNullException.ThrowIfNull(userDTO.Id);

        UserDAL.DeleteUser(userDTO.ToEntity());
        return true;
    }

    public static bool IsValidAdmin(string username, string password)
    {
        var admins = UserDAL.GetAllAdmins();
        return admins.Any(a => a.Username == username && a.Password == password);
    }

    public static bool IsValidCashier(string username, string password)
    {
        var cashiers = UserDAL.GetAllCashiers();
        return cashiers.Any(c => c.Username == username && c.Password == password);
    }
}