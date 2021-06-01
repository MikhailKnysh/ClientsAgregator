using ClientsAgregator_DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Hello World!");
            AddClient();


        }

        private static void AddClient()
        {
            string connectionString = @"Data Source=DESKTOP-4JVUDM5;Initial Catalog=ClientsAgr;Integrated Security=True";
            string query = "AddClient";

            ClientDTO ClientInfo = new ClientDTO { };
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, ClientInfo);
            }

        }
    }
}