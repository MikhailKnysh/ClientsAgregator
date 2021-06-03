using ClientsAgregator_DAL.CustomModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClientsAgregator_DAL.Queries
{
    public static class OrdersHelper
    {
        private const string connectionString = @"Data Source=DESKTOP-8AL13S1;Initial Catalog=CLAG;Integrated Security=True";

        public static List<OrdersInfoDTO> GetOrdersInfo()
        {
            string query = "GetOrdersInfo";

            List<OrdersInfoDTO> orders = new List<OrdersInfoDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                orders = conn.Query<OrdersInfoDTO>(query).AsList();
            }

            return orders;
        }
    }
}
