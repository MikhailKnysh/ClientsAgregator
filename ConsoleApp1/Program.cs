using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string connectionString = @"Data Source=DESKTOP-8AL13S1;Initial Catalog=CA;Integrated Security=True";
            string query = "GetOrdersInfo";

            List<OrdersInfoDTO> orders = new List<OrdersInfoDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                orders = conn.Query<OrdersInfoDTO>(query).AsList();
            }
        }
    }
}