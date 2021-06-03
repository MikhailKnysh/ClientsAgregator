using ClientsAgregator_DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClientsAgregator_DAL.Queries
{
    class AddClientInfo
    {
        string connectionString = @"Data Source=DESKTOP-4JVUDM5;Initial Catalog=ClientsAgr;Integrated Security=True";
        string query = "AddClient";

        ClientDTO ClientInfo = new ClientDTO {};
        public void AddClient()
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, ClientInfo);
            }
        }
    }
}
