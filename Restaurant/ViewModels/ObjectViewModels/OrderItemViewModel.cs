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

    private int _productId;
    public int ProductId
    {
        get => _productId;
        set
        {
            _productId = value;
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
}