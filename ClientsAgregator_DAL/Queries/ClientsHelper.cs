using ClientsAgregator_DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClientsAgregator_DAL.Queries
{
    public static class ClientsHelper
    {
        private const string connectionString = @"Data Source=DESKTOP-VTR9DQO;Initial Catalog=ClientsAgr;Integrated Security=True";

        public static List<AddClientDTO> AddClient()
        {
            string query = "AddClient";

            List<AddClientDTO> newClientInfo = new List<AddClientDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                newClientInfo = conn.Query<AddClientDTO>(query).AsList();
            }

            return newClientInfo;
        }

        public static List<ClientDTO> GetClients()
        {
            string query = "GetClients";

            List<ClientDTO> clientsInfo = new List<ClientDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                clientsInfo = conn.Query<ClientDTO>(query).AsList();
            }

            return clientsInfo;
        }

        public static List<ClientDTO> GetClientById(int id)
        {
            string query = "GetClientById";

            List<ClientDTO> clientInfo = new List<ClientDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                clientInfo = conn.Query<ClientDTO>(query, new { id }).AsList();
            }

            return clientInfo;
        }

        public static List<ProductsBuyClientDTO> GetProductsBuyClient(int id)
        {
            string query = "GetProductsBuyClientById";

            List<ProductsBuyClientDTO> productsBuyClient = new List<ProductsBuyClientDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                productsBuyClient = conn.Query<ProductsBuyClientDTO>(query, new { id }).AsList();
            }

            return productsBuyClient;
        }

        public static List<ClientDTO> UpdateClientById(int id)
        {
            string query = "UpdateClientById";

            List<ClientDTO> updateClient = new List<ClientDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                updateClient = conn.Query<ClientDTO>(query, new {id}).AsList();
            }

            return updateClient;
        }

        public static string GetSpendMoneyCountByClientId(int id)
        {
            string query = "GetSpendMoneyCountByClientId";

            string totalSum;

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                totalSum = conn.Query<int>(query, new { id }).ToString();
            }

            return totalSum;
        }
    }
}
