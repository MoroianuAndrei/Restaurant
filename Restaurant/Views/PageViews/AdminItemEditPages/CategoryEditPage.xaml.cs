using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

namespace Restaurant.Views.AdminItemEditPages;

public partial class CategoryEditPage
{
    public CategoryEditPage()
    {
        InitializeComponent();
    }

    public CategoryEditPage(CategoryViewModel category)
    {
        InitializeComponent();
        DataContext = new CategoryEditPageViewModel(category);
    }
}