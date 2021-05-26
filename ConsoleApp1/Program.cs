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
            string connectionString = @"Data Source=DESKTOP-8AL13S1;Initial Catalog=ClientsAgregator;Integrated Security=True";
            string query = "exec AddBulkStatus @Title";
            string title = "TTT";

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Query<BulkStatusDTO>(query, new { title }).AsList<BulkStatusDTO>();
            }
        }
    }
}