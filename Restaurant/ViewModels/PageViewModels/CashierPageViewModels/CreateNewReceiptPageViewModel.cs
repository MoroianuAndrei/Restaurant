using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Wpf.Ui.Controls;

namespace Restaurant.ViewModels.PageViewModels.CashierPageViewModels;

public class CreateNewReceiptPageViewModel : BaseViewModel
{
    public static NavigationView? NavigationView { get; set; }

    // Customer information
    private string? _customerName;
    public string CustomerName
    {
        get => _customerName ?? "";
        set
        {
            _customerName = value;
            OnPropertyChanged();
        }
    }

    private int _tableNumber;
    public int TableNumber
    {
        get => _tableNumber;
        set
        {
            _tableNumber = value;
            OnPropertyChanged();
        }
    }

    // Search and filter
    private string? _productSearchText;
    public string ProductSearchText
    {
        get => _productSearchText ?? "";
        set
        {
            _productSearchText = value;
            OnPropertyChanged();
            FilterProducts();
        }
    }

    private string? _menuSearchText;
    public string MenuSearchText
    {
        get => _menuSearchText ?? "";
        set
        {
            _menuSearchText = value;
            OnPropertyChanged();
            FilterMenus();
        }
    }

    private CategoryViewModel? _selectedCategory;
    public CategoryViewModel? SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            _selectedCategory = value;
            OnPropertyChanged();
            FilterProducts();
        }
    }

    // Collections
    private ObservableCollection<ProductViewModel> _products = new();
    public ObservableCollection<ProductViewModel> Products
    {
        get => _products;
        set
        {
            _products = value;
            OnPropertyChanged();
            FilterProducts();
        }
    }

    private ObservableCollection<ProductViewModel> _filteredProducts = new();
    public ObservableCollection<ProductViewModel> FilteredProducts
    {
        get => _filteredProducts;
        set
        {
            _filteredProducts = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<MenuViewModel> _menus = new();
    public ObservableCollection<MenuViewModel> Menus
    {
        get => _menus;
        set
        {
            _menus = value;
            OnPropertyChanged();
            FilterMenus();
        }
    }

    private ObservableCollection<MenuViewModel> _filteredMenus = new();
    public ObservableCollection<MenuViewModel> FilteredMenus
    {
        get => _filteredMenus;
        set
        {
            _filteredMenus = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<CategoryViewModel> _categories = new();
    public ObservableCollection<CategoryViewModel> Categories
    {
        get => _categories;
        set
        {
            _categories = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<OrderItemViewModel> _orderItems = new();
    public ObservableCollection<OrderItemViewModel> OrderItems
    {
        get => _orderItems;
        set
        {
            _orderItems = value;
            OnPropertyChanged();
        }
    }

    // Order totals
    private decimal _subtotalAmount;
    public decimal SubtotalAmount
    {
        get => _subtotalAmount;
        set
        {
            _subtotalAmount = value;
            OnPropertyChanged();
            CalculateTotal();
        }
    }

    private decimal _discountAmount;
    public decimal DiscountAmount
    {
        get => _discountAmount;
        set
        {
            _discountAmount = value;
            OnPropertyChanged();
            CalculateTotal();
        }
    }

    private decimal _shippingCost;
    public decimal ShippingCost
    {
        get => _shippingCost;
        set
        {
            _shippingCost = value;
            OnPropertyChanged();
            CalculateTotal();
        }
    }

    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get => _totalAmount;
        set
        {
            _totalAmount = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddProductToOrderCommand { get; }
    public ICommand AddMenuToOrderCommand { get; }
    public ICommand RemoveOrderItemCommand { get; }
    public ICommand IncreaseQuantityCommand { get; }
    public ICommand DecreaseQuantityCommand { get; }
    public ICommand SaveReceiptCommand { get; }
    public ICommand PrintReceiptCommand { get; }
    public ICommand CancelCommand { get; }


    public CreateNewReceiptPageViewModel()
    {
        // Initialize commands
        AddProductToOrderCommand = new RelayCommand<object?>(AddProductToOrder);
        AddMenuToOrderCommand = new RelayCommand<object?>(AddMenuToOrder);
        RemoveOrderItemCommand = new RelayCommand<object?>(RemoveOrderItem);
        IncreaseQuantityCommand = new RelayCommand<object?>(IncreaseQuantity);
        DecreaseQuantityCommand = new RelayCommand<object?>(DecreaseQuantity);
        SaveReceiptCommand = new RelayCommand<object?>(SaveReceipt);
        PrintReceiptCommand = new RelayCommand<object?>(PrintReceipt);
        CancelCommand = new RelayCommand<object?>(Cancel);

        // Set some default values
        ShippingCost = 5.0m;

        // Load sample data (in a real app, this would come from a database)
        LoadSampleData();
    }

    private void LoadSampleData()
    {
        // Sample Categories
        var categories = new ObservableCollection<CategoryViewModel>
        {
            new() { Id = 1, CategoryName = "Toate categoriile" },
            new() { Id = 2, CategoryName = "Aperitive" },
            new() { Id = 3, CategoryName = "Feluri principale" },
            new() { Id = 4, CategoryName = "Deserturi" },
            new() { Id = 5, CategoryName = "Băuturi" }
        };
        Categories = categories;

        // Sample Products
        var products = new ObservableCollection<ProductViewModel>
        {
            new() { Id = 1, ProductName = "Salată Caesar", Price = 25.99m, CategoryId = 2, CategoryName = "Aperitive", PortionQuantity = 350, MeasurementUnit = "g" },
            new() { Id = 2, ProductName = "Pizza Margherita", Price = 35.50m, CategoryId = 3, CategoryName = "Feluri principale", PortionQuantity = 450, MeasurementUnit = "g" },
            new() { Id = 3, ProductName = "Paste Carbonara", Price = 32.00m, CategoryId = 3, CategoryName = "Feluri principale", PortionQuantity = 400, MeasurementUnit = "g" },
            new() { Id = 4, ProductName = "Tiramisu", Price = 18.50m, CategoryId = 4, CategoryName = "Deserturi", PortionQuantity = 200, MeasurementUnit = "g" },
            new() { Id = 5, ProductName = "Coca Cola", Price = 8.00m, CategoryId = 5, CategoryName = "Băuturi", PortionQuantity = 330, MeasurementUnit = "ml" },
            new() { Id = 6, ProductName = "Apă minerală", Price = 6.00m, CategoryId = 5, CategoryName = "Băuturi", PortionQuantity = 500, MeasurementUnit = "ml" }
        };
        Products = products;

        // Sample Menus
        var menuItems1 = new ObservableCollection<MenuItemViewModel>
        {
            new() { ProductId = 1, ProductName = "Salată Caesar", Price = 25.99m, Quantity = 1 },
            new() { ProductId = 3, ProductName = "Paste Carbonara", Price = 32.00m, Quantity = 1 },
            new() { ProductId = 5, ProductName = "Coca Cola", Price = 8.00m, Quantity = 1 }
        };

        var menuItems2 = new ObservableCollection<MenuItemViewModel>
        {
            new() { ProductId = 2, ProductName = "Pizza Margherita", Price = 35.50m, Quantity = 1 },
            new() { ProductId = 4, ProductName = "Tiramisu", Price = 18.50m, Quantity = 1 },
            new() { ProductId = 6, ProductName = "Apă minerală", Price = 6.00m, Quantity = 1 }
        };

        var menus = new ObservableCollection<MenuViewModel>
        {
            new() { Id = 1, Name = "Meniu Paste", Discount = 0.15m, MenuItems = menuItems1 },
            new() { Id = 2, Name = "Meniu Pizza", Discount = 0.10m, MenuItems = menuItems2 }
        };
        Menus = menus;

        // Initialize filtered collections
        FilterProducts();
        FilterMenus();
    }

    private void FilterProducts()
    {
        var query = Products.AsEnumerable();

        // Apply text filter if provided
        if (!string.IsNullOrWhiteSpace(ProductSearchText))
        {
            var searchText = ProductSearchText.ToLower();
            query = query.Where(p => p.ProductName.ToLower().Contains(searchText));
        }

        // Apply category filter if selected
        if (SelectedCategory != null && SelectedCategory.Id != 1) // Assuming ID 1 is "All Categories"
        {
            query = query.Where(p => p.CategoryId == SelectedCategory.Id);
        }

        FilteredProducts = new ObservableCollection<ProductViewModel>(query);
    }

    private void FilterMenus()
    {
        var query = Menus.AsEnumerable();

        // Apply text filter if provided
        if (!string.IsNullOrWhiteSpace(MenuSearchText))
        {
            var searchText = MenuSearchText.ToLower();
            query = query.Where(m => m.Name?.ToLower().Contains(searchText) == true);
        }

        FilteredMenus = new ObservableCollection<MenuViewModel>(query);
    }

    private void AddProductToOrder(object? parameter)
    {
        if (parameter is not ProductViewModel product) return;

        // Check if product already exists in order
        var existingItem = OrderItems.FirstOrDefault(item =>
            item.ProductId == product.Id && !item.IsMenu);

        if (existingItem != null)
        {
            // Increase quantity of existing item
            existingItem.Quantity++;
        }
        else
        {
            // Add new order item
            var orderItem = new OrderItemViewModel
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                ProductDescription = $"{product.PortionQuantity} {product.MeasurementUnit}",
                Quantity = 1,
                UnitPrice = product.Price,
                IsMenu = false
            };

            OrderItems.Add(orderItem);
        }

        UpdateOrderTotals();
    }

    private void AddMenuToOrder(object? parameter)
    {
        if (parameter is not MenuViewModel menu) return;

        // Create a new order item for the menu
        var orderItem = new OrderItemViewModel
        {
            ProductId = menu.Id,
            ProductName = menu.Name ?? "Menu",
            ProductDescription = $"Discount: {menu.Discount:P0}",
            Quantity = 1,
            UnitPrice = CalculateMenuPrice(menu),
            IsMenu = true
        };

        OrderItems.Add(orderItem);
        UpdateOrderTotals();
    }

    private decimal CalculateMenuPrice(MenuViewModel menu)
    {
        // Calculate the total price of all items in the menu
        decimal totalPrice = menu.MenuItems.Sum(item => item.Price * item.Quantity);

        // Apply the menu discount
        if (menu.Discount.HasValue)
        {
            totalPrice *= (1 - menu.Discount.Value);
        }

        return totalPrice;
    }

    private void RemoveOrderItem(object? parameter)
    {
        if (parameter is not OrderItemViewModel item) return;

        OrderItems.Remove(item);
        UpdateOrderTotals();
    }

    private void IncreaseQuantity(object? parameter)
    {
        if (parameter is not OrderItemViewModel item) return;

        item.Quantity++;
        UpdateOrderTotals();
    }

    private void DecreaseQuantity(object? parameter)
    {
        if (parameter is not OrderItemViewModel item) return;

        if (item.Quantity > 1)
        {
            item.Quantity--;
        }
        else
        {
            // If quantity becomes 0, remove the item
            OrderItems.Remove(item);
        }

        UpdateOrderTotals();
    }

    private void UpdateOrderTotals()
    {
        // Calculate subtotal
        SubtotalAmount = OrderItems.Sum(item => item.TotalPrice);

        // Calculate discount (could be based on specific rules)
        // For this example, we'll apply a simple 5% discount if total is above 100
        DiscountAmount = SubtotalAmount > 100 ? SubtotalAmount * 0.05m : 0;

        // Shipping cost is already set, but you could adjust it based on order details

        // Total will be calculated by the property setter
    }

    private void CalculateTotal()
    {
        TotalAmount = SubtotalAmount - DiscountAmount + ShippingCost;
    }

    private void SaveReceipt(object? parameter)
    {
        // Here you would normally:
        // 1. Validate the order
        if (OrderItems.Count == 0)
        {
            // Show error message - no items in order
            return;
        }

        // 2. Create an order in the database
        // var order = new OrderViewModel {...}

        // 3. Create order items in the database
        // foreach (var item in OrderItems) {...}

        // 4. Generate receipt number, etc.

        // For this example, we'll just navigate back to home
        NavigationView?.Navigate("Home");
    }

    private void PrintReceipt(object? parameter)
    {
        // Implement printing functionality
        // This is just a placeholder
        SaveReceipt(parameter);
    }

    private void Cancel(object? parameter)
    {
        // Simply navigate back without saving
        NavigationView?.Navigate("Home");
    }
}