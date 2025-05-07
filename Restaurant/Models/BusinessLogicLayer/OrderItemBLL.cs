using System.Collections.ObjectModel;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Models.DataTransferLayer;

namespace Restaurant.Models.BusinessLogicLayer;

public static class OrderItemBLL
{
    public static ObservableCollection<OrderItemDTO> GetOrderItems()
    {
        var orderItems = new ObservableCollection<OrderItemDTO>();
        foreach (var orderItem in OrderItemDAL.GetOrderItems())
        {
            orderItems.Add(orderItem.ToDTO());
        }
        return orderItems;
    }

    public static ObservableCollection<OrderItemDTO> GetOrderItemsByOrderId(int orderId)
    {
        var orderItems = new ObservableCollection<OrderItemDTO>();
        foreach (var orderItem in OrderItemDAL.GetOrderItemsByOrderId(orderId))
        {
            orderItems.Add(orderItem.ToDTO());
        }
        return orderItems;
    }

    public static OrderItemDTO GetOrderItem(int orderId, int productId)
    {
        return OrderItemDAL.GetOrderItem(orderId, productId).ToDTO();
    }

    public static bool AddOrderItem(OrderItemDTO orderItemDTO)
    {
        ArgumentNullException.ThrowIfNull(orderItemDTO);

        return OrderItemDAL.InsertOrderItem(orderItemDTO.ToEntity());
    }

    public static bool UpdateOrderItem(OrderItemDTO orderItemDTO)
    {
        ArgumentNullException.ThrowIfNull(orderItemDTO);

        return OrderItemDAL.UpdateOrderItem(orderItemDTO.ToEntity());
    }

    public static bool DeleteOrderItem(OrderItemDTO orderItemDTO)
    {
        ArgumentNullException.ThrowIfNull(orderItemDTO);

        return OrderItemDAL.DeleteOrderItem(orderItemDTO.ToEntity());
    }

    public static bool DeleteOrderItemsByOrderId(int orderId)
    {
        return OrderItemDAL.DeleteOrderItemsByOrderId(orderId);
    }

    public static decimal CalculateOrderSubtotal(int orderId)
    {
        var orderItems = OrderItemDAL.GetOrderItemsByOrderId(orderId);
        decimal subtotal = 0;

        foreach (var item in orderItems)
        {
            subtotal += item.Quantity * item.UnitPrice;
        }

        return subtotal;
    }

    public static bool UpdateOrderItemQuantity(int orderId, int productId, int quantity)
    {
        var orderItem = OrderItemDAL.GetOrderItem(orderId, productId);
        if (orderItem == null)
            return false;

        orderItem.Quantity = quantity;
        return OrderItemDAL.UpdateOrderItem(orderItem);
    }

    // New methods to match what the ViewModel is trying to call
    public static ObservableCollection<OrderItemDTO> GetAll()
    {
        return GetOrderItems();
    }

    public static ObservableCollection<OrderItemDTO> GetByOrderId(int orderId)
    {
        return GetOrderItemsByOrderId(orderId);
    }

    public static bool Insert(OrderItemDTO orderItemDTO)
    {
        return AddOrderItem(orderItemDTO);
    }
}