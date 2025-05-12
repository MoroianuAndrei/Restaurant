using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.BusinessLogicLayer;
using Restaurant.ViewModels.Commands;
using Restaurant.ViewModels.ObjectViewModels;
using Restaurant.Views.AdminItemEditPages;
using Restaurant.Views.AdminItemPageViews;
using Wpf.Ui.Controls;

namespace Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

public class MenuEditPageViewModel : BaseViewModel
{
    public MenuViewModel Menu { get; set; }

    // List of available products for adding to menu
    public ObservableCollection<ProductViewModel> AvailableProducts { get; set; }

    private readonly string? _title;
    public string Title
    {
        get => _title ?? "";
        private init
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public ICommand? SaveCommand { get; private set; }
    public ICommand? CancelCommand { get; private set; }
    public ICommand? AddMenuItemCommand { get; private set; }
    public ICommand? RemoveMenuItemCommand { get; private set; }

    private string? _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage ?? "";
        private set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    private bool _nameHasError;
    public bool NameHasError
    {
        get => _nameHasError;
        private set
        {
            _nameHasError = value;
            OnPropertyChanged();
        }
    }

    // Default constructor for Add operation
    public MenuEditPageViewModel()
    {
        Menu = new MenuViewModel();
        AvailableProducts = new ObservableCollection<ProductViewModel>(
            ProductBLL.GetProducts().Select(p => p.ToViewModel())
        );
        Title = "Add Menu";
        InitializeCommands();
    }

    // Constructor for Edit operation
    public MenuEditPageViewModel(MenuViewModel menu)
    {
        Menu = menu;
        AvailableProducts = new ObservableCollection<ProductViewModel>(
            ProductBLL.GetProducts().Select(p => p.ToViewModel())
        );
        Title = "Edit Menu";

        InitializeCommands();
    }

    private void InitializeCommands()
    {
        SaveCommand = new RelayCommand<object>(o =>
        {
            // Reset error states
            ErrorMessage = "";
            NameHasError = false;

            // Validate menu name
            if (string.IsNullOrWhiteSpace(Menu.Name))
            {
                ErrorMessage = "Name is required";
                NameHasError = true;
                return;
            }

            foreach(var m in Menu.MenuItems)
            {
                System.Windows.MessageBox.Show(m.ProductId + " " + m.MenuId);
            }

            // Save menu based on whether it's a new menu or an existing one
            if (Menu.Id == 0) // New menu
            {
                MenuBLL.AddMenu(Menu.ToDTO());

                foreach (var m in Menu.MenuItems)
                {
                    MenuItemBLL.AddMenuItem(m.ToDTO());
                }
            }
            else // Existing menu
            {
                MenuBLL.EditMenu(Menu.ToDTO());

                foreach (var m in Menu.MenuItems)
                {
                    MenuItemBLL.AddMenuItem(m.ToDTO());
                }
            }

            // Navigate back to menu page
            var page = o as MenuEditPage;
            page?.NavigationService?.Navigate(new MenuPage());
        });

        CancelCommand = new RelayCommand<object>(o =>
        {
            var page = o as MenuEditPage;
            page?.NavigationService?.Navigate(new MenuPage());
        });

        AddMenuItemCommand = new RelayCommand<object>(_ =>
        {
            // Open a dialog to select a product and specify quantity
            var productSelectionDialog = new Window
            {
                Title = "Add Product to Menu",
                Width = 400,
                Height = 300,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            var productComboBox = new ComboBox
            {
                ItemsSource = AvailableProducts,
                DisplayMemberPath = "ProductName",
                Margin = new Thickness(10)
            };
            Grid.SetRow(productComboBox, 0);
            Grid.SetColumn(productComboBox, 0);
            Grid.SetColumnSpan(productComboBox, 2);

            var quantityLabel = new Label { Content = "Quantity:" };
            Grid.SetRow(quantityLabel, 1);
            Grid.SetColumn(quantityLabel, 0);

            var quantityTextBox = new System.Windows.Controls.TextBox
            {
                Text = "1",
                Margin = new Thickness(10)
            };
            Grid.SetRow(quantityTextBox, 1);
            Grid.SetColumn(quantityTextBox, 1);

            var addButton = new System.Windows.Controls.Button
            {
                Content = "Add",
                Margin = new Thickness(10)
            };
            Grid.SetRow(addButton, 2);
            Grid.SetColumn(addButton, 1);

            addButton.Click += (s, e) =>
            {
                var selectedProduct = productComboBox.SelectedItem as ProductViewModel;
                if (selectedProduct == null)
                {
                    System.Windows.MessageBox.Show("Please select a product.");
                    return;
                }

                if (!decimal.TryParse(quantityTextBox.Text, out decimal quantity))
                {
                    System.Windows.MessageBox.Show("Invalid quantity.");
                    return;
                }

                // Create a new menu item
                var newMenuItem = new MenuItemViewModel
                {
                    MenuId = Menu.Id,
                    ProductId = selectedProduct.Id,
                    ProductName = selectedProduct.ProductName,
                    Quantity = quantity,
                    Price = selectedProduct.Price
                };

                // Add to menu items
                Menu.MenuItems.Add(newMenuItem);

                productSelectionDialog.Close();
            };

            grid.Children.Add(productComboBox);
            grid.Children.Add(quantityLabel);
            grid.Children.Add(quantityTextBox);
            grid.Children.Add(addButton);

            productSelectionDialog.Content = grid;
            productSelectionDialog.ShowDialog();
        });

        RemoveMenuItemCommand = new RelayCommand<object>(obj =>
        {
            if (obj is MenuItemViewModel menuItem)
            {
                Menu.MenuItems.Remove(menuItem);
            }
        });
    }
}