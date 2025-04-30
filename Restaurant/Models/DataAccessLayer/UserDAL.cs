using System.Data;
using Microsoft.Data.SqlClient;
using Restaurant.Extensions.Mapping;
using Restaurant.Models.DataAccessLayer.Helpers;
using Restaurant.Models.EntityLayer;
using Restaurant.Models.EntityLayer.Enums;

namespace Restaurant.Models.DataAccessLayer;

public static class UserDAL
{
    public static IEnumerable<User> GetUsers()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var users = new List<User>();

            while (reader.Read())
            {
                var user = new User
                {
                    UserId = (int)reader["UserId"],
                    FirstName = reader["FirstName"].ToString()!,
                    LastName = reader["LastName"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Phone = reader["Phone"].ToString()!,
                    DeliveryAddress = reader["DeliveryAddress"].ToString()!,
                    Password = reader["Password"].ToString()!,
                    UserType = (EUserType)reader["UserType"]
                };
                users.Add(user);
            }

            reader.Close();

            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<User>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static User GetUserById(int userId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserId", userId);

            connection.Open();

            var reader = command.ExecuteReader();
            var user = new User();

            if (reader.Read())
            {
                user.UserId = (int)reader["UserId"];
                user.FirstName = reader["FirstName"].ToString()!;
                user.LastName = reader["LastName"].ToString()!;
                user.Email = reader["Email"].ToString()!;
                user.Phone = reader["Phone"].ToString()!;
                user.DeliveryAddress = reader["DeliveryAddress"].ToString()!;
                user.Password = reader["Password"].ToString()!;
                user.UserType = (EUserType)reader["UserType"];
            }

            reader.Close();

            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new User();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool InsertUser(User user)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@DeliveryAddress", user.DeliveryAddress);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@UserType", user.UserType);

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

    public static bool UpdateUser(User user)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@DeliveryAddress", user.DeliveryAddress);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@UserType", user.UserType);

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

    public static bool DeleteUser(User user)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserId", user.UserId);

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

    public static IEnumerable<User> GetAllAdmins()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserSelectAllAdmins", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var users = new List<User>();

            while (reader.Read())
            {
                var user = new User
                {
                    UserId = (int)reader["UserId"],
                    FirstName = reader["FirstName"].ToString()!,
                    LastName = reader["LastName"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Phone = reader["Phone"].ToString()!,
                    DeliveryAddress = reader["DeliveryAddress"].ToString()!,
                    Password = reader["Password"].ToString()!,
                    UserType = (EUserType)reader["UserType"]
                };
                users.Add(user);
            }

            reader.Close();

            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<User>();
        }
        finally
        {
            connection.Close();
        }
    }

    public static IEnumerable<User> GetAllCashiers()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserSelectAllClients", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var users = new List<User>();

            while (reader.Read())
            {
                var user = new User
                {
                    UserId = (int)reader["UserId"],
                    FirstName = reader["FirstName"].ToString()!,
                    LastName = reader["LastName"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Phone = reader["Phone"].ToString()!,
                    DeliveryAddress = reader["DeliveryAddress"].ToString()!,
                    Password = reader["Password"].ToString()!,
                    UserType = (EUserType)reader["UserType"]
                };
                users.Add(user);
            }

            reader.Close();

            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<User>();
        }
        finally
        {
            connection.Close();
        }
    }
}