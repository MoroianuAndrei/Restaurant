using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;

namespace Restaurant.Models.DataAccessLayer;

public static class OrderDAL
{
    public static IEnumerable<Order> GetOrders()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var orders = new List<Order>();

            while (reader.Read())
            {
                var order = new Order
                {
                    OrderId = (int)reader["OrderId"],
                    OrderCode = reader["OrderCode"].ToString()!,
                    UserId = (int)reader["UserId"],
                    OrderDate = (DateTime)reader["OrderDate"],
                    Status = reader["Status"].ToString()!,
                    EstimatedDeliveryTime = reader["EstimatedDeliveryTime"] as DateTime?,
                    SubtotalAmount = (decimal)reader["SubtotalAmount"],
                    DiscountAmount = (decimal)reader["DiscountAmount"],
                    ShippingCost = (decimal)reader["ShippingCost"],
                    TotalAmount = (decimal)reader["TotalAmount"]
                };
                orders.Add(order);
            }

            reader.Close();

            return orders;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Order>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static Order GetOrderById(int orderId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", orderId);

            connection.Open();

            var reader = command.ExecuteReader();
            var order = new Order();

            if (reader.Read())
            {
                order.OrderId = (int)reader["OrderId"];
                order.OrderCode = reader["OrderCode"].ToString()!;
                order.UserId = (int)reader["UserId"];
                order.OrderDate = (DateTime)reader["OrderDate"];
                order.Status = reader["Status"].ToString()!;
                order.EstimatedDeliveryTime = reader["EstimatedDeliveryTime"] as DateTime?;
                order.SubtotalAmount = (decimal)reader["SubtotalAmount"];
                order.DiscountAmount = (decimal)reader["DiscountAmount"];
                order.ShippingCost = (decimal)reader["ShippingCost"];
                order.TotalAmount = (decimal)reader["TotalAmount"];
            }

            reader.Close();

            return order;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Order();
        }
        finally
        {
            connection.Close();
        }
    }

    public static IEnumerable<Order> GetOrdersByUserId(int userId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderSelectByUser", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserId", userId);

            connection.Open();

            var reader = command.ExecuteReader();
            var orders = new List<Order>();

            while (reader.Read())
            {
                var order = new Order
                {
                    OrderId = (int)reader["OrderId"],
                    OrderCode = reader["OrderCode"].ToString()!,
                    UserId = (int)reader["UserId"],
                    OrderDate = (DateTime)reader["OrderDate"],
                    Status = reader["Status"].ToString()!,
                    EstimatedDeliveryTime = reader["EstimatedDeliveryTime"] as DateTime?,
                    SubtotalAmount = (decimal)reader["SubtotalAmount"],
                    DiscountAmount = (decimal)reader["DiscountAmount"],
                    ShippingCost = (decimal)reader["ShippingCost"],
                    TotalAmount = (decimal)reader["TotalAmount"]
                };
                orders.Add(order);
            }

            reader.Close();

            return orders;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Order>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool InsertOrder(Order order)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderCode", order.OrderCode);
            command.Parameters.AddWithValue("@UserId", order.UserId);
            command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            command.Parameters.AddWithValue("@Status", order.Status);
            command.Parameters.AddWithValue("@EstimatedDeliveryTime", order.EstimatedDeliveryTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SubtotalAmount", order.SubtotalAmount);
            command.Parameters.AddWithValue("@DiscountAmount", order.DiscountAmount);
            command.Parameters.AddWithValue("@ShippingCost", order.ShippingCost);
            command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

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

    public static bool UpdateOrder(Order order)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", order.OrderId);
            command.Parameters.AddWithValue("@OrderCode", order.OrderCode);
            command.Parameters.AddWithValue("@UserId", order.UserId);
            command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            command.Parameters.AddWithValue("@Status", order.Status);
            command.Parameters.AddWithValue("@EstimatedDeliveryTime", order.EstimatedDeliveryTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SubtotalAmount", order.SubtotalAmount);
            command.Parameters.AddWithValue("@DiscountAmount", order.DiscountAmount);
            command.Parameters.AddWithValue("@ShippingCost", order.ShippingCost);
            command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

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

    public static bool DeleteOrder(Order order)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OrderId", order.OrderId);

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

    public static IEnumerable<Order> GetOrdersByStatus(string status)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOrderSelectByStatus", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Status", status);

            connection.Open();

            var reader = command.ExecuteReader();
            var orders = new List<Order>();

            while (reader.Read())
            {
                var order = new Order
                {
                    OrderId = (int)reader["OrderId"],
                    OrderCode = reader["OrderCode"].ToString()!,
                    UserId = (int)reader["UserId"],
                    OrderDate = (DateTime)reader["OrderDate"],
                    Status = reader["Status"].ToString()!,
                    EstimatedDeliveryTime = reader["EstimatedDeliveryTime"] as DateTime?,
                    SubtotalAmount = (decimal)reader["SubtotalAmount"],
                    DiscountAmount = (decimal)reader["DiscountAmount"],
                    ShippingCost = (decimal)reader["ShippingCost"],
                    TotalAmount = (decimal)reader["TotalAmount"]
                };
                orders.Add(order);
            }

            reader.Close();

            return orders;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Order>();
        }
        finally
        {
            connection.Close();
        }
    }
}