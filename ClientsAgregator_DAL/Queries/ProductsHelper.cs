using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace ClientsAgregator_DAL.Queries
{
    public static class ProductsHelper
    {
        private const string connectionString = @"Data Source=5876ROR;Initial Catalog=QQQQ;Integrated Security=True";

        public static List<ProductInfoDTO> GetProductsInfo()
        {
            string query = "GetProductsInfo";

            List<ProductInfoDTO> products = new List<ProductInfoDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                products = conn.Query<ProductInfoDTO>(query).AsList();
            }

            return products;
        }

        public static List<GroupDTO> GetGroups()
        {
            string query = "GetGroups";

            List<GroupDTO> groups = new List<GroupDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                groups = conn.Query<GroupDTO>(query).AsList();
            }

            return groups;
        }

        public static List<SubgroupDTO> GetSubgroupsInfoByGroupId(int groupId)
        {
            string query = "GetSubgroupsInfoByGroupId";

            List<SubgroupDTO> subgroups = new List<SubgroupDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                subgroups = conn.Query<SubgroupDTO>(query, new { groupId }, commandType: CommandType.StoredProcedure).AsList();
            }

            return subgroups;
        }

        public static List<MeasureUnitDTO> GetMeasureUnits()
        {
            string query = "GetMeasureUnit";

            List<MeasureUnitDTO> measureUnits = new List<MeasureUnitDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                measureUnits = conn.Query<MeasureUnitDTO>(query).AsList();
            }

            return measureUnits;
        }

        public static int AddProduct(ProductDTO product)
        {
            string query = "AddProduct";

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var productId = conn.Query<int>(query, new
                {
                    product.Articul,
                    product.Title,
                    product.Price,
                    product.Quantity,
                    product.MeasureId
                }, commandType: CommandType.StoredProcedure);

                return productId.Single();
            }
        }

        public static void AddProductSubgroup(int productId, int subgroupId)
        {
            string query = "AddProduct_Subgroup";

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Query<int>(query, new { productId, subgroupId }, commandType: CommandType.StoredProcedure);
            }
        }

        public static void AddProductGroup(string Title)
        {
            string query = "AddGroup";

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Query<int>(query,new {Title}, commandType: CommandType.StoredProcedure);
            }
        }

        public static int AddProductSubgroup(string Title)
        {
            string query = "AddSubgroup";

            using (IDbConnection conn = new SqlConnection(connectionString))
            { 
                var subgroupId = conn.Query<int>(query, new { Title }, commandType: CommandType.StoredProcedure);

                return subgroupId.Single();
            }
        }

        public static void AddSubgroupGroup(int SubgroupId, int GroupId)
        {
            string query = "AddSubgroupGroup";

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Query<int>(query, new { SubgroupId, GroupId }, commandType: CommandType.StoredProcedure);
            }
        }

        public static void DeleteProductById(int productId)
        {
            string query = "DeleteProductById";

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Query<int>(query, new {productId}, commandType: CommandType.StoredProcedure);
            }
        }

        public static void DeleteProductSubgroupByProductId(int productId)
        {
            string query = "DeleteProductSubgroupByProductId";

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Query<int>(query, new { productId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
