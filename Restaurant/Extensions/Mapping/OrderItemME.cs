using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class OrderItemME
{
    public static OrderItemDTO ToDTO(this OrderItem orderItem)
    {
        return new OrderItemDTO
        {
            OrderId = orderItem.OrderId,
            ProductId = orderItem.ProductId,
            MenuId = orderItem.MenuId,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice,
            IsMenu = orderItem.IsMenu
        };
    }

    public static OrderItemDTO ToDTO(this OrderItemViewModel orderItemViewModel)
    {
        return new OrderItemDTO
        {
            OrderId = orderItemViewModel.OrderId,
            ProductId = orderItemViewModel.ProductId,
            MenuId = orderItemViewModel.MenuId,
            Quantity = orderItemViewModel.Quantity,
            UnitPrice = orderItemViewModel.UnitPrice,
            IsMenu = orderItemViewModel.IsMenu
        };
    }

    public static OrderItem ToEntity(this OrderItemDTO orderItemDTO)
    {
        return new OrderItem
        {
            OrderId = orderItemDTO.OrderId,
            ProductId = orderItemDTO.ProductId,
            MenuId = orderItemDTO.MenuId,
            Quantity = orderItemDTO.Quantity,
            UnitPrice = orderItemDTO.UnitPrice,
            IsMenu = orderItemDTO.IsMenu
        };
    }

    public static OrderItemViewModel ToViewModel(this OrderItemDTO orderItemDTO)
    {
        return new OrderItemViewModel
        {
            OrderId = orderItemDTO.OrderId,
            ProductId = orderItemDTO.ProductId,
            MenuId = orderItemDTO.MenuId,
            Quantity = orderItemDTO.Quantity,
            UnitPrice = orderItemDTO.UnitPrice,
            IsMenu = orderItemDTO.IsMenu
        };
    }
}