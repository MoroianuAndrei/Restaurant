using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
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

    private ObservableCollection<OrderViewModel> _allOrders;
    public ObservableCollection<OrderViewModel> AllOrders
    {
        get => _allOrders;
        set
        {
            _allOrders = value;
            OnPropertyChanged();
        }
    }

    private bool _showActiveOrdersOnly;
    public bool ShowActiveOrdersOnly
    {
        get => _showActiveOrdersOnly;
        set
        {
            _showActiveOrdersOnly = value;
            OnPropertyChanged();
            FilterOrders();
        }
    }

    private string? _name;
    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    // Dictionary to store user information for each order
    private Dictionary<int, UserViewModel> _usersByOrderId;

    public ICommand ViewDetailsCommand { get; }
    public ICommand ToggleActiveOrdersCommand { get; }

    public OrderPageViewModel()
    {
        // Initialize properties
        _allOrders = new ObservableCollection<OrderViewModel>();
        _orders = new ObservableCollection<OrderViewModel>();
        _showActiveOrdersOnly = false;
        _usersByOrderId = new Dictionary<int, UserViewModel>();

        // Initialize commands
        ViewDetailsCommand = new RelayCommand<object>(ViewOrderDetails);
        ToggleActiveOrdersCommand = new RelayCommand<object>(_ =>
        {
            ShowActiveOrdersOnly = !ShowActiveOrdersOnly;
        });

        // Load orders from BLL
        LoadOrders();
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


            // Get user data for this order
            var userDTO = UserBLL.GetUserById(orderViewModel.UserId);
            if (userDTO != null)
            {
                var userViewModel = userDTO.ToViewModel();
                _usersByOrderId[orderViewModel.Id] = userViewModel;
            }

            orderViewModels.Add(orderViewModel);
        }

        // Sort orders by date in descending order
        AllOrders = new ObservableCollection<OrderViewModel>(
            orderViewModels.OrderByDescending(o => o.OrderDate)
        );

        // Apply current filter
        FilterOrders();
    }

    private void FilterOrders()
    {
        if (ShowActiveOrdersOnly)
        {
            // Filter only active orders (status is "Inregistrata")
            Orders = new ObservableCollection<OrderViewModel>(
                AllOrders.Where(o => o.Status.Equals("Inregistrata", StringComparison.OrdinalIgnoreCase))
            );
        }
        else
        {
            // Show all orders
            Orders = new ObservableCollection<OrderViewModel>(AllOrders);
        }
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

        // Add client information if available
        if (_usersByOrderId.TryGetValue(order.Id, out var user))
        {
            sb.AppendLine("Client Information:");
            sb.AppendLine($"Nume: {user.LastName}");
            sb.AppendLine($"Prenume: {user.FirstName}");
            sb.AppendLine($"Telefon: {user.Phone}");
            sb.AppendLine($"Adresa de livrare: {user.DeliveryAddress}");
            sb.AppendLine();
        }

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