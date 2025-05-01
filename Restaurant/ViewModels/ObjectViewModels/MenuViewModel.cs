using System.Collections.ObjectModel;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.ViewModels.ObjectViewModels;

public class MenuViewModel : BaseViewModel
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

    private string? _name;
    public string? Name
    {
        get => _name;
        set 
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    private decimal? _discount;
    public decimal? Discount
    {
        get => _discount;
        set
        {
            _discount = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<MenuItemViewModel> _menuItems = new();
    public ObservableCollection<MenuItemViewModel> MenuItems
    {
        get => _menuItems;
        set
        {
            _menuItems = value;
            OnPropertyChanged();
        }
    }
}