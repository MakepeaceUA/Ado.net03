using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=ARSEN;Initial Catalog=Warehouse; Integrated Security=True";

            using (SqlConnection sql_connect = new SqlConnection(connectionString))
            {
                try
                {
                    sql_connect.Open();
                    Console.WriteLine("Подключение к базе данных успешно.");
                    Console.WriteLine($"Сервер: {sql_connect.DataSource}");
                    Console.WriteLine($"База данных: {sql_connect.Database}\n\n");
                    Console.WriteLine("Все товары:");
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Products", sql_connect))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]}, Название: {reader["ProductName"]}, Количество: {reader["Quantity"]}, Цена: {reader["CostPrice"]}, Дата поставки: {reader["SupplyDate"]}");
                        }
                    }

                    Console.WriteLine("\nВсе типы товаров:");
                    using (SqlCommand command = new SqlCommand("SELECT * FROM ProductTypes", sql_connect))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]}, Тип: {reader["TypeName"]}");
                        }
                    }

                    Console.WriteLine("\nВсе поставщики:");
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Suppliers", sql_connect))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]}, Поставщик: {reader["SupplierName"]}");
                        }
                    }

                    int typeId = 2;
                    Console.WriteLine("\nТовары выбранной категории:");
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE ProductTypeId = @TypeId", sql_connect))
                    {
                        command.Parameters.AddWithValue("@TypeId", typeId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["Id"]}, Название: {reader["ProductName"]}, Количество: {reader["Quantity"]}, Цена: {reader["CostPrice"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                finally
                {
                    sql_connect.Close();
                    Console.WriteLine("Подключение закрыто.");
                }
            }
            Console.ReadLine();
        }
    }
}
