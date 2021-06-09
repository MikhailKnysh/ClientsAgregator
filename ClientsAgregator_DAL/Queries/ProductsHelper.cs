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
        public static List<ProductInfoDTO> GetProductsInfo()
        {
            string query = "ClientsAgregatorDB.GetProductsInfo";

            List<ProductInfoDTO> products = new List<ProductInfoDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                products = conn.Query<ProductInfoDTO>(query).AsList();
            }

            return products;
        }

        public static List<GroupDTO> GetGroups()
        {
            string query = "ClientsAgregatorDB.GetGroups";

            List<GroupDTO> groups = new List<GroupDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                groups = conn.Query<GroupDTO>(query).AsList();
            }

            return groups;
        }

        public static List<SubgroupDTO> GetSubgroupsInfoByGroupId(int groupId)
        {
            string query = "ClientsAgregatorDB.GetSubgroupsInfoByGroupId";

            List<SubgroupDTO> subgroups = new List<SubgroupDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                subgroups = conn.Query<SubgroupDTO>(query, new { groupId }, commandType: CommandType.StoredProcedure).AsList();
            }

            return subgroups;
        }

        public static List<MeasureUnitDTO> GetMeasureUnits()
        {
            string query = "ClientsAgregatorDB.GetMeasureUnit";

            List<MeasureUnitDTO> measureUnits = new List<MeasureUnitDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                measureUnits = conn.Query<MeasureUnitDTO>(query).AsList();
            }

            return measureUnits;
        }

        public static int AddProduct(ProductDTO product)
        {
            string query = "ClientsAgregatorDB.AddProduct";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
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
            string query = "ClientsAgregatorDB.AddProduct_Subgroup";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new { productId, subgroupId }, commandType: CommandType.StoredProcedure);
            }
        }

        public static void AddProductGroup(string Title)
        {
            string query = "ClientsAgregatorDB.AddGroup";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query,new {Title}, commandType: CommandType.StoredProcedure);
            }
        }

        public static int AddProductSubgroup(string Title)
        {
            string query = "ClientsAgregatorDB.AddSubgroup";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            { 
                var subgroupId = conn.Query<int>(query, new { Title }, commandType: CommandType.StoredProcedure);

                return subgroupId.Single();
            }
        }

        public static void AddSubgroupGroup(int SubgroupId, int GroupId)
        {
            string query = "ClientsAgregatorDB.AddSubgroupGroup";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new { SubgroupId, GroupId }, commandType: CommandType.StoredProcedure);
            }
        }

        public static void DeleteProductById(int productId)
        {
            string query = "ClientsAgregatorDB.DeleteProductById";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new {productId}, commandType: CommandType.StoredProcedure);
            }
        }

        public static void DeleteProductSubgroupByProductId(int productId)
        {
            string query = "ClientsAgregatorDB.DeleteProductSubgroupByProductId";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new { productId }, commandType: CommandType.StoredProcedure);
            }
        }

        public static ProductInfoDTO GetProductById(int productId)
        {
            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                string query = "ClientsAgregatorDB.GetProductById @ProductId";
                ProductDTO productDTO = conn.Query<ProductDTO>(query, new { productId }).FirstOrDefault();

                query = "GetMeasureUnitById @Id";
                string measureUnitTitle = conn.Query<string>(query, new {productDTO.MeasureId}).FirstOrDefault();

                query = "GetSubgroupById @Id";
                string subgroupTitle = conn.Query<string>(query, new { productDTO. }).FirstOrDefault();
            }

            return productDTO;
        }
    }
}
