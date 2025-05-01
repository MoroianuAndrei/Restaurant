using System.Collections.ObjectModel;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;

namespace Restaurant.Models.BusinessLogicLayer;

public static class OrderBLL
{
    public static ObservableCollection<OrderDTO> GetOrders()
    {
        var orders = new ObservableCollection<OrderDTO>();
        foreach (var order in OrderDAL.GetOrders())
        {
            orders.Add(order.ToDTO());
        }
        return orders;
    }

    public static ObservableCollection<OrderDTO> GetOrdersByUserId(int userId)
    {
        var orders = new ObservableCollection<OrderDTO>();
        foreach (var order in OrderDAL.GetOrdersByUserId(userId))
        {
            orders.Add(order.ToDTO());
        }
        return orders;
    }

    public static ObservableCollection<OrderDTO> GetOrdersByStatus(string status)
    {
        var orders = new ObservableCollection<OrderDTO>();
        foreach (var order in OrderDAL.GetOrdersByStatus(status))
        {
            orders.Add(order.ToDTO());
        }
        return orders;
    }

    public static bool AddOrder(OrderDTO orderDTO)
    {
        ArgumentNullException.ThrowIfNull(orderDTO);
        ArgumentNullException.ThrowIfNull(orderDTO.OrderCode);
        ArgumentNullException.ThrowIfNull(orderDTO.Status);

        return OrderDAL.InsertOrder(orderDTO.ToEntity());
    }

    public static bool EditOrder(OrderDTO orderDTO)
    {
        ArgumentNullException.ThrowIfNull(orderDTO);
        ArgumentNullException.ThrowIfNull(orderDTO.Id);
        ArgumentNullException.ThrowIfNull(orderDTO.OrderCode);
        ArgumentNullException.ThrowIfNull(orderDTO.Status);

        return OrderDAL.UpdateOrder(orderDTO.ToEntity());
    }

    public static bool DeleteOrder(OrderDTO orderDTO)
    {
        ArgumentNullException.ThrowIfNull(orderDTO);
        ArgumentNullException.ThrowIfNull(orderDTO.Id);

        return OrderDAL.DeleteOrder(orderDTO.ToEntity());
    }

    public static OrderDTO GetOrderById(int orderId)
    {
        return OrderDAL.GetOrderById(orderId).ToDTO();
    }

    public static bool UpdateOrderStatus(int orderId, string status)
    {
        var order = OrderDAL.GetOrderById(orderId);
        if (order == null || order.OrderId == 0)
            return false;

        order.Status = status;
        return OrderDAL.UpdateOrder(order);
    }

    public static bool UpdateEstimatedDeliveryTime(int orderId, DateTime? estimatedDeliveryTime)
    {
        var order = OrderDAL.GetOrderById(orderId);
        if (order == null || order.OrderId == 0)
            return false;

        order.EstimatedDeliveryTime = estimatedDeliveryTime;
        return OrderDAL.UpdateOrder(order);
    }
}