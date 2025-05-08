//using System.Collections.ObjectModel;
//using System.Globalization;
//using System.Windows;
//using Restaurant.Extensions.EnumExtensions;
//using Restaurant.Extensions.Mapping;
//using Restaurant.Models.BusinessLogicLayer;
//using Restaurant.Models.EntityLayer.Enums;
//using Restaurant.ViewModels.ObjectViewModels;

//namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels;

//public class ReportsPageViewModel : BaseViewModel
//{
//    public ObservableCollection<CategoryViewModel> Categories { get; set; }
//        = new(CategoryBLL.GetCategories().Select(c => c.ToViewModel()));

//    public ObservableCollection<ProductViewModel> Products { get; set; }
//        = new(ProductBLL.GetProducts().Select(p => p.ToViewModel()));

//    public ObservableCollection<Tuple<CategoryViewModel, float>> ValuesByCategoryReport { get; set; }
//        = new(ReportQueries.GetValueOfCategories()
//            .Select(t => new Tuple<CategoryViewModel, float>(t.Item1.ToViewModel(), t.Item2)));

//    private ObservableCollection<Tuple<DateOnly, float>>? _incomeByMonthReport;
//    public ObservableCollection<Tuple<DateOnly, float>> IncomeByMonthReport
//    {
//        get => _incomeByMonthReport ?? [];
//        private set
//        {
//            _incomeByMonthReport = value;
//            OnPropertyChanged();
//        }
//    }

//    private UserViewModel? _selectedUser;
//    public UserViewModel SelectedUser
//    {
//        get => _selectedUser ?? new UserViewModel();
//        set
//        {
//            _selectedUser = value;
//            IncomeByMonthReport = new ObservableCollection<Tuple<DateOnly, float>>(
//                ReportQueries.GetIncomeForMonth(SelectedUser.ToDTO(), _selectedMonth ?? EMonth.January));
//            IncomeByMonthReportVisibility = _selectedUser != null && _selectedMonth != null && IncomeByMonthReport.Count > 0
//                ? Visibility.Visible
//                : Visibility.Collapsed;
//            OnPropertyChanged();
//        }
//    }

//    private EMonth? _selectedMonth;
//    public string SelectedMonth
//    {
//        get => _selectedMonth?.ToString() ?? "";
//        set
//        {
//            _selectedMonth = value.ToEMonth();
//            IncomeByMonthReport = new ObservableCollection<Tuple<DateOnly, float>>(
//                ReportQueries.GetIncomeForMonth(SelectedUser.ToDTO(), _selectedMonth ?? EMonth.January));
//            IncomeByMonthReportVisibility = _selectedUser != null && _selectedMonth != null && IncomeByMonthReport.Count > 0
//                ? Visibility.Visible
//                : Visibility.Collapsed;
//            OnPropertyChanged();
//        }
//    }

//    private Visibility _incomeByMonthReportVisibility = Visibility.Collapsed;
//    public Visibility IncomeByMonthReportVisibility
//    {
//        get => _incomeByMonthReportVisibility;
//        set
//        {
//            _incomeByMonthReportVisibility = value;
//            OnPropertyChanged();
//        }
//    }

//    public ObservableCollection<string> Months { get; set; } = EMonthExtension.ToStringCollection();
//    public ObservableCollection<UserViewModel> Cashiers { get; set; }
//        = new(UserBLL.GetUsers()
//                .Where(u => u.UserType == EUserType.Cashier.ToString())
//                .Select(u => u.ToViewModel()));

//    private DateTime? _selectedDate;
//    public string SelectedDate
//    {
//        get => _selectedDate?.ToString("D") ?? "";
//        set
//        {
//            _selectedDate = DateTime.Parse(value, new CultureInfo("en-US"));
//            MostValuableReceipt = ReportQueries.GetMostValuableReceiptByDate(_selectedDate
//                                                                             ?? DateTime.Now).ToViewModel();
//            MostValuableReceiptVisibility = MostValuableReceipt.Id != 0
//                ? Visibility.Visible
//                : Visibility.Collapsed;
//            OnPropertyChanged();
//        }
//    }

//    private ReceiptViewModel? _mostValuableReceipt;
//    public ReceiptViewModel MostValuableReceipt
//    {
//        get => _mostValuableReceipt ?? new ReceiptViewModel();
//        private set
//        {
//            _mostValuableReceipt = value;
//            OnPropertyChanged();
//        }
//    }

//    private Visibility _mostValuableReceiptVisibility = Visibility.Collapsed;
//    public Visibility MostValuableReceiptVisibility
//    {
//        get => _mostValuableReceiptVisibility;
//        set
//        {
//            _mostValuableReceiptVisibility = value;
//            OnPropertyChanged();
//        }
//    }
//}