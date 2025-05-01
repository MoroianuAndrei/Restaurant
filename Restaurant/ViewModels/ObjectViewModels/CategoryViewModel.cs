namespace Restaurant.ViewModels.ObjectViewModels;

public class CategoryViewModel : BaseViewModel
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

    private string? _categoryName;
    public string CategoryName
    {
        get => _categoryName ?? "";
        set
        {
            _categoryName = value;
            OnPropertyChanged();
        }
    }

    private string? _description;
    public string Description
    {
        get => _description ?? "";
        set
        {
            _description = value;
            OnPropertyChanged();
        }
    }
}