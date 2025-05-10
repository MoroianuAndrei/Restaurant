using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;

namespace Restaurant.Models.DataAccessLayer;

public static class AllergenDAL
{
    public static IEnumerable<Allergen> GetAllergens()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spAllergenSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var allergens = new List<Allergen>();

            while (reader.Read())
            {
                var allergen = new Allergen
                {
                    AllergenId = (int)reader["AllergenId"],
                    AllergenName = reader["AllergenName"].ToString()!,
                    Description = reader["Description"].ToString()
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

    public static IEnumerable<Allergen> GetAllergensForProduct(int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spAllergenSelectByProductId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", productId);

            connection.Open();

            var reader = command.ExecuteReader();
            var allergens = new List<Allergen>();

            while (reader.Read())
            {
                var allergen = new Allergen
                {
                    AllergenId = (int)reader["AllergenId"],
                    AllergenName = reader["AllergenName"].ToString()!,
                    Description = reader["Description"].ToString()
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

    public static Allergen GetAllergenById(int allergenId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spAllergenSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@AllergenId", allergenId);

            connection.Open();

            var reader = command.ExecuteReader();
            var allergen = new Allergen();

            if (reader.Read())
            {
                allergen.AllergenId = (int)reader["AllergenId"];
                allergen.AllergenName = reader["AllergenName"].ToString()!;
                allergen.Description = reader["Description"].ToString();
            }

            reader.Close();

            return allergen;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Allergen();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool InsertAllergen(Allergen allergen)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spAllergenInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@AllergenName", allergen.AllergenName);
            command.Parameters.AddWithValue("@Description", allergen.Description ?? (object)DBNull.Value);

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

    public static bool UpdateAllergen(Allergen allergen)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spAllergenUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@AllergenId", allergen.AllergenId);
            command.Parameters.AddWithValue("@AllergenName", allergen.AllergenName);
            command.Parameters.AddWithValue("@Description", allergen.Description ?? (object)DBNull.Value);

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

    public static bool DeleteAllergen(Allergen allergen)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spAllergenDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@AllergenId", allergen.AllergenId);

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