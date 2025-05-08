//using System.Collections.ObjectModel;
//using System.Windows.Input;
//using Restaurant.Extensions.Mapping;
//using Restaurant.Models.BusinessLogicLayer;
//using Restaurant.ViewModels.Commands;
//using Restaurant.ViewModels.ObjectViewModels;
//using Restaurant.Views.AdminItemEditPages;
//using Restaurant.Views.AdminItemPageViews;

//namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels;

//public class StockPageViewModel
//{
//    public ObservableCollection<StockViewModel> Stocks { get; set; } =
//        new(StockBLL.GetStocks().Select(s => s.ToViewModel()));
    
//    public ICommand AddNewCommand { get; }
    
//    public StockPageViewModel()
//    {
//        AddNewCommand = new RelayCommand<object>(o =>
//        {
//            if (o is not StockPage currentPage)
//            {
//                return;
//            }
            
//            var stockEditPage = new StockEditPage();
            
//            currentPage.NavigationService?.Navigate(stockEditPage);
//        });
//    }
//}