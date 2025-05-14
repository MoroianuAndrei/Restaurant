using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.Views.PageViews.CashierPageViews;
using Wpf.Ui.Controls;
using Restaurant.Services;

namespace Restaurant.ViewModels.PageViewModels.CashierPageViewModels;

public class OrderHistoryPageViewModel : BaseViewModel
{
    private ObservableCollection<OrderViewModel> _userOrders;
    public ObservableCollection<OrderViewModel> UserOrders
    {
        get => _userOrders;
        set
        {
            _userOrders = value;
            OnPropertyChanged();
        }
    }

    private int _currentUserId;
    public int CurrentUserId
    {
        get => _currentUserId;
        set
        {
            _currentUserId = value;
            OnPropertyChanged();
        }
    }

    public ICommand ViewDetailsCommand { get; }

    public OrderHistoryPageViewModel()
    {
        // Initialize properties
        _userOrders = new ObservableCollection<OrderViewModel>();

        // Get current user ID from the session
        CurrentUserId = UserSession.Instance.LoggedInUser?.Id ?? 0;

        // Initialize commands
        ViewDetailsCommand = new RelayCommand<object>(ViewOrderDetails);

        // Load orders for current user
        if (CurrentUserId > 0)
        {
            LoadUserOrders();
        }
    }

    private void LoadUserOrders()
    {
        // Get all orders from BLL
        var orderDTOs = OrderBLL.GetOrders();

        // Filter orders for current user
        var userOrderDTOs = orderDTOs.Where(o => o.UserId == CurrentUserId).ToList();

        // Convert to view models and add order items
        var orderViewModels = new ObservableCollection<OrderViewModel>();

        foreach (var orderDTO in userOrderDTOs)
        {
            var orderViewModel = orderDTO.ToViewModel();

            // Load order items for this order
            var orderItems = OrderItemBLL.GetOrderItemsByOrderId(orderViewModel.Id);
            var productList = ProductBLL.GetProducts();
            var menuList = MenuBLL.GetMenus();

            var itemViewModels = new List<OrderItemViewModel>();

            foreach (var item in orderItems)
            {
                var itemVM = item.ToViewModel();

                if (item.ProductId != null)
                {
                    var product = productList.FirstOrDefault(p => p.Id == item.ProductId);
                    itemVM.Name = product?.ProductName ?? "Unknown Product";
                }
                else if (item.MenuId != null)
                {
                    var menu = menuList.FirstOrDefault(m => m.Id == item.MenuId);
                    itemVM.Name = menu?.Name ?? "Unknown Menu";
                }

                itemViewModels.Add(itemVM);
            }

            orderViewModel.OrderItems = new ObservableCollection<OrderItemViewModel>(itemViewModels);
            orderViewModels.Add(orderViewModel);
        }

        // Sort orders by date in descending order
        UserOrders = new ObservableCollection<OrderViewModel>(
            orderViewModels.OrderByDescending(o => o.OrderDate)
        );
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
        var sb = new StringBuilder();

        sb.AppendLine($"Order Date: {order.OrderDate:yyyy-MM-dd HH:mm}");
        sb.AppendLine($"Status: {order.Status}");
        sb.AppendLine($"Est. Delivery: {order.EstimatedDeliveryTime?.ToString("HH:mm") ?? "N/A"}");
        sb.AppendLine();

        var itemsList = new List<string>();
        var menusList = new List<string>();

        foreach (var item in order.OrderItems)
        {
            if (item.ProductId != null)
            {
                var product = ProductBLL.GetProducts().FirstOrDefault(p => p.Id == item.ProductId);
                if (product != null)
                {
                    itemsList.Add($"  - {item.Quantity} x {product.ProductName} ({item.UnitPrice:C})");
                }
            }
            else if (item.MenuId != null)
            {
                var menu = MenuBLL.GetMenus().FirstOrDefault(m => m.Id == item.MenuId);
                if (menu != null)
                {
                    menusList.Add($"  - {item.Quantity} x {menu.Name} ({item.UnitPrice:C})");
                }
            }
        }

        if (itemsList.Any())
        {
            sb.AppendLine("Items:");
            foreach (var line in itemsList)
            {
                sb.AppendLine(line);
            }
        }

        if (menusList.Any())
        {
            sb.AppendLine("Menus:");
            foreach (var line in menusList)
            {
                sb.AppendLine(line);
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