using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;

namespace Restaurant.Models.DataAccessLayer;

public static class CategoryDAL
{
    public static IEnumerable<Category> GetCategories()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategorySelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var categories = new List<Category>();

            while (reader.Read())
            {
                var category = new Category
                {
                    CategoryId = (int)reader["CategoryId"],
                    CategoryName = reader["CategoryName"].ToString()!,
                    Description = reader["Description"].ToString()
                };
                categories.Add(category);
            }

            reader.Close();

            return categories;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Category>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static Category GetCategoryById(int categoryId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategorySelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CategoryId", categoryId);

            connection.Open();

            var reader = command.ExecuteReader();
            var category = new Category();

            if (reader.Read())
            {
                category.CategoryId = (int)reader["CategoryId"];
                category.CategoryName = reader["CategoryName"].ToString()!;
                category.Description = reader["Description"].ToString();
            }

            reader.Close();

            return category;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Category();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool InsertCategory(Category category)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategoryInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            command.Parameters.AddWithValue("@Description", category.Description ?? (object)DBNull.Value);

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

    public static bool UpdateCategory(Category category)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategoryUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            command.Parameters.AddWithValue("@Description", category.Description ?? (object)DBNull.Value);

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

    public static bool DeleteCategory(Category category)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategoryDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CategoryId", category.CategoryId);

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