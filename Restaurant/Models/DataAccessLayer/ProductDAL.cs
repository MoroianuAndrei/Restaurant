using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;

namespace Restaurant.Models.DataAccessLayer;

public static class ProductDAL
{
    public static IEnumerable<Product> GetProducts()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

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
                    IsMenu = (bool)reader["IsMenu"]
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

    public static Product GetProductById(int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", productId);

            connection.Open();

            var reader = command.ExecuteReader();
            var product = new Product();

            if (reader.Read())
            {
                product.ProductId = (int)reader["ProductId"];
                product.ProductName = reader["ProductName"].ToString()!;
                product.Price = (decimal)reader["Price"];
                product.PortionQuantity = (decimal)reader["PortionQuantity"];
                product.MeasurementUnit = reader["MeasurementUnit"].ToString()!;
                product.TotalQuantity = (decimal)reader["TotalQuantity"];
                product.CategoryId = (int)reader["CategoryId"];
                product.IsMenu = (bool)reader["IsMenu"];
            }

            reader.Close();

            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Product();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool InsertProduct(Product product)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@PortionQuantity", product.PortionQuantity);
            command.Parameters.AddWithValue("@MeasurementUnit", product.MeasurementUnit);
            command.Parameters.AddWithValue("@TotalQuantity", product.TotalQuantity);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@IsMenu", product.IsMenu);

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

    public static bool UpdateProduct(Product product)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", product.ProductId);
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@PortionQuantity", product.PortionQuantity);
            command.Parameters.AddWithValue("@MeasurementUnit", product.MeasurementUnit);
            command.Parameters.AddWithValue("@TotalQuantity", product.TotalQuantity);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@IsMenu", product.IsMenu);

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

    public static bool DeleteProduct(Product product)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", product.ProductId);

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

    public static IEnumerable<Product> GetMenuProducts()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductSelectAllMenus", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

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
                    IsMenu = (bool)reader["IsMenu"]
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

    public static IEnumerable<Product> GetNonMenuProducts()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductSelectAllNonMenus", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

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
                    IsMenu = (bool)reader["IsMenu"]
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

    public static IEnumerable<Product> GetProductsByCategory(int categoryId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductSelectByCategory", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CategoryId", categoryId);

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
                    IsMenu = (bool)reader["IsMenu"]
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
}