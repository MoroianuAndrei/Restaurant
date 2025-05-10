using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;

namespace Restaurant.Models.DataAccessLayer;

public static class ProductAllergenDAL
{
    public static IEnumerable<Allergen> GetAllergensByProductId(int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductAllergenSelectByProduct", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductID", productId);

            connection.Open();

            var reader = command.ExecuteReader();
            var allergens = new List<Allergen>();

            while (reader.Read())
            {
                var allergen = new Allergen
                {
                    AllergenId = (int)reader["AllergenID"],
                    AllergenName = reader["AllergenName"].ToString()!,
                    // Description nu este inclus în rezultatul procedurii stocate
                    Description = null
                };
                allergens.Add(allergen);
            }

            reader.Close();

            return allergens;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Allergen>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static IEnumerable<Product> GetProductsByAllergenId(int allergenId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductAllergenSelectByAllergenId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@AllergenId", allergenId);

            connection.Open();

            var reader = command.ExecuteReader();
            var products = new List<Product>();

            while (reader.Read())
            {
                var product = new Product
                {
                    ProductId = (int)reader["ProductId"],
                    ProductName = reader["ProductName"].ToString()!,
                    Price = (decimal)reader["Price"],
                    PortionQuantity = (decimal)reader["PortionQuantity"],
                    MeasurementUnit = reader["MeasurementUnit"].ToString()!,
                    TotalQuantity = (decimal)reader["TotalQuantity"],
                    CategoryId = (int)reader["CategoryId"],
                    IsMenu = (bool)reader["IsMenu"],
                    ImagePath = reader["ImagePath"].ToString()
                };
                products.Add(product);
            }

            reader.Close();

            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Product>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool AssignAllergenToProduct(int productId, int allergenId)
    {
        var connection = DALHelper.Connection;
        try
        {
            // First check if the relationship already exists
            var checkCommand = new SqlCommand("spProductAllergenCheckExists", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            checkCommand.Parameters.AddWithValue("@ProductId", productId);
            checkCommand.Parameters.AddWithValue("@AllergenId", allergenId);

            connection.Open();
            var result = (int)checkCommand.ExecuteScalar();

            if (result > 0)
            {
                // Relationship already exists
                return true;
            }

            connection.Close();

            // Insert the relationship if it doesn't exist
            var insertCommand = new SqlCommand("spProductAllergenInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            insertCommand.Parameters.AddWithValue("@ProductId", productId);
            insertCommand.Parameters.AddWithValue("@AllergenId", allergenId);

            connection.Open();

            return insertCommand.ExecuteNonQuery() > 0;
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

    public static bool RemoveAllergenFromProduct(int productId, int allergenId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductAllergenDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", productId);
            command.Parameters.AddWithValue("@AllergenId", allergenId);

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

    public static bool RemoveAllAllergensFromProduct(int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductAllergenDeleteByProductId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", productId);

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

    public static bool RemoveAllProductsWithAllergen(int allergenId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductAllergenDeleteByAllergenId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@AllergenId", allergenId);

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