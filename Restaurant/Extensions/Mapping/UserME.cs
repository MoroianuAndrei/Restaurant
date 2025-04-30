using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.Models.EntityLayer.Enums;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class UserME
{
    public static UserDTO ToDTO(this User user)
    {
        return new UserDTO
        {
            Id = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            DeliveryAddress = user.DeliveryAddress,
            Password = user.Password,
            UserType = user.UserType.ToString()
        };
    }

    public static UserDTO ToDTO(this UserViewModel userViewModel)
    {
        return new UserDTO
        {
            Id = userViewModel.Id,
            FirstName = userViewModel.FirstName,
            LastName = userViewModel.LastName,
            Email = userViewModel.Email,
            Phone = userViewModel.Phone,
            DeliveryAddress = userViewModel.DeliveryAddress,
            Password = userViewModel.Password,
            UserType = userViewModel.UserType
        };
    }

    public static User ToEntity(this UserDTO userDTO)
    {
        return new User
        {
            UserId = userDTO.Id,
            FirstName = userDTO.FirstName ?? "",
            LastName = userDTO.LastName ?? "",
            Email = userDTO.Email ?? "",
            Phone = userDTO.Phone ?? "",
            DeliveryAddress = userDTO.DeliveryAddress ?? "",
            Password = userDTO.Password ?? "",
            UserType = userDTO.UserType switch
            {
                "Admin" => EUserType.Admin,
                "Client" => EUserType.Client,
                "Guest" => EUserType.Guest,
                _ => throw new ArgumentException("Invalid user type")
            }
        };
    }

    public static UserViewModel ToViewModel(this UserDTO userDTO)
    {
        return new UserViewModel
        {
            Id = userDTO.Id,
			FirstName = userDTO.FirstName ?? "",
			LastName = userDTO.LastName ?? "",
			Email = userDTO.Email ?? "",
			Phone = userDTO.Phone ?? "",
			DeliveryAddress = userDTO.DeliveryAddress ?? "",
			Password = userDTO.Password ?? "",
			UserType = userDTO.UserType ?? ""
        };
    }
}