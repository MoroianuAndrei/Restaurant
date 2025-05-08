//using System.Collections.ObjectModel;
//using Restaurant.Extensions.Mapping;
//using Restaurant.Models.BusinessLogicLayer;
//using Restaurant.ViewModels.ObjectViewModels;

//namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels;

//public class OrderPageViewModel : BaseViewModel
//{
//    public ObservableCollection<OrderViewModel> Receipts { get; } 
//        = new(OrderBLL.GetOrders().Select(r => r.ToViewModel()));
//}