using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Interface;
using ClientsAgregator_DAL.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ClientsAgregator_DAL.Queries
{
    public class ProductsHelper : IProductsHelper
    {
        public List<ProductInfoDTO> GetProductsInfo()
        {
            string query = "ClientsAgregatorDB.GetProductsInfo";

            List<ProductInfoDTO> products = new List<ProductInfoDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                products = conn.Query<ProductInfoDTO>(query).AsList();
            }

            return products;
        }

        public List<GroupDTO> GetGroups()
        {
            string query = "ClientsAgregatorDB.GetGroups";

            List<GroupDTO> groups = new List<GroupDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                groups = conn.Query<GroupDTO>(query).AsList();
            }

            return groups;
        }

        public List<SubgroupDTO> GetSubgroupsInfoByGroupId(int groupId)
        {
            string query = "ClientsAgregatorDB.GetSubgroupsInfoByGroupId";

            List<SubgroupDTO> subgroups = new List<SubgroupDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                subgroups = conn.Query<SubgroupDTO>(query, new { groupId }, commandType: CommandType.StoredProcedure).AsList();
            }

            return subgroups;
        }

        public List<MeasureUnitDTO> GetMeasureUnits()
        {
            string query = "ClientsAgregatorDB.GetMeasureUnit";

            List<MeasureUnitDTO> measureUnits = new List<MeasureUnitDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                measureUnits = conn.Query<MeasureUnitDTO>(query).AsList();
            }

            return measureUnits;
        }

        public int AddProduct(ProductDTO product)
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

        public void AddProductSubgroup(int productId, int subgroupId)
        {
            string query = "ClientsAgregatorDB.AddProduct_Subgroup";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new { productId, subgroupId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddProductGroup(string Title)
        {
            string query = "ClientsAgregatorDB.AddGroup";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new { Title }, commandType: CommandType.StoredProcedure);
            }
        }

        public int AddProductSubgroup(string Title)
        {
            string query = "ClientsAgregatorDB.AddSubgroup";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                var subgroupId = conn.Query<int>(query, new { Title }, commandType: CommandType.StoredProcedure);

                return subgroupId.Single();
            }
        }

        public void AddSubgroupGroup(int SubgroupId, int GroupId)
        {
            string query = "ClientsAgregatorDB.AddSubgroupGroup";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new { SubgroupId, GroupId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProductById(int productId)
        {
            string query = "ClientsAgregatorDB.DeleteProductById";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new { productId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteProductSubgroupByProductId(int productId)
        {
            string query = "ClientsAgregatorDB.DeleteProductSubgroupByProductId";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new { productId }, commandType: CommandType.StoredProcedure);
            }
        }

        public ProductInfoDTO GetProductInfoById(int productId)
        {
            ProductInfoDTO productInfoDTO;
            string query = "ClientsAgregatorDB.GetProductsInfoById @ProductId";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                productInfoDTO = conn.Query<ProductInfoDTO>(query, new { productId }).FirstOrDefault();
            }

            return productInfoDTO;
        }

        public void AddMeasureUnits(string Title)
        {
            string query = "ClientsAgregatorDB.AddMeasureUnit";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query<int>(query, new { Title }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
