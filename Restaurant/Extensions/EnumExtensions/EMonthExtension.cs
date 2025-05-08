using System.Collections.ObjectModel;
using Restaurant.Models.EntityLayer.Enums;

namespace Restaurant.Extensions.EnumExtensions;

public static class EMonthExtension
{
    public static ObservableCollection<string> ToStringCollection()
    {
        var collection = new ObservableCollection<string>();
        foreach (var month in Enum.GetValues<EMonth>())
        {
            collection.Add(month.ToString());
        }
        return collection;
    }

    public static EMonth ToEMonth(this string month)
    {
        return Enum.Parse<EMonth>(month);
    }

    public static string ToMonthString(this EMonth month)
    {
        return month.ToString();
    }
}