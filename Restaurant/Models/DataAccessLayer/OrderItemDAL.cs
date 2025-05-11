using System;
using System.Collections.Generic;
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
                    Id = (int)reader["Id"],
                    OrderId = (int)reader["OrderId"],
                    ProductId = reader["ProductId"] != DBNull.Value ? (int?)reader["ProductId"] : null,
                    MenuId = reader["MenuId"] != DBNull.Value ? (int?)reader["MenuId"] : null,
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
                    Id = (int)reader["Id"],
                    OrderId = (int)reader["OrderId"],
                    ProductId = reader["ProductId"] != DBNull.Value ? (int?)reader["ProductId"] : null,
                    MenuId = reader["MenuId"] != DBNull.Value ? (int?)reader["MenuId"] : null,
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

    public static OrderItem GetOrderItem(int id)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();

            var reader = command.ExecuteReader();
            var orderItem = new OrderItem();

            if (reader.Read())
            {
                orderItem.Id = (int)reader["Id"];
                orderItem.OrderId = (int)reader["OrderId"];
                orderItem.ProductId = reader["ProductId"] != DBNull.Value ? (int?)reader["ProductId"] : null;
                orderItem.MenuId = reader["MenuId"] != DBNull.Value ? (int?)reader["MenuId"] : null;
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

            if (orderItem.ProductId.HasValue)
            {
                command.Parameters.AddWithValue("@ProductId", orderItem.ProductId.Value);
                command.Parameters.AddWithValue("@IsMenu", false);
            }
            else
                command.Parameters.AddWithValue("@ProductId", DBNull.Value);

            if (orderItem.MenuId.HasValue)
            {
                command.Parameters.AddWithValue("@MenuId", orderItem.MenuId.Value);
                command.Parameters.AddWithValue("@IsMenu", true);
            }
            else
                command.Parameters.AddWithValue("@MenuId", DBNull.Value);

            command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
            command.Parameters.AddWithValue("@UnitPrice", orderItem.UnitPrice);

            var idParam = new SqlParameter("@Id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(idParam);

            connection.Open();

            var result = command.ExecuteNonQuery();

            if (result > 0 && idParam.Value != DBNull.Value)
            {
                orderItem.Id = (int)idParam.Value;
                return true;
            }

            return false;
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
            command.Parameters.AddWithValue("@Id", orderItem.Id);
            command.Parameters.AddWithValue("@OrderId", orderItem.OrderId);

            if (orderItem.ProductId.HasValue)
                command.Parameters.AddWithValue("@ProductId", orderItem.ProductId.Value);
            else
                command.Parameters.AddWithValue("@ProductId", DBNull.Value);

            if (orderItem.MenuId.HasValue)
                command.Parameters.AddWithValue("@MenuId", orderItem.MenuId.Value);
            else
                command.Parameters.AddWithValue("@MenuId", DBNull.Value);

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

    public static bool DeleteOrderItem(int id)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Id", id);

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

    // Metodă adițională pentru a obține detalii despre OrderItems cu informații despre produse
    public static IEnumerable<dynamic> GetOrderItemsWithDetails(int orderId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderItemSelectByOrder", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", orderId);

            connection.Open();

            var reader = command.ExecuteReader();
            var orderItems = new List<dynamic>();

            while (reader.Read())
            {
                var orderItem = new
                {
                    Id = (int)reader["Id"],
                    OrderId = (int)reader["OrderId"],
                    ProductId = reader["ProductId"] != DBNull.Value ? (int?)reader["ProductId"] : null,
                    ProductName = reader["ProductName"] != DBNull.Value ? (string)reader["ProductName"] : null,
                    MenuId = reader["MenuId"] != DBNull.Value ? (int?)reader["MenuId"] : null,
                    Quantity = (int)reader["Quantity"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    TotalPrice = (decimal)reader["TotalPrice"],
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
            return new List<dynamic>();
        }
        finally
        {
            connection.Close();
        }
    }
}