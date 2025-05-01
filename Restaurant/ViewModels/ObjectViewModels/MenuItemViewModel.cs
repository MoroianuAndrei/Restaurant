namespace Restaurant.ViewModels.ObjectViewModels;

public class MenuItemViewModel : BaseViewModel
{
    private int _menuId;
    public int MenuId
    {
        get => _menuId;
        set
        {
            _menuId = value;
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

    private decimal _quantity;
    public decimal Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged();
        }
    }

    // Optional properties for display purposes
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

    private decimal _price;
    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged();
        }
    }

    // Total calculation for this menu item
    public decimal Total => Price * Quantity;
}