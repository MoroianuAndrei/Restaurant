namespace Restaurant.ViewModels.ObjectViewModels;

public class AllergenViewModel : BaseViewModel
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

    private string? _allergenName;
    public string AllergenName
    {
        get => _allergenName ?? "";
        set
        {
            _allergenName = value;
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