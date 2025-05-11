using System.Windows.Input;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.Views.AdminItemEditPages;
using Restaurant.Views.AdminItemPageViews;

namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

public class AllergenEditPageViewModel : BaseViewModel
{
    public AllergenViewModel Allergen { get; set; }

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
    public AllergenEditPageViewModel()
    {
        Allergen = new AllergenViewModel();
        Title = "Add Allergen";
        InitializeCommands();
    }

    // Constructor for Edit operation
    public AllergenEditPageViewModel(AllergenViewModel allergen)
    {
        Allergen = allergen;
        Title = "Edit Allergen";
        InitializeCommands();
    }

    private void InitializeCommands()
    {
        SaveCommand = new RelayCommand<object>(o =>
        {
            // Reset error states
            ErrorMessage = "";
            NameHasError = false;

            // Validate allergen name
            if (string.IsNullOrWhiteSpace(Allergen.AllergenName))
            {
                ErrorMessage = "Name is required";
                NameHasError = true;
                return;
            }

            // Save allergen based on whether it's a new allergen or an existing one
            if (Allergen.Id == 0) // New allergen
            {
                AllergenBLL.AddAllergen(Allergen.ToDTO());
            }
            else // Existing allergen
            {
                AllergenBLL.EditAllergen(Allergen.ToDTO());
            }

            // Navigate back to allergen page
            var page = o as AllergenEditPage;
            page?.NavigationService?.Navigate(new AllergenPage());
        });

        CancelCommand = new RelayCommand<object>(o =>
        {
            var page = o as AllergenEditPage;
            page?.NavigationService?.Navigate(new AllergenPage());
        });
    }
}