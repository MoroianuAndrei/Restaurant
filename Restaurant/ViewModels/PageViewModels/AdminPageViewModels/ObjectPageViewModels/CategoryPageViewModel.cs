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

public class CategoryPageViewModel : BaseViewModel
{
    public ObservableCollection<CategoryViewModel> Categories { get; set; }
        = new(CategoryBLL.GetCategories().Select(c => c.ToViewModel()));

    public ICommand AddNewCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand RemoveCommand { get; }

    public CategoryPageViewModel()
    {
        AddNewCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not CategoryPage currentPage)
            {
                return;
            }

            //var categoryEditPage = new CategoryEditPage();

            //currentPage.NavigationService?.Navigate(categoryEditPage);
        });

        EditCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not object[] values) return;

            if (values[0] is not CategoryViewModel category || values[1] is not CategoryPage currentPage)
            {
                return;
            }

            //var categoryEditPage = new CategoryEditPage(category);

            //currentPage.NavigationService?.Navigate(categoryEditPage);
        });

        RemoveCommand = new RelayCommand<object>(Remove);
    }

    private void Remove(object? obj)
    {
        if (obj is not CategoryViewModel category)
        {
            return;
        }

        if (ProductBLL.GetProducts().Any(p => p.Category.Id == category.Id))
        {
            var errDialog = new MessageBox
            {
                Title = "Error",
                Content = "There are products in this category.\nPlease delete them first."
            };

            errDialog.ShowDialogAsync();
            return;
        }

        var dialog = new MessageBox
        {
            Title = "Confirmation",
            Content = "Are you sure you want to delete this category?",
            PrimaryButtonText = "Yes",
            CloseButtonText = "No"
        };

        var result = dialog.ShowDialogAsync().Result;

        if (result != MessageBoxResult.Primary) return;

        if (CategoryBLL.DeleteCategory(category.ToDTO()))
        {
            Categories.Remove(category);
        }
    }
}