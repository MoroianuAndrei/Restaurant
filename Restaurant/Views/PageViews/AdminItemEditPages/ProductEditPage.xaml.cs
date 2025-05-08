using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

namespace Restaurant.Views.AdminItemEditPages;

public partial class ProductEditPage
{
    public ProductEditPage()
    {
        InitializeComponent();
    }

    public ProductEditPage(ProductViewModel product)
    {
        InitializeComponent();
        DataContext = new ProductEditPageViewModel(product);
    }
}