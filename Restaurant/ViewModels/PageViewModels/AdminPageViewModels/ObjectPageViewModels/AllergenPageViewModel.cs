using System.Collections.ObjectModel;
using System.Windows.Input;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.Views.AdminItemEditPages;
using Restaurant.Views.AdminItemPageViews;
using Wpf.Ui.Controls;

namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels;

public class AllergenPageViewModel : BaseViewModel
{
    public ObservableCollection<AllergenViewModel> Allergens { get; set; }
        = new(AllergenBLL.GetAllergens().Select(a => a.ToViewModel()));

    public ICommand AddNewCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand RemoveCommand { get; }

    public AllergenPageViewModel()
    {
        AddNewCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not AllergenPage currentPage)
            {
                return;
            }

            var allergenEditPage = new AllergenEditPage();

            currentPage.NavigationService?.Navigate(allergenEditPage);
        });

        EditCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not object[] values) return;

            if (values[0] is not AllergenViewModel allergen || values[1] is not AllergenPage currentPage)
            {
                return;
            }

            var allergenEditPage = new AllergenEditPage(allergen);

            currentPage.NavigationService?.Navigate(allergenEditPage);
        });

        RemoveCommand = new RelayCommand<object>(Remove);
    }

    private void Remove(object? obj)
    {
        if (obj is not AllergenViewModel allergen)
        {
            return;
        }

        // Check if allergen is used in any products
        var productsWithAllergen = ProductBLL.GetProducts()
            .Where(p => p.Allergens?.Any(a => a.AllergenId == allergen.Id) ?? false);

        if (productsWithAllergen.Any())
        {
            var errDialog = new MessageBox
            {
                Title = "Error",
                Content = "This allergen is used in products.\nPlease take out the allergen from product first."
            };

            errDialog.ShowDialogAsync();
            return;
        }

        var dialog = new MessageBox
        {
            Title = "Confirmation",
            Content = "Are you sure you want to delete this allergen?",
            PrimaryButtonText = "Yes",
            CloseButtonText = "No"
        };

        var result = dialog.ShowDialogAsync().Result;

        if (result != MessageBoxResult.Primary) return;

        if (AllergenBLL.DeleteAllergen(allergen.ToDTO()))
        {
            Allergens.Remove(allergen);
        }
    }
}