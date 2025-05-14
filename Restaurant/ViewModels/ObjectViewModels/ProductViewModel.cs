using System.Collections.ObjectModel;
using System.ComponentModel;
using Restaurant.ViewModels;
using System.Configuration;

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

    public bool IsLowStock => TotalQuantity <= int.Parse(ConfigurationManager.AppSettings["ProductLowQuantityThreshold"]);

    private CategoryViewModel? _category;
    public CategoryViewModel Category
    {
        get => _category ?? new CategoryViewModel();
        set
        {
            _category = value;
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

    // Proprietăți pentru imagine
    private string? _imagePath;
    public string ImagePath
    {
        get => _imagePath ?? "";
        set
        {
            _imagePath = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasImage));
        }
    }

    private string? _imageDescription;
    public string ImageDescription
    {
        get => _imageDescription ?? "";
        set
        {
            _imageDescription = value;
            OnPropertyChanged();
        }
    }

    // Proprietate calculată pentru a verifica dacă produsul are imagine
    public bool HasImage => !string.IsNullOrEmpty(ImagePath);

    // Colecție de alergeni pentru produs
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
}