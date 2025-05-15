using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using Restaurant.Extensions.EnumExtensions;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.Models.EntityLayer.Enums;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels
{
    public class ReportsPageViewModel : BaseViewModel
    {
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
            = new(CategoryBLL.GetCategories().Select(c => c.ToViewModel()));

        public ObservableCollection<ProductViewModel> Products { get; set; }
            = new(ProductBLL.GetProducts().Select(p => p.ToViewModel()));

        public ObservableCollection<Tuple<CategoryViewModel, decimal>> ValuesByCategoryReport { get; set; }
            = new(ReportQueries.GetValueOfCategories()
                .Select(t => new Tuple<CategoryViewModel, decimal>(t.Item1.ToViewModel(), t.Item2)));

        private ObservableCollection<Tuple<DateOnly, decimal>>? _incomeByMonthReport;
        public ObservableCollection<Tuple<DateOnly, decimal>> IncomeByMonthReport
        {
            get => _incomeByMonthReport ?? new ObservableCollection<Tuple<DateOnly, decimal>>();
            private set
            {
                _incomeByMonthReport = value;
                OnPropertyChanged();
            }
        }

        private UserViewModel? _selectedUser;
        public UserViewModel SelectedUser
        {
            get => _selectedUser ?? new UserViewModel();
            set
            {
                _selectedUser = value;
                UpdateIncomeByMonthReport();
                OnPropertyChanged();
            }
        }

        private EMonth? _selectedMonth;
        public string SelectedMonth
        {
            get => _selectedMonth?.ToString() ?? "";
            set
            {
                _selectedMonth = value.ToEMonth();
                UpdateIncomeByMonthReport();
                OnPropertyChanged();
            }
        }

        private void UpdateIncomeByMonthReport()
        {
            if (_selectedUser != null && _selectedMonth.HasValue)
            {
                IncomeByMonthReport = new ObservableCollection<Tuple<DateOnly, decimal>>(
                    ReportQueries.GetIncomeForMonth(_selectedUser.ToDTO(), _selectedMonth.Value));

                IncomeByMonthReportVisibility = IncomeByMonthReport.Count > 0
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }

        private Visibility _incomeByMonthReportVisibility = Visibility.Collapsed;
        public Visibility IncomeByMonthReportVisibility
        {
            get => _incomeByMonthReportVisibility;
            set
            {
                _incomeByMonthReportVisibility = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Months { get; set; } = EMonthExtension.ToStringCollection();

        public ObservableCollection<UserViewModel> Clients { get; set; }
            = new(UserBLL.GetUsers()
                .Where(u => u.UserType == EUserType.Client.ToString())
                .Select(u => u.ToViewModel()));

        private DateTime? _selectedDate;
        public string SelectedDate
        {
            get => _selectedDate?.ToString("D") ?? "";
            set
            {
                if (DateTime.TryParse(value, new CultureInfo("en-US"), out DateTime parsedDate))
                {
                    _selectedDate = parsedDate;
                    MostValuableOrder = ReportQueries.GetMostValuableOrderByDate(_selectedDate.Value).ToViewModel();
                    MostValuableOrderVisibility = MostValuableOrder.Id != 0
                        ? Visibility.Visible
                        : Visibility.Collapsed;
                    OnPropertyChanged();
                }
            }
        }

        private OrderViewModel? _mostValuableOrder;
        public OrderViewModel MostValuableOrder
        {
            get => _mostValuableOrder ?? new OrderViewModel();
            private set
            {
                _mostValuableOrder = value;
                OnPropertyChanged();
            }
        }

        private Visibility _mostValuableOrderVisibility = Visibility.Collapsed;
        public Visibility MostValuableOrderVisibility
        {
            get => _mostValuableOrderVisibility;
            set
            {
                _mostValuableOrderVisibility = value;
                OnPropertyChanged();
            }
        }

        // Most sold product by category section
        private CategoryViewModel? _selectedCategoryForMostSoldProduct;
        public CategoryViewModel SelectedCategoryForMostSoldProduct
        {
            get => _selectedCategoryForMostSoldProduct ?? new CategoryViewModel();
            set
            {
                _selectedCategoryForMostSoldProduct = value;

                if (_selectedCategoryForMostSoldProduct != null && _selectedCategoryForMostSoldProduct.Id > 0)
                {
                    // Get the most sold product from the selected category
                    MostSoldProductByCategory = ReportQueries
                        .GetMostSoldProductByCategory(_selectedCategoryForMostSoldProduct.Id)
                        .ToViewModel();

                    MostSoldProductByCategoryVisibility = MostSoldProductByCategory?.Id > 0
                        ? Visibility.Visible
                        : Visibility.Collapsed;
                }
                else
                {
                    MostSoldProductByCategoryVisibility = Visibility.Collapsed;
                }

                OnPropertyChanged();
            }
        }

        private ProductViewModel? _mostSoldProductByCategory;
        public ProductViewModel MostSoldProductByCategory
        {
            get => _mostSoldProductByCategory ?? new ProductViewModel();
            private set
            {
                _mostSoldProductByCategory = value;
                OnPropertyChanged();
            }
        }

        private Visibility _mostSoldProductByCategoryVisibility = Visibility.Collapsed;
        public Visibility MostSoldProductByCategoryVisibility
        {
            get => _mostSoldProductByCategoryVisibility;
            set
            {
                _mostSoldProductByCategoryVisibility = value;
                OnPropertyChanged();
            }
        }
    }
}