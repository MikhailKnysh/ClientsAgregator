using ClientsAgregator_DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace ClientsAgregator_DAL.Queries
{
    class GetProducts
    {
        string connectionString = @"Data Source=DESKTOP-8AL13S1;Initial Catalog=usersdb;Integrated Security=True";
        string query = "exec AddBulkStatus @Title";
        string title = "TTT";

        public void Method()
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Query<BulkStatusDTO>(query, title).AsList<BulkStatusDTO>();
            }
        }
    }
}
