using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;

namespace Restaurant.Models.DataAccessLayer;

public static class ProductImageDAL
{
    public static IEnumerable<ProductImage> GetProductImages()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductImageSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var productImages = new List<ProductImage>();

            while (reader.Read())
            {
                var productImage = new ProductImage
                {
                    ImageId = (int)reader["ImageId"],
                    ProductId = (int)reader["ProductId"],
                    ImagePath = reader["ImagePath"].ToString()!,
                    ImageDescription = reader["ImageDescription"].ToString()
                };
                productImages.Add(productImage);
            }

            reader.Close();

            return productImages;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<ProductImage>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static ProductImage GetProductImageById(int imageId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductImageSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ImageId", imageId);

            connection.Open();

            var reader = command.ExecuteReader();
            var productImage = new ProductImage();

            if (reader.Read())
            {
                productImage.ImageId = (int)reader["ImageId"];
                productImage.ProductId = (int)reader["ProductId"];
                productImage.ImagePath = reader["ImagePath"].ToString()!;
                productImage.ImageDescription = reader["ImageDescription"].ToString();
            }

            reader.Close();

            return productImage;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new ProductImage();
        }
        finally
        {
            connection.Close();
        }
    }

    public static IEnumerable<ProductImage> GetProductImagesByProductId(int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductImageSelectByProductId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", productId);

            connection.Open();

            var reader = command.ExecuteReader();
            var productImages = new List<ProductImage>();

            while (reader.Read())
            {
                var productImage = new ProductImage
                {
                    ImageId = (int)reader["ImageId"],
                    ProductId = (int)reader["ProductId"],
                    ImagePath = reader["ImagePath"].ToString()!,
                    ImageDescription = reader["ImageDescription"].ToString()
                };
                productImages.Add(productImage);
            }

            reader.Close();

            return productImages;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<ProductImage>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool InsertProductImage(ProductImage productImage)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductImageInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", productImage.ProductId);
            command.Parameters.AddWithValue("@ImagePath", productImage.ImagePath);
            command.Parameters.AddWithValue("@ImageDescription",
                productImage.ImageDescription ?? (object)DBNull.Value);

            connection.Open();

            var result = command.ExecuteNonQuery();
            return result > 0;
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

    public static bool UpdateProductImage(ProductImage productImage)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductImageUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ImageId", productImage.ImageId);
            command.Parameters.AddWithValue("@ProductId", productImage.ProductId);
            command.Parameters.AddWithValue("@ImagePath", productImage.ImagePath);
            command.Parameters.AddWithValue("@ImageDescription",
                productImage.ImageDescription ?? (object)DBNull.Value);

            connection.Open();

            var result = command.ExecuteNonQuery();
            return result > 0;
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

    public static bool DeleteProductImage(ProductImage productImage)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductImageDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ImageId", productImage.ImageId);

            connection.Open();

            var result = command.ExecuteNonQuery();
            return result > 0;
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

    public static bool DeleteProductImagesByProductId(int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductImageDeleteByProductId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", productId);

            connection.Open();

            var result = command.ExecuteNonQuery();
            return result > 0;
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