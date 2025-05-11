using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

namespace Restaurant.Views.AdminItemEditPages;

public partial class AllergenEditPage
{
    public AllergenEditPage()
    {
        InitializeComponent();
    }

    public AllergenEditPage(AllergenViewModel allergen)
    {
        InitializeComponent();
        DataContext = new AllergenEditPageViewModel(allergen);
    }
}