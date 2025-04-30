using Microsoft.Data.SqlClient;
using Restaurant.Services;

namespace Restaurant.Models.DataAccessLayer.Helpers;

public static class DALHelper
{
    public static SqlConnection Connection => new(ConfigurationManager.GetConnectionString());
}