using System.Windows.Input;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.Views.AdminItemEditPages;
using Restaurant.Views.AdminItemPageViews;

namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

public class CategoryEditPageViewModel : BaseViewModel
{
    public CategoryViewModel Category { get; set; }

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

    public ICommand? SaveCommand { get; private set; }
    public ICommand? CancelCommand { get; private set; }

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

    // Default constructor for Add operation
    public CategoryEditPageViewModel()
    {
        Category = new CategoryViewModel();
        Title = "Add Category";
        InitializeCommands();
    }

    // Constructor for Edit operation
    public CategoryEditPageViewModel(CategoryViewModel category)
    {
        Category = category;
        Title = "Edit Category";
        InitializeCommands();
    }

    private void InitializeCommands()
    {
        SaveCommand = new RelayCommand<object>(o =>
        {
            // Reset error states
            ErrorMessage = "";
            NameHasError = false;

            // Validate category name
            if (string.IsNullOrWhiteSpace(Category.CategoryName))
            {
                ErrorMessage = "Name is required";
                NameHasError = true;
                return;
            }

            // Save category based on whether it's a new category or an existing one
            if (Category.Id == 0) // New category
            {
                CategoryBLL.AddCategory(Category.ToDTO());
            }
            else // Existing category
            {
                CategoryBLL.EditCategory(Category.ToDTO());
            }

            // Navigate back to category page
            var page = o as CategoryEditPage;
            page?.NavigationService?.Navigate(new CategoryPage());
        });

        CancelCommand = new RelayCommand<object>(o =>
        {
            var page = o as CategoryEditPage;
            page?.NavigationService?.Navigate(new CategoryPage());
        });
    }
}