using ClientsAgregator_DAL.CustomModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClientsAgregator_DAL.Queries
{
    public static class MainsHalper
    {
        public static List<ProductSubgroupDTO> GetProductsSubgroup()
        {
            string query = "ClientsAgregatorDB.GetProductSubgroup";

            List<ProductSubgroupDTO> productSubgroups = new List<ProductSubgroupDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                productSubgroups = conn.Query<ProductSubgroupDTO>(query).AsList();
            }

            return productSubgroups;
        }

        public static List<ClientByProductsDTO> GetClientInfoByProduct()
        {
            string query = "ClientsAgregatorDB.GetClientInfoByProduct";

            List<ClientByProductsDTO> clientByProducts = new List<ClientByProductsDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                clientByProducts = conn.Query<ClientByProductsDTO>(query).AsList();
            }

            return clientByProducts;
        }

    }
}
