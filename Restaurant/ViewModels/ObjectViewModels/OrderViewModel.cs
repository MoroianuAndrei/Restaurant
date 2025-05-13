using System.Collections.ObjectModel;

namespace Restaurant.ViewModels.ObjectViewModels;

public class OrderViewModel : BaseViewModel
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

    private string? _orderCode;
    public string OrderCode
    {
        get => _orderCode ?? "";
        set
        {
            _orderCode = value;
            OnPropertyChanged();
        }
    }

    private int _userId;
    public int UserId
    {
        get => _userId;
        set
        {
            _userId = value;
            OnPropertyChanged();
        }
    }

    private DateTime _orderDate;
    public DateTime OrderDate
    {
        get => _orderDate;
        set
        {
            _orderDate = value;
            OnPropertyChanged();
        }
    }

    private string? _status;
    public string Status
    {
        get => _status ?? "";
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsEditableStatus));

                // Salvează în BLL
                Restaurant.Models.BusinessLogicLayer.OrderBLL.UpdateOrderStatus(Id, _status);
            }
        }
    }


    public bool IsEditableStatus => Status.Equals("Inregistrata", StringComparison.OrdinalIgnoreCase);

    private DateTime? _estimatedDeliveryTime;
    public DateTime? EstimatedDeliveryTime
    {
        get => _estimatedDeliveryTime;
        set
        {
            _estimatedDeliveryTime = value;
            OnPropertyChanged();
        }
    }

    private decimal _subtotalAmount;
    public decimal SubtotalAmount
    {
        get => _subtotalAmount;
        set
        {
            _subtotalAmount = value;
            OnPropertyChanged();
            // Recalculate total when subtotal changes
            CalculateTotal();
        }
    }

    private decimal _discountAmount;
    public decimal DiscountAmount
    {
        get => _discountAmount;
        set
        {
            _discountAmount = value;
            OnPropertyChanged();
            // Recalculate total when discount changes
            CalculateTotal();
        }
    }

    private decimal _shippingCost;
    public decimal ShippingCost
    {
        get => _shippingCost;
        set
        {
            _shippingCost = value;
            OnPropertyChanged();
            // Recalculate total when shipping cost changes
            CalculateTotal();
        }
    }

    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get => _totalAmount;
        set
        {
            _totalAmount = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<OrderItemViewModel> _orderItems = new();
    public ObservableCollection<OrderItemViewModel> OrderItems
    {
        get => _orderItems;
        set
        {
            _orderItems = value;
            OnPropertyChanged();
        }
    }

    // Helper method to calculate total amount
    private void CalculateTotal()
    {
        TotalAmount = SubtotalAmount - DiscountAmount + ShippingCost;
    }
}