using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;

namespace Restaurant.Models.DataAccessLayer
{
    public static class MenuDAL
    {
        public static IEnumerable<Menu> GetMenus()
        {
            var connection = DALHelper.Connection;
            try
            {
                var command = new SqlCommand("spMenuSelectAll", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();

                var reader = command.ExecuteReader();
                var menus = new List<Menu>();

                while (reader.Read())
                {
                    var menu = new Menu
                    {
                        MenuId = (int)reader["MenuId"],
                        Name = reader["Name"].ToString()!,
                        Discount = reader["Discount"] != DBNull.Value ? (decimal?)reader["Discount"] : null
                    };
                    menus.Add(menu);
                }

                reader.Close();

                return menus;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Menu>();
            }
            finally
            {
                connection.Close();
            }
        }

        public static Menu GetMenuById(int menuId)
        {
            var connection = DALHelper.Connection;
            try
            {
                var command = new SqlCommand("spMenuSelectOne", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuId", menuId);

                connection.Open();

                var reader = command.ExecuteReader();
                var menu = new Menu();

                if (reader.Read())
                {
                    menu.MenuId = (int)reader["MenuId"];
                    menu.Name = reader["Name"].ToString()!;
                    menu.Discount = reader["Discount"] != DBNull.Value ? (decimal?)reader["Discount"] : null;
                }

                reader.Close();

                return menu;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Menu();
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool InsertMenu(Menu menu)
        {
            var connection = DALHelper.Connection;
            try
            {
                var command = new SqlCommand("spMenuInsert", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Name", menu.Name);
                command.Parameters.AddWithValue("@Discount", menu.Discount ?? (object)DBNull.Value);

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

        public static bool UpdateMenu(Menu menu)
        {
            var connection = DALHelper.Connection;
            try
            {
                var command = new SqlCommand("spMenuUpdate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuId", menu.MenuId);
                command.Parameters.AddWithValue("@Name", menu.Name);
                command.Parameters.AddWithValue("@Discount", menu.Discount ?? (object)DBNull.Value);

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

        public static bool DeleteMenu(Menu menu)
        {
            var connection = DALHelper.Connection;
            try
            {
                var command = new SqlCommand("spMenuDelete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuId", menu.MenuId);

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
}