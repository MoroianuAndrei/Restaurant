//using System.Collections.ObjectModel;
//using System.Windows.Input;
//using Restaurant.Extensions.Mapping;
//using Restaurant.Models.BusinessLogicLayer;
//using Restaurant.ViewModels.Commands;
//using Restaurant.ViewModels.ObjectViewModels;
//using Restaurant.Views.AdminItemEditPages;
//using Restaurant.Views.AdminItemPageViews;
//using MessageBox = Wpf.Ui.Controls.MessageBox;
//using MessageBoxResult = Wpf.Ui.Controls.MessageBoxResult;

//namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels;

//public class ProducerPageViewModel : BaseViewModel
//{
//    public ObservableCollection<ProducerViewModel> Producers { get; set; } 
//        = new(ProducerBLL.GetProducers().Select(p => p.ToViewModel()));
//    public ICommand AddNewCommand { get; }
//    public ICommand EditCommand { get; }
//    public ICommand RemoveCommand { get; }
    
//    public ProducerPageViewModel()
//    {
//        AddNewCommand = new RelayCommand<object>(obj =>
//        {
//            if (obj is not ProducerPage currentPage)
//            {
//                return;
//            }
        
//            var producerEditPage = new ProducerEditPage();
        
//            currentPage.NavigationService?.Navigate(producerEditPage);
//        });
        
//        EditCommand = new RelayCommand<object>(obj =>
//        {
//            if (obj is not object[] values) return;

//            if (values[0] is not ProducerViewModel producer || values[1] is not ProducerPage currentPage)
//            {
//                return;
//            }
        
//            var producerEditPage = new ProducerEditPage(producer);
        
//            currentPage.NavigationService?.Navigate(producerEditPage);
//        });
        
//        RemoveCommand = new RelayCommand<object>(Remove);
//    }

//    private void Remove(object? obj)
//    {
//        if (obj is not ProducerViewModel producer)
//        {
//            return;
//        }
        
//        if (ProductBLL.GetProducts().Any(p => p.Id == producer.Id))
//        {
//            var errDialog = new MessageBox
//            {
//                Title = "Error",
//                Content = "This producer is used in products.\nYou cannot delete it."
//            };
            
//            errDialog.ShowDialogAsync();
//            return;
//        }

//        var dialog = new MessageBox
//        {
//            Title = "Confirmation",
//            Content = "Are you sure you want to delete this producer?",
//            PrimaryButtonText = "Yes",
//            CloseButtonText = "No"
//        };
        
//        var result = dialog.ShowDialogAsync().Result;

//        if (result != MessageBoxResult.Primary) return;
        
//        if (ProducerBLL.DeleteProducer(producer.ToDTO()))
//        {
//            Producers.Remove(producer);
//        }
//    }
//}