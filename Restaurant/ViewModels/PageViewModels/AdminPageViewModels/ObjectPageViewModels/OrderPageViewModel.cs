using System.Collections.ObjectModel;
using System.Windows.Input;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.Views.AdminItemPageViews;
using Wpf.Ui.Controls;

namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels;

public class OrderPageViewModel : BaseViewModel
{
    private ObservableCollection<OrderViewModel> _orders;
    public ObservableCollection<OrderViewModel> Orders
    {
        get => _orders;
        set
        {
            _orders = value;
            OnPropertyChanged();
        }
    }

    public ICommand ViewDetailsCommand { get; }

    public OrderPageViewModel()
    {
        // Load orders from BLL
        LoadOrders();

        // Initialize commands
        ViewDetailsCommand = new RelayCommand<object>(ViewOrderDetails);
    }

    private void LoadOrders()
    {
        // Get orders from BLL
        var orderDTOs = OrderBLL.GetOrders();

        // Convert to view models and add order items
        var orderViewModels = new ObservableCollection<OrderViewModel>();

        foreach (var orderDTO in orderDTOs)
        {
            var orderViewModel = orderDTO.ToViewModel();

            // Load order items for this order
            var orderItems = OrderItemBLL.GetOrderItemsByOrderId(orderViewModel.Id);
            orderViewModel.OrderItems = new ObservableCollection<OrderItemViewModel>(
                orderItems.Select(item => item.ToViewModel())
            );

            orderViewModels.Add(orderViewModel);
        }

        Orders = orderViewModels;
    }

    private void ViewOrderDetails(object? parameter)
    {
        if (parameter is not OrderViewModel order)
        {
            return;
        }

        // Create a dialog to show detailed order information
        var dialog = new MessageBox
        {
            Title = $"Order Details - {order.OrderCode}",
            Content = CreateOrderDetailsContent(order),
            PrimaryButtonText = "Close"
        };

        dialog.ShowDialogAsync();
    }

    private string CreateOrderDetailsContent(OrderViewModel order)
    {
        // Create a formatted string with all the order details
        var sb = new System.Text.StringBuilder();

        sb.AppendLine($"Order Date: {order.OrderDate:yyyy-MM-dd HH:mm}");
        sb.AppendLine($"Status: {order.Status}");
        sb.AppendLine($"Est. Delivery: {order.EstimatedDeliveryTime?.ToString("HH:mm") ?? "N/A"}");
        sb.AppendLine();

        sb.AppendLine("Items:");
        foreach (var item in order.OrderItems)
        {
            sb.AppendLine($"- {item.Quantity} x {item.ProductName} ({item.UnitPrice:C})");
            if (item.IsMenu && item.MenuItems?.Count > 0)
            {
                sb.AppendLine("  Menu items:");
                foreach (var menuItem in item.MenuItems)
                {
                    sb.AppendLine($"  - {menuItem.Quantity} x {menuItem.ProductName} ({menuItem.Price:C})");
                }
            }
            if (item.HasAllergens)
            {
                sb.AppendLine($"  Allergens: {item.AllergensDisplay}");
            }
        }

        sb.AppendLine();
        sb.AppendLine($"Subtotal: {order.SubtotalAmount:C}");

        if (order.DiscountAmount > 0)
        {
            sb.AppendLine($"Discount: -{order.DiscountAmount:C}");
        }

        sb.AppendLine($"Shipping: {order.ShippingCost:C}");
        sb.AppendLine($"Total: {order.TotalAmount:C}");

        return sb.ToString();
    }
}