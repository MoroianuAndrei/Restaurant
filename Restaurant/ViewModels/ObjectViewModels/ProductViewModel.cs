using System.ComponentModel;
using Restaurant.ViewModels;

namespace Restaurant.ViewModels.ObjectViewModels;

public class ProductViewModel : BaseViewModel
{
    private readonly int _id;
    public int Id
    {
        get => _id;
        init
        {
            _id = value;
            OnPropertyChanged();
        }
    }

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

    private decimal _portionQuantity;
    public decimal PortionQuantity
    {
        get => _portionQuantity;
        set
        {
            _portionQuantity = value;
            OnPropertyChanged();
        }
    }

    private string? _measurementUnit;
    public string MeasurementUnit
    {
        get => _measurementUnit ?? "";
        set
        {
            _measurementUnit = value;
            OnPropertyChanged();
        }
    }

    private decimal _totalQuantity;
    public decimal TotalQuantity
    {
        get => _totalQuantity;
        set
        {
            _totalQuantity = value;
            OnPropertyChanged();
        }
    }

    private int _categoryId;
    public int CategoryId
    {
        get => _categoryId;
        set
        {
            _categoryId = value;
            OnPropertyChanged();
        }
    }

    private bool? _isMenu;
    public bool? IsMenu
    {
        get => _isMenu;
        set
        {
            _isMenu = value;
            OnPropertyChanged();
        }
    }

    private string? _categoryName;
    public string CategoryName
    {
        get => _categoryName ?? "";
        set
        {
            _categoryName = value;
            OnPropertyChanged();
        }
    }
}