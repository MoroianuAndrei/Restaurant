using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.Views.AdminItemEditPages;
using Restaurant.Views.AdminItemPageViews;
using System.Linq;

namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

public class ProductEditPageViewModel : BaseViewModel
{
    public ProductViewModel Product { get; set; }
    public ObservableCollection<string> Categories { get; set; }
        = new ObservableCollection<string>(CategoryBLL.GetCategories().Select(c => c.CategoryName ?? ""));

    private ObservableCollection<AllergenViewModel> _availableAllergens;
    public ObservableCollection<AllergenViewModel> AvailableAllergens
    {
        get => _availableAllergens;
        set
        {
            _availableAllergens = value;
            OnPropertyChanged();
        }
    }

    private AllergenViewModel? _selectedAllergen;
    public AllergenViewModel? SelectedAllergen
    {
        get => _selectedAllergen;
        set
        {
            _selectedAllergen = value;
            OnPropertyChanged();
        }
    }

    private readonly string? _title;
    public string Title
    {
        get => _title ?? "";
        private init
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public string Category
    {
        get => Product.Category.CategoryName;
        set
        {
            Product.Category = (from category in CategoryBLL.GetCategories().Select(c => c.ToViewModel())
                                where category.CategoryName == value
                                select category).FirstOrDefault() ?? new CategoryViewModel();
            OnPropertyChanged();
        }
    }

    // Proprietate pentru afișarea prețului (evită afișarea valorii 0)
    public string PriceDisplay
    {
        get => Product.Price > 0 ? Product.Price.ToString() : "";
        set
        {
            if (decimal.TryParse(value, out decimal price))
            {
                Product.Price = price;
            }
            else if (string.IsNullOrWhiteSpace(value))
            {
                Product.Price = 0;
            }
            OnPropertyChanged();
        }
    }

    // Proprietate pentru afișarea cantității porției (evită afișarea valorii 0)
    public string PortionQuantityDisplay
    {
        get => Product.PortionQuantity > 0 ? Product.PortionQuantity.ToString() : "";
        set
        {
            if (decimal.TryParse(value, out decimal quantity))
            {
                Product.PortionQuantity = quantity;
            }
            else if (string.IsNullOrWhiteSpace(value))
            {
                Product.PortionQuantity = 0;
            }
            OnPropertyChanged();
        }
    }

    // Proprietate pentru afișarea cantității totale (evită afișarea valorii 0)
    public string TotalQuantityDisplay
    {
        get => Product.TotalQuantity > 0 ? Product.TotalQuantity.ToString() : "";
        set
        {
            if (decimal.TryParse(value, out decimal quantity))
            {
                Product.TotalQuantity = quantity;
            }
            else if (string.IsNullOrWhiteSpace(value))
            {
                Product.TotalQuantity = 0;
            }
            OnPropertyChanged();
        }
    }

    public string? SelectedImagePath
    {
        get => Product.ImagePath is "" or null ? "No image selected" : Product.ImagePath;
        set
        {
            Product.ImagePath = value ?? "";
            ImageVisibility = Product.ImagePath is "" or null ? Visibility.Collapsed : Visibility.Visible;
            OnPropertyChanged();
        }
    }

    public Visibility ImageVisibility
    {
        get => Product.ImagePath is "" or "No image found" or null ? Visibility.Collapsed : Visibility.Visible;
        private set => OnPropertyChanged();
    }

    public ICommand? SaveCommand { get; private set; }
    public ICommand? CancelCommand { get; private set; }
    public ICommand? BrowseForImageCommand { get; private set; }
    public ICommand? AddAllergenCommand { get; private set; }
    public ICommand? RemoveAllergenCommand { get; private set; }

    private string? _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage ?? "";
        private set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    private bool _nameHasError;
    public bool NameHasError
    {
        get => _nameHasError;
        private set
        {
            _nameHasError = value;
            OnPropertyChanged();
        }
    }

    private bool _priceHasError;
    public bool PriceHasError
    {
        get => _priceHasError;
        private set
        {
            _priceHasError = value;
            OnPropertyChanged();
        }
    }

    private bool _categoryHasError;
    public bool CategoryHasError
    {
        get => _categoryHasError;
        private set
        {
            _categoryHasError = value;
            OnPropertyChanged();
        }
    }

    // Default constructor for Add operation
    public ProductEditPageViewModel()
    {
        Product = new ProductViewModel();

        // Ensure Allergens is initialized
        if (Product.Allergens == null)
        {
            Product.Allergens = new ObservableCollection<AllergenViewModel>();
        }

        Title = "Add Product";
        LoadAvailableAllergens();
        InitializeCommands();
    }

    // Constructor for Edit operation
    public ProductEditPageViewModel(ProductViewModel product)
    {
        Product = product;

        // IMPORTANT: The key fix - ensure allergens are loaded from the database for this product
        if (Product.Id > 0)
        {
            // If we're editing an existing product, ensure we have the latest allergens data
            var productFromDb = ProductBLL.GetProductById(Product.Id);
            if (productFromDb != null)
            {
                // Make sure the allergens collection is initialized and populated
                if (Product.Allergens == null || !Product.Allergens.Any())
                {
                    var allergens = AllergenBLL.GetAllergensForProduct(Product.Id)
                        .Select(a => a.ToViewModel())
                        .ToList();

                    Product.Allergens = new ObservableCollection<AllergenViewModel>(allergens);
                }
            }
        }

        // Ensure Allergens is initialized even if no allergens were found
        if (Product.Allergens == null)
        {
            Product.Allergens = new ObservableCollection<AllergenViewModel>();
        }

        Title = "Edit Product";
        LoadAvailableAllergens();
        InitializeCommands();
    }

    private void LoadAvailableAllergens()
    {
        // Get all allergens
        var allAllergens = AllergenBLL.GetAllergens().Select(a => a.ToViewModel()).ToList();

        // Ensure Product.Allergens is initialized
        if (Product.Allergens == null)
        {
            Product.Allergens = new ObservableCollection<AllergenViewModel>();
        }

        // Filter out allergens that are already selected
        var availableAllergens = allAllergens
            .Where(a => !Product.Allergens.Any(pa => pa.Id == a.Id))
            .ToList();

        _availableAllergens = new ObservableCollection<AllergenViewModel>(availableAllergens);

        // Update property to ensure UI reflects changes
        OnPropertyChanged(nameof(AvailableAllergens));
    }

    // Method to update available allergens when selected allergens change
    private void UpdateAvailableAllergens()
    {
        var allAllergens = AllergenBLL.GetAllergens().Select(a => a.ToViewModel()).ToList();

        // Filter out allergens that are already selected
        var availableAllergens = allAllergens
            .Where(a => !Product.Allergens.Any(pa => pa.Id == a.Id))
            .ToList();

        AvailableAllergens = new ObservableCollection<AllergenViewModel>(availableAllergens);
    }

    private void InitializeCommands()
    {
        SaveCommand = new RelayCommand<object>(o =>
        {
            // Reset error states
            ErrorMessage = "";
            NameHasError = false;
            PriceHasError = false;
            CategoryHasError = false;

            // Validate product name
            if (string.IsNullOrWhiteSpace(Product.ProductName))
            {
                ErrorMessage = "Name is required";
                NameHasError = true;
                return;
            }

            // Validate price
            if (Product.Price <= 0)
            {
                ErrorMessage = "Price must be greater than zero";
                PriceHasError = true;
                return;
            }

            // Validate category
            if (string.IsNullOrEmpty(Product.Category.CategoryName))
            {
                ErrorMessage = "Category is required";
                CategoryHasError = true;
                return;
            }

            // Save product based on whether it's a new product or an existing one
            if (Product.Id == 0) // New product
            {
                var productEntity = Product.ToDTO();
                ProductBLL.AddProduct(productEntity);

                ProductAllergenBLL.AssignAllergenToProduct(productEntity.Id, Product.Allergens);
            }
            else // Existing product
            {
                ProductBLL.EditProduct(Product.ToDTO());

                ProductAllergenBLL.AssignAllergenToProduct(Product.Id, Product.Allergens);
            }

            // Navigate back to product page
            var page = o as ProductEditPage;
            page?.NavigationService?.Navigate(new ProductPage());
        });

        CancelCommand = new RelayCommand<object>(o =>
        {
            var page = o as ProductEditPage;
            page?.NavigationService?.Navigate(new ProductPage());
        });

        BrowseForImageCommand = new RelayCommand<object>(_ =>
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select an image",
                Filter = "Image files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() != true)
            {
                return;
            }

            if (!File.Exists(dialog.FileName))
            {
                return;
            }

            SelectedImagePath = dialog.FileName;
        });

        AddAllergenCommand = new RelayCommand<object>(_ =>
        {
            if (SelectedAllergen == null)
                return;

            // Add the selected allergen to the product
            Product.Allergens.Add(SelectedAllergen);

            // Update the available allergens list
            UpdateAvailableAllergens();

            // Reset selection
            SelectedAllergen = null;
        });

        RemoveAllergenCommand = new RelayCommand<object>(allergen =>
        {
            if (allergen is AllergenViewModel allergenToRemove)
            {
                // Remove the allergen from the product
                Product.Allergens.Remove(allergenToRemove);

                // Update the available allergens list to include the removed allergen
                UpdateAvailableAllergens();
            }
        });
    }
}