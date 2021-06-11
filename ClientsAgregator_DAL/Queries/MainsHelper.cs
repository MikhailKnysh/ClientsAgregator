using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Interface;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClientsAgregator_DAL.Queries
{
    public class MainsHelper : IMainsHelper
    {
        public List<ProductSubgroupDTO> GetProductsSubgroup()
        {
            string query = "ClientsAgregatorDB.GetProductSubgroup";

            List<ProductSubgroupDTO> productSubgroups = new List<ProductSubgroupDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                productSubgroups = conn.Query<ProductSubgroupDTO>(query).AsList();
            }

            return productSubgroups;
        }

        public List<InterestedClientInfoByProductDTO> GetInterestedClientInfoByProduct(int productId)
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
