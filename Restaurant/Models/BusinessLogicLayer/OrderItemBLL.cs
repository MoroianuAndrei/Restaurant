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

    public static OrderItemDTO GetOrderItem(int id)
    {
        return OrderItemDAL.GetOrderItem(id).ToDTO();
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

        return OrderItemDAL.DeleteOrderItem(orderItemDTO.ToEntity().Id);
    }

    public static bool DeleteOrderItem(int id)
    {
        return OrderItemDAL.DeleteOrderItem(id);
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

    public static bool UpdateOrderItemQuantity(int id, int quantity)
    {
        var orderItem = OrderItemDAL.GetOrderItem(id);
        if (orderItem == null)
            return false;

        orderItem.Quantity = quantity;
        return OrderItemDAL.UpdateOrderItem(orderItem);
    }

    // Metoda de compatibilitate pentru codul existent care încă utilizează OrderId și ProductId
    public static OrderItemDTO FindOrderItemByOrderIdAndProductId(int orderId, int productId)
    {
        var orderItems = GetOrderItemsByOrderId(orderId);
        foreach (var item in orderItems)
        {
            if (item.ProductId.HasValue && item.ProductId.Value == productId)
            {
                return item;
            }
        }
        return null;
    }

    // Metode de compatibilitate pentru codul existent
    public static OrderItemDTO GetOrderItem(int orderId, int productId)
    {
        return FindOrderItemByOrderIdAndProductId(orderId, productId);
    }

    //public static bool UpdateOrderItemQuantity(int orderId, int productId, int quantity)
    //{
    //    var orderItem = FindOrderItemByOrderIdAndProductId(orderId, productId);
    //    if (orderItem == null)
    //        return false;

    //    orderItem.Quantity = quantity;
    //    return UpdateOrderItem(orderItem);
    //}

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

    // Metode adiționale pentru a lucra cu câmpul MenuId
    public static ObservableCollection<OrderItemDTO> GetOrderItemsByMenuId(int menuId)
    {
        var allOrderItems = GetOrderItems();
        var filteredItems = new ObservableCollection<OrderItemDTO>();

        foreach (var item in allOrderItems)
        {
            if (item.MenuId.HasValue && item.MenuId.Value == menuId)
            {
                filteredItems.Add(item);
            }
        }

        return filteredItems;
    }

    public static bool UpdateOrderItemMenuId(int id, int? menuId)
    {
        var orderItem = OrderItemDAL.GetOrderItem(id);
        if (orderItem == null)
            return false;

        orderItem.MenuId = menuId;
        return OrderItemDAL.UpdateOrderItem(orderItem);
    }

    // Metoda de compatibilitate pentru codul existent
    //public static bool UpdateOrderItemMenuId(int orderId, int productId, int? menuId)
    //{
    //    var orderItem = FindOrderItemByOrderIdAndProductId(orderId, productId);
    //    if (orderItem == null)
    //        return false;

    //    orderItem.MenuId = menuId;
    //    return UpdateOrderItem(orderItem);
    //}

    // Metodă pentru obținerea detaliilor OrderItem cu informații despre produse
    public static ObservableCollection<dynamic> GetOrderItemsWithDetails(int orderId)
    {
        var orderItems = OrderItemDAL.GetOrderItemsWithDetails(orderId);
        var result = new ObservableCollection<dynamic>();

        foreach (var item in orderItems)
        {
            result.Add(item);
        }

        return result;
    }
}