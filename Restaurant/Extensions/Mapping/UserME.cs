using Restaurant.Model.DataTransferLayer;
using Restaurant.Model.EntityLayer;
using Restaurant.Model.EntityLayer.Enums;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class UserME
{
    public static UserDTO ToDTO(this User user)
    {
        return new UserDTO
        {
            Id = user.UserId,
            Username = user.Username,
            Password = user.Password,
            UserType = user.UserType.ToString()
        };
    }

    public static UserDTO ToDTO(this UserViewModel userViewModel)
    {
        return new UserDTO
        {
            Id = userViewModel.Id,
            Username = userViewModel.Username,
            Password = userViewModel.Password,
            UserType = userViewModel.UserType
        };
    }

    public static User ToEntity(this UserDTO userDTO)
    {
        return new User
        {
            UserId = userDTO.Id,
            Username = userDTO.Username ?? "",
            Password = userDTO.Password ?? "",
            UserType = userDTO.UserType switch
            {
                "Admin" => EUserType.Admin,
                "Cashier" => EUserType.Cashier,
                _ => throw new ArgumentException("Invalid user type")
            }
        };
    }

    public static UserViewModel ToViewModel(this UserDTO userDTO)
    {
        return new UserViewModel
        {
            Id = userDTO.Id ?? 0,
            Username = userDTO.Username ?? "",
            Password = userDTO.Password ?? "",
            UserType = userDTO.UserType ?? ""
        };
    }
}