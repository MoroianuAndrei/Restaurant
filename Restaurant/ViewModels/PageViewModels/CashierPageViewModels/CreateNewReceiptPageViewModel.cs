using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Wpf.Ui.Controls;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.DataAccessLayer;
using Restaurant.Services;
using Restaurant.Extensions.Mapping;
using System.Windows.Media.Imaging;
using Restaurant.Helpers;

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

    // Loading indicators
    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
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
        AddProductToOrderCommand = new RelayCommand<object>(AddProductToOrder);
        AddMenuToOrderCommand = new RelayCommand<object>(AddMenuToOrder);
        RemoveOrderItemCommand = new RelayCommand<object>(RemoveOrderItem);
        IncreaseQuantityCommand = new RelayCommand<object>(IncreaseQuantity);
        DecreaseQuantityCommand = new RelayCommand<object>(DecreaseQuantity);
        SaveReceiptCommand = new RelayCommand<object>(SaveReceipt);
        CancelCommand = new RelayCommand<object>(Cancel);

        // Set default values
        ShippingCost = 5.0m;
        TableNumber = 1;

        // Load data from database
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        try
        {
            IsLoading = true;

            // Load categories from database
            await LoadCategoriesAsync();

            // Load products from database
            await LoadProductsAsync();

            // Load menus and menu items from database
            await LoadMenusAsync();
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"Eroare la încărcarea datelor: {ex.Message}", "Eroare",
                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task LoadCategoriesAsync()
    {
        // Get all categories from database
        var categoryDTOs = await Task.Run(() => CategoryBLL.GetAll());

        // Create "All Categories" option
        var allCategories = new ObservableCollection<CategoryViewModel>
        {
            new CategoryViewModel { Id = 0, CategoryName = "Toate categoriile" }
        };

        // Convert DTOs to ViewModels
        foreach (var categoryDTO in categoryDTOs)
        {
            allCategories.Add(new CategoryViewModel
            {
                Id = categoryDTO.Id,
                CategoryName = categoryDTO.CategoryName,
                Description = categoryDTO.Description
            });
        }

        Categories = allCategories;
        SelectedCategory = Categories.FirstOrDefault(); // Select "All Categories" by default
    }

    // Adăugăm metoda pentru a încărca imaginile produselor
    private async Task LoadProductsAsync()
    {
        // Get all products from database
        var productDTOs = await Task.Run(() => ProductBLL.GetAll());

        // Convert DTOs to ViewModels
        var productViewModels = new ObservableCollection<ProductViewModel>();
        foreach (var productDTO in productDTOs)
        {
            // Add null check before accessing Category.Id
            int categoryId = productDTO.Category?.Id ?? 0;

            // Get category name
            var category = categoryId > 0 ?
                await Task.Run(() => CategoryBLL.GetById(categoryId)) : null;
            string categoryName = category != null ? category.CategoryName : string.Empty;

            var productViewModel = new ProductViewModel
            {
                Id = productDTO.Id,
                ProductName = productDTO.ProductName,
                Price = productDTO.Price,
                Category = productDTO.Category != null ? productDTO.Category.ToViewModel() : new CategoryViewModel(),
                PortionQuantity = productDTO.PortionQuantity,
                MeasurementUnit = productDTO.MeasurementUnit,
                TotalQuantity = productDTO.TotalQuantity,
                IsMenu = productDTO.IsMenu,
                ImagePath = productDTO.ImagePath
            };

            // Load allergens for this product
            await LoadAllergensForProductAsync(productViewModel, productDTO.Id);

            productViewModels.Add(productViewModel);
        }

        Products = productViewModels;
    }

    // Helper method to load allergens for a specific product
    private async Task LoadAllergensForProductAsync(ProductViewModel productViewModel, int productId)
    {
        try
        {
            // Assuming there's a method in your BLL layer to get allergens for a product
            // If it doesn't exist, you'll need to create it
            var allergenDTOs = await Task.Run(() => ProductAllergenBLL.GetAllergensByProductId(productId));

            if (allergenDTOs != null && allergenDTOs.Count > 0)
            {
                // Convert allergen DTOs to ViewModels and assign to the product
                var allergenViewModels = new ObservableCollection<AllergenViewModel>();
                foreach (var allergenDTO in allergenDTOs)
                {
                    allergenViewModels.Add(allergenDTO.ToViewModel());
                }
                productViewModel.Allergens = allergenViewModels;
            }
        }
        catch (Exception ex)
        {
            // Log the error but don't crash the application
            System.Diagnostics.Debug.WriteLine($"Error loading allergens for product {productId}: {ex.Message}");
        }
    }

    private async Task LoadMenusAsync()
    {
        // Get all menus from database
        var menuDTOs = await Task.Run(() => MenuBLL.GetAll());

        // Convert DTOs to ViewModels
        var menuViewModels = new ObservableCollection<MenuViewModel>();
        foreach (var menuDTO in menuDTOs)
        {
            // Get menu items for this menu
            var menuItemDTOs = await Task.Run(() => MenuItemBLL.GetByMenuId(menuDTO.Id));
            var menuItemViewModels = new ObservableCollection<MenuItemViewModel>();

            foreach (var menuItemDTO in menuItemDTOs)
            {
                // Get product details
                var product = await Task.Run(() => ProductBLL.GetById(menuItemDTO.ProductId));
                if (product != null)
                {
                    menuItemViewModels.Add(new MenuItemViewModel
                    {
                        MenuId = menuItemDTO.MenuId,                     
                        ProductId = menuItemDTO.ProductId,
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Quantity = menuItemDTO.Quantity
                    });
                }
            }

            menuViewModels.Add(new MenuViewModel
            {
                Id = menuDTO.Id,
                Name = menuDTO.Name,
                Discount = menuDTO.Discount,
                MenuItems = menuItemViewModels,
                MenuImage = ImageHelper.CreateMenuImageCollage(menuItemViewModels, Products.ToList())
            });
        }

        Menus = menuViewModels;
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
        if (SelectedCategory != null && SelectedCategory.Id != 0) // ID 0 is "All Categories"
        {
            query = query.Where(p => p.Category.Id == SelectedCategory.Id);
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

        decimal requiredQuantity = product.PortionQuantity;

        // Calculează cantitatea totală deja comandată pentru acest produs
        var existingItem = OrderItems.FirstOrDefault(item => item.ProductId == product.Id && !item.IsMenu);
        int existingQuantity = existingItem?.Quantity ?? 0;

        decimal totalRequired = (existingQuantity + 1) * requiredQuantity;

        if (totalRequired > product.TotalQuantity)
        {
            System.Windows.MessageBox.Show(
                "Nu există suficientă cantitate disponibilă pentru a adăuga această porție.",
                "Stoc insuficient",
                System.Windows.MessageBoxButton.OK,
                MessageBoxImage.Warning
            );
            return;
        }

        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            // Create a new ObservableCollection for allergens to avoid reference issues
            var orderAllergens = new ObservableCollection<AllergenViewModel>();

            // Copy each allergen from the product to the order item
            if (product.Allergens != null && product.Allergens.Count > 0)
            {
                foreach (var allergen in product.Allergens)
                {
                    orderAllergens.Add(new AllergenViewModel
                    {
                        Id = allergen.Id,
                        AllergenName = allergen.AllergenName,
                        Description = allergen.Description
                    });
                }
            }

            var productImage = !string.IsNullOrEmpty(product.ImagePath)
                ? new BitmapImage(new Uri(product.ImagePath, UriKind.RelativeOrAbsolute))
                : new BitmapImage(new Uri("/Assets/Images/home_page.png", UriKind.Relative)); // fallback

            var orderItem = new OrderItemViewModel
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                ProductDescription = $"{product.PortionQuantity} {product.MeasurementUnit}",
                Quantity = 1,
                UnitPrice = product.Price,
                IsMenu = false,
                ProductImage = productImage,
                Allergens = orderAllergens
            };

            OrderItems.Add(orderItem);
        }

        UpdateOrderTotals();
    }

    private void AddMenuToOrder(object? parameter)
    {
        if (parameter is not MenuViewModel menu) return;

        // Verifică disponibilitatea stocului pentru toate produsele din meniu
        if (!IsMenuStockAvailable(menu))
        {
            System.Windows.MessageBox.Show(
                "Nu există suficientă cantitate disponibilă pentru unul sau mai multe produse din acest meniu.",
                "Stoc insuficient",
                System.Windows.MessageBoxButton.OK,
                MessageBoxImage.Warning
            );
            return;
        }

        // Verifică dacă meniul există deja în comandă
        var existingItem = OrderItems.FirstOrDefault(item => item.MenuId == menu.Id && item.IsMenu);

        if (existingItem != null)
        {
            // Verifică din nou disponibilitatea stocului pentru încă o cantitate din acest meniu
            if (!IsMenuStockAvailable(menu, existingItem.Quantity + 1))
            {
                System.Windows.MessageBox.Show(
                    "Nu există suficientă cantitate disponibilă pentru a crește numărul de meniuri.",
                    "Stoc insuficient",
                    System.Windows.MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
                return;
            }

            // Dacă meniul există deja și avem stoc suficient, îi crește cantitatea
            existingItem.Quantity++;
        }
        else
        {
            // Dacă nu există, creează un nou element pentru meniu
            var menuItems = new ObservableCollection<MenuItemViewModel>();

            // Adăugăm elementele meniului pentru a le putea utiliza la scăderea din stoc
            foreach (var item in menu.MenuItems)
            {
                menuItems.Add(new MenuItemViewModel
                {
                    MenuId = item.MenuId,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            var orderItem = new OrderItemViewModel
            {
                MenuId = menu.Id, // ID-ul meniului
                ProductName = menu.Name ?? "Menu",
                ProductDescription = $"Discount: {menu.Discount:P0}",
                Quantity = 1,
                UnitPrice = CalculateMenuPrice(menu),
                IsMenu = true,
                MenuItems = menuItems, // Elemente ale meniului

                // 🔽 Aici setăm colajul ca imagine
                ProductImage = ImageHelper.CreateMenuImageCollage(menuItems, Products.ToList())
            };


            OrderItems.Add(orderItem);
        }

        UpdateOrderTotals();
    }

    // Metoda verifică dacă există suficient stoc pentru toate produsele din meniu
    private bool IsMenuStockAvailable(MenuViewModel menu, int quantity = 1)
    {
        foreach (var menuItem in menu.MenuItems)
        {
            // Găsește produsul din lista de produse
            var product = Products.FirstOrDefault(p => p.Id == menuItem.ProductId);
            if (product == null) continue; // Skip if product not found

            // Calculează cantitatea necesară pentru acest produs în cadrul meniului
            decimal requiredQuantity = menuItem.Quantity * product.PortionQuantity * quantity;

            // Verifică cantitatea totală deja comandată pentru acest produs (în afara meniurilor)
            var existingOrderItems = OrderItems.Where(item => item.ProductId == menuItem.ProductId && !item.IsMenu);
            decimal existingQuantityUsed = 0;
            foreach (var item in existingOrderItems)
            {
                existingQuantityUsed += item.Quantity * product.PortionQuantity;
            }

            // Verifică cantitatea folosită în meniurile deja comandate
            var existingMenuItems = OrderItems.Where(item => item.IsMenu && item.MenuItems != null);
            foreach (var orderItem in existingMenuItems)
            {
                var menuItemInExistingMenu = orderItem.MenuItems.FirstOrDefault(mi => mi.ProductId == menuItem.ProductId);
                if (menuItemInExistingMenu != null)
                {
                    existingQuantityUsed += menuItemInExistingMenu.Quantity * product.PortionQuantity * orderItem.Quantity;
                }
            }

            // Verifică dacă mai avem suficientă cantitate disponibilă
            if (existingQuantityUsed + requiredQuantity > product.TotalQuantity)
            {
                return false;
            }
        }

        return true;
    }

    // Metoda SaveReceipt modificată pentru a salva și MenuId
    private async void SaveReceipt(object? parameter)
    {
        try
        {
            // Validate the order
            if (OrderItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Nu puteți salva o comandă fără produse.", "Eroare",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                return;
            }

            IsLoading = true;

            // Get the current user ID from UserSession
            int currentUserId = UserSession.Instance.LoggedInUser?.Id ?? -1;

            if (currentUserId == -1)
            {
                System.Windows.MessageBox.Show("Utilizatorul nu este autentificat corect.", "Eroare",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                IsLoading = false;
                return;
            }

            // Create a new Order DTO
            var orderDTO = new OrderDTO
            {
                OrderCode = GenerateOrderCode(),
                UserId = currentUserId, // Use the current user's ID from the session
                OrderDate = DateTime.Now,
                Status = "New",
                EstimatedDeliveryTime = DateTime.Now.AddMinutes(30),
                SubtotalAmount = SubtotalAmount,
                DiscountAmount = DiscountAmount,
                ShippingCost = ShippingCost,
                TotalAmount = TotalAmount,
                // Additional fields like CustomerName and TableNumber can be added to your Order entity if needed
            };

            // Save the order to database
            var savedOrderId = await Task.Run(() => OrderBLL.Insert(orderDTO));

            if (savedOrderId > 0)
            {
                // Save each order item
                foreach (var item in OrderItems)
                {
                    var orderItemDTO = new OrderItemDTO
                    {
                        OrderId = savedOrderId,
                        ProductId = item.IsMenu ? null : item.ProductId, // Null pentru meniuri
                        MenuId = item.IsMenu ? item.MenuId : null, // Null pentru produse simple
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };

                    await Task.Run(() => OrderItemBLL.Insert(orderItemDTO));

                    // Scade din stoc pentru produse individuale
                    if (orderItemDTO.ToEntity().ProductId.HasValue)
                    {
                        // Caută produsul ca să obții PortionQuantity
                        var product = Products.FirstOrDefault(p => p.Id == item.ProductId);
                        if (product != null)
                        {
                            decimal quantityToDecrease = item.Quantity * product.PortionQuantity;
                            await Task.Run(() => ProductBLL.DecreaseQuantity(item.ProductId.Value, quantityToDecrease));
                        }
                    }
                    // Scade din stoc pentru produsele din meniu
                    else if (orderItemDTO.ToEntity().MenuId.HasValue && item.MenuItems != null && item.MenuItems.Count > 0)
                    {
                        foreach (var menuItem in item.MenuItems)
                        {
                            var product = Products.FirstOrDefault(p => p.Id == menuItem.ProductId);
                            if (product != null)
                            {
                                decimal quantityToDecrease = item.Quantity * menuItem.Quantity * product.PortionQuantity;
                                await Task.Run(() => ProductBLL.DecreaseQuantity(menuItem.ProductId, quantityToDecrease));
                            }
                        }
                    }
                }

                System.Windows.MessageBox.Show($"Comandă salvată cu succes! Cod comandă: {orderDTO.OrderCode}", "Succes",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

                // Navigate back
                NavigationView?.Navigate("Home");
            }
            else
            {
                System.Windows.MessageBox.Show("Nu s-a putut salva comanda.", "Eroare",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"Eroare la salvarea comenzii: {ex.Message}", "Eroare",
                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }
        finally
        {
            IsLoading = false;
        }
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

        // Găsește produsul asociat
        var product = Products.FirstOrDefault(p => p.Id == item.ProductId);
        if (product == null || product.IsMenu == true)
        {
            item.Quantity++;
            UpdateOrderTotals();
            return;
        }

        decimal requiredQuantity = (item.Quantity + 1) * product.PortionQuantity;

        if (requiredQuantity > product.TotalQuantity)
        {
            System.Windows.MessageBox.Show(
                $"Nu există suficientă cantitate disponibilă pentru a crește porția de {product.ProductName}.",
                "Stoc insuficient",
                System.Windows.MessageBoxButton.OK,
                MessageBoxImage.Warning
            );
            return;
        }

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

    private string GenerateOrderCode()
    {
        // Generate a unique order code (for example: ORDER-YYYYMMDD-XXXX)
        var dateStr = DateTime.Now.ToString("yyyyMMdd");
        var random = new Random();
        var randomStr = random.Next(1000, 9999).ToString();
        return $"ORDER-{dateStr}-{randomStr}";
    }

    private void Cancel(object? parameter)
    {
        // Ask for confirmation if there are items in the order
        if (OrderItems.Count > 0)
        {
            var result = System.Windows.MessageBox.Show(
                "Sunteți sigur că doriți să anulați comanda? Toate produsele adăugate vor fi pierdute.",
                "Confirmare",
                System.Windows.MessageBoxButton.YesNo,
                System.Windows.MessageBoxImage.Question);

            if (result != System.Windows.MessageBoxResult.Yes)
            {
                return;
            }
        }

        // Simply navigate back without saving
        NavigationView?.Navigate("Home");
    }
}