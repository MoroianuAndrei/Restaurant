using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;

namespace Restaurant.Models.DataAccessLayer;

public static class OrderItemDAL
{
    public static IEnumerable<OrderItem> GetOrderItems()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var orderItems = new List<OrderItem>();

            while (reader.Read())
            {
                var orderItem = new OrderItem
                {
                    OrderId = (int)reader["OrderId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (int)reader["Quantity"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    IsMenu = (bool)reader["IsMenu"]
                };
                orderItems.Add(orderItem);
            }

            reader.Close();

            return orderItems;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<OrderItem>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static IEnumerable<OrderItem> GetOrderItemsByOrderId(int orderId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemSelectByOrderId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", orderId);

            connection.Open();

            var reader = command.ExecuteReader();
            var orderItems = new List<OrderItem>();

            while (reader.Read())
            {
                var orderItem = new OrderItem
                {
                    OrderId = (int)reader["OrderId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (int)reader["Quantity"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    IsMenu = (bool)reader["IsMenu"]
                };
                orderItems.Add(orderItem);
            }

            reader.Close();

            return orderItems;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<OrderItem>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static OrderItem GetOrderItem(int orderId, int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", orderId);
            command.Parameters.AddWithValue("@ProductId", productId);

            connection.Open();

            var reader = command.ExecuteReader();
            var orderItem = new OrderItem();

            if (reader.Read())
            {
                orderItem.OrderId = (int)reader["OrderId"];
                orderItem.ProductId = (int)reader["ProductId"];
                orderItem.Quantity = (int)reader["Quantity"];
                orderItem.UnitPrice = (decimal)reader["UnitPrice"];
                orderItem.IsMenu = (bool)reader["IsMenu"];
            }

            reader.Close();

            return orderItem;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new OrderItem();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool InsertOrderItem(OrderItem orderItem)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", orderItem.OrderId);
            command.Parameters.AddWithValue("@ProductId", orderItem.ProductId);
            command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
            command.Parameters.AddWithValue("@UnitPrice", orderItem.UnitPrice);
            command.Parameters.AddWithValue("@IsMenu", orderItem.IsMenu);

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

    public static bool UpdateOrderItem(OrderItem orderItem)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", orderItem.OrderId);
            command.Parameters.AddWithValue("@ProductId", orderItem.ProductId);
            command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
            command.Parameters.AddWithValue("@UnitPrice", orderItem.UnitPrice);
            command.Parameters.AddWithValue("@IsMenu", orderItem.IsMenu);

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

    public static bool DeleteOrderItem(OrderItem orderItem)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", orderItem.OrderId);
            command.Parameters.AddWithValue("@ProductId", orderItem.ProductId);

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

    public static bool DeleteOrderItemsByOrderId(int orderId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemDeleteByOrderId", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", orderId);

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