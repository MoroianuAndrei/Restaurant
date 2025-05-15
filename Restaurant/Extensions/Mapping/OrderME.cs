using Restaurant.Models.BusinessLogicLayer;
using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping;

public static class OrderME
{
    public static OrderDTO ToDTO(this Order order)
    {
        return new OrderDTO
        {
            Id = order.OrderId,
            OrderCode = order.OrderCode,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            Status = order.Status,
            EstimatedDeliveryTime = order.EstimatedDeliveryTime,
            SubtotalAmount = order.SubtotalAmount,
            DiscountAmount = order.DiscountAmount,
            ShippingCost = order.ShippingCost,
            TotalAmount = order.TotalAmount
        };
    }

    public static OrderDTO ToDTO(this OrderViewModel orderViewModel)
    {
        return new OrderDTO
        {
            Id = orderViewModel.Id,
            OrderCode = orderViewModel.OrderCode,
            UserId = orderViewModel.UserId,
            OrderDate = orderViewModel.OrderDate,
            Status = orderViewModel.Status,
            EstimatedDeliveryTime = orderViewModel.EstimatedDeliveryTime,
            SubtotalAmount = orderViewModel.SubtotalAmount,
            DiscountAmount = orderViewModel.DiscountAmount,
            ShippingCost = orderViewModel.ShippingCost,
            TotalAmount = orderViewModel.TotalAmount
        };
    }

    public static Order ToEntity(this OrderDTO orderDTO)
    {
        return new Order
        {
            OrderId = orderDTO.Id,
            OrderCode = orderDTO.OrderCode ?? "",
            UserId = orderDTO.UserId,
            OrderDate = orderDTO.OrderDate,
            Status = orderDTO.Status ?? "",
            EstimatedDeliveryTime = orderDTO.EstimatedDeliveryTime,
            SubtotalAmount = orderDTO.SubtotalAmount,
            DiscountAmount = orderDTO.DiscountAmount,
            ShippingCost = orderDTO.ShippingCost,
            TotalAmount = orderDTO.TotalAmount
        };
    }

    public static OrderViewModel ToViewModel(this OrderDTO orderDTO)
    {
        return new OrderViewModel
        {
            Id = orderDTO.Id,
            OrderCode = orderDTO.OrderCode ?? "",
            UserId = orderDTO.UserId,
            OrderDate = orderDTO.OrderDate,
            Status = orderDTO.Status ?? "",
            EstimatedDeliveryTime = orderDTO.EstimatedDeliveryTime,
            SubtotalAmount = orderDTO.SubtotalAmount,
            DiscountAmount = orderDTO.DiscountAmount,
            ShippingCost = orderDTO.ShippingCost,
            TotalAmount = orderDTO.TotalAmount,
            User = UserBLL.GetUserById(orderDTO.UserId).ToViewModel()
        };
    }
}