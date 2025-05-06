using System.Windows.Input;
using Restaurant.ViewModels.Commands;
using Wpf.Ui.Controls;

namespace Restaurant.ViewModels.PageViewModels.CashierPageViewModels;

public class CreateNewReceiptPageViewModel : BaseViewModel
{
    public static NavigationView? NavigationView { get; set; }

    public ICommand SaveReceiptCommand { get; } = new RelayCommand<object?>(_ =>
    {
        // Logic to save receipt
        // Then navigate back to home
        NavigationView?.Navigate("Home");
    });
}