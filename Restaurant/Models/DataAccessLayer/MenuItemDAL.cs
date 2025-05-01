using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;

namespace Restaurant.Models.DataAccessLayer;

public static class MenuItemDAL
{
    public static IEnumerable<MenuItem> GetMenuItems()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spMenuItemSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var menuItems = new List<MenuItem>();

            while (reader.Read())
            {
                var menuItem = new MenuItem
                {
                    MenuId = (int)reader["MenuId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (decimal)reader["Quantity"]
                };
                menuItems.Add(menuItem);
            }

            reader.Close();

            return menuItems;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<MenuItem>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static MenuItem GetMenuItemById(int menuId, int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spMenuItemSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@MenuId", menuId);
            command.Parameters.AddWithValue("@ProductId", productId);

            connection.Open();

            var reader = command.ExecuteReader();
            var menuItem = new MenuItem();

            if (reader.Read())
            {
                menuItem.MenuId = (int)reader["MenuId"];
                menuItem.ProductId = (int)reader["ProductId"];
                menuItem.Quantity = (decimal)reader["Quantity"];
            }

            reader.Close();

            return menuItem;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new MenuItem();
        }
        finally
        {
            connection.Close();
        }
    }

    public static IEnumerable<MenuItem> GetMenuItemsByMenuId(int menuId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spMenuItemSelectByMenuId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@MenuId", menuId);

            connection.Open();

            var reader = command.ExecuteReader();
            var menuItems = new List<MenuItem>();

            while (reader.Read())
            {
                var menuItem = new MenuItem
                {
                    MenuId = (int)reader["MenuId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (decimal)reader["Quantity"]
                };
                menuItems.Add(menuItem);
            }

            reader.Close();

            return menuItems;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<MenuItem>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool InsertMenuItem(MenuItem menuItem)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spMenuItemInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@MenuId", menuItem.MenuId);
            command.Parameters.AddWithValue("@ProductId", menuItem.ProductId);
            command.Parameters.AddWithValue("@Quantity", menuItem.Quantity);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool UpdateMenuItem(MenuItem menuItem)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spMenuItemUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@MenuId", menuItem.MenuId);
            command.Parameters.AddWithValue("@ProductId", menuItem.ProductId);
            command.Parameters.AddWithValue("@Quantity", menuItem.Quantity);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool DeleteMenuItem(MenuItem menuItem)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spMenuItemDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@MenuId", menuItem.MenuId);
            command.Parameters.AddWithValue("@ProductId", menuItem.ProductId);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        finally
        {
            connection.Close();
        }
    }
}