using System.Collections.ObjectModel;
using Restaurant.Models.EntityLayer.Enums;

namespace Restaurant.Extensions.EnumExtensions;

public static class EStatusExtension
{
    public static ObservableCollection<string> Statuses { get; } =
        new ObservableCollection<string>(Enum.GetNames(typeof(EStatus)));

    public static EStatus ToEStatus(this string status)
    {
        return Enum.Parse<EStatus>(status);
    }

    public static string ToStatusString(this EStatus status)
    {
        return status.ToString();
    }
}
