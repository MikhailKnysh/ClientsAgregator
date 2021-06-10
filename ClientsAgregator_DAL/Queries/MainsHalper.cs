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

        public static List<InterestedClientInfoByProductDTO> GetInterestedClientInfoByProduct(int productId)
        {
            string query = "ClientsAgregatorDB.GetClientInfoByProduct";

            List<InterestedClientInfoByProductDTO> interestedClientByProducts = new List<InterestedClientInfoByProductDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                interestedClientByProducts = conn.Query<InterestedClientInfoByProductDTO>(query, new { productId },commandType:CommandType.StoredProcedure).AsList();
            }

            return interestedClientByProducts;
        }

    }
}
