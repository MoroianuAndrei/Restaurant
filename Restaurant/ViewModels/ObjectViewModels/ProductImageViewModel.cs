namespace Restaurant.ViewModels.ObjectViewModels;

public class ProductImageViewModel : BaseViewModel
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

    private int _productId;
    public int ProductId
    {
        get => _productId;
        set
        {
            _productId = value;
            OnPropertyChanged();
        }
    }

    private string? _imagePath;
    public string ImagePath
    {
        get => _imagePath ?? "";
        set
        {
            _imagePath = value;
            OnPropertyChanged();
        }
    }

    private string? _imageDescription;
    public string ImageDescription
    {
        get => _imageDescription ?? "";
        set
        {
            _imageDescription = value;
            OnPropertyChanged();
        }
    }

    private string? _productName;
    public string ProductName
    {
        get => _productName ?? "";
        set
        {
            _productName = value;
            OnPropertyChanged();
        }
    }

    // Optional: Add display properties, like preview image, if needed for UI
    private bool _isMainImage;
    public bool IsMainImage
    {
        get => _isMainImage;
        set
        {
            _isMainImage = value;
            OnPropertyChanged();
        }
    }
}