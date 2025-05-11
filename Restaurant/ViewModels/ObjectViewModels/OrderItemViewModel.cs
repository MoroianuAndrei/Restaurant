using System.Collections.ObjectModel;

namespace Restaurant.ViewModels.ObjectViewModels;

public class OrderItemViewModel : BaseViewModel
{
    private int _orderId;
    public int OrderId
    {
        get => _orderId;
        set
        {
            _orderId = value;
            OnPropertyChanged();
        }
    }

    private int? _productId;
    public int? ProductId
    {
        get => _productId;
        set
        {
            _productId = value;
            OnPropertyChanged();
        }
    }

    private int? _menuId;
    public int? MenuId
    {
        get => _menuId;
        set
        {
            _menuId = value;
            OnPropertyChanged();
        }
    }

    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged();
            // Recalculate total price when quantity changes
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    private decimal _unitPrice;
    public decimal UnitPrice
    {
        get => _unitPrice;
        set
        {
            _unitPrice = value;
            OnPropertyChanged();
            // Recalculate total price when unit price changes
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    private bool _isMenu;
    public bool IsMenu
    {
        get => _isMenu;
        set
        {
            _isMenu = value;
            OnPropertyChanged();
        }
    }

    // Calculated property
    public decimal TotalPrice => Quantity * UnitPrice;

    // Additional properties that might be useful in UI
    private string? _productName;
    public string ProductName
    {
        get => _productName ?? "";
        set
        {
            _productName = value;
            OnPropertyChanged();
        }
    }

    private string? _productDescription;
    public string ProductDescription
    {
        get => _productDescription ?? "";
        set
        {
            _productDescription = value;
            OnPropertyChanged();
        }
    }

    private string? _productImagePath;
    public string ProductImagePath
    {
        get => _productImagePath ?? "";
        set
        {
            _productImagePath = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasImage));
        }
    }

    // Proprietate calculată pentru a verifica dacă produsul are imagine
    public bool HasImage => !string.IsNullOrEmpty(ProductImagePath);

    // Alergeni asociați cu acest element de comandă
    private ObservableCollection<AllergenViewModel> _allergens = new();
    public ObservableCollection<AllergenViewModel> Allergens
    {
        get => _allergens;
        set
        {
            _allergens = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasAllergens));
            OnPropertyChanged(nameof(AllergensDisplay));
        }
    }

    // Proprietate calculată pentru a verifica dacă produsul are alergeni
    public bool HasAllergens => Allergens.Count > 0;

    // Proprietate calculată pentru afișarea listei de alergeni într-un format ușor de citit
    public string AllergensDisplay
    {
        get
        {
            if (!HasAllergens) return string.Empty;

            return string.Join(", ", Allergens.Select(a => a.AllergenName));
        }
    }

    // Adăugăm o proprietate pentru elementele meniului
    private ObservableCollection<MenuItemViewModel>? _menuItems;
    public ObservableCollection<MenuItemViewModel>? MenuItems
    {
        get => _menuItems;
        set
        {
            _menuItems = value;
            OnPropertyChanged();
        }
    }
}