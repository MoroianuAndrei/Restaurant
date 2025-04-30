using System.Configuration;
using System.IO;
namespace Restaurant.Services;

public static class ConfigurationManager
{
    public static string? GetSetting(string settingName)
    {
        try
        {
            return System.Configuration.ConfigurationManager.AppSettings[settingName];
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error reading configuration settings.");
            return null;
        }
    }

    public static string? GetConnectionString()
    {
        try
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["RestaurantDb"]?.ConnectionString;
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error reading connection string.");
            return null;
        }
    }

    public static string? GetConnectionStringDbContext()
    {
        try
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["RestaurantDb"]?.ConnectionString;
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error reading connection string.");
            return null;
        }
    }
}