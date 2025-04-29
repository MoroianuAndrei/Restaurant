using Restaurant;
using Restaurant.Views.PageViews;

namespace Restaurant.ViewModels.WindowViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private object? _currentPage;

    public object? CurrentPage
    {
        get => _currentPage;
        private set
        {
            _currentPage = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel()
    {
        CurrentPage = new LoginPage();
    }
}