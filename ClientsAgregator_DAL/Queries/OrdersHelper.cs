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

        public static List<ClientFullNameDTO> GetClientsFullNames()
        {
            string query = "GetClientsFullName";

            List<ClientFullNameDTO> clients = new List<ClientFullNameDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                clients = conn.Query<ClientFullNameDTO>(query).AsList();
            }

            return clients;
        }

        public static List<ProductTitleDTO> GetProductTitles()
        {
            string query = "GetProductTitles";

            List<ProductTitleDTO> products = new List<ProductTitleDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                products = conn.Query<ProductTitleDTO>(query).AsList();
            }

            return products;
        }

        public static List<StatusDTO> GetStatusTitles()
        {
            string query = "GetStatuses";

            List<StatusDTO> statuses = new List<StatusDTO>();

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                statuses = conn.Query<StatusDTO>(query).AsList();
            }

            return statuses;
        }

        public static void AddOrder(List<Product_OrderDTO> productsOrder, OrderDTO order)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                string query = "AddOrder";

                var result = conn.Query<int>(query, new
                {
                    order.ClientId,
                    order.StatusesId,
                    order.OrderReview,
                    order.OrderDate,
                    order.TotalPrice
                },
                    commandType: CommandType.StoredProcedure
                );

                int OrderId = result.Single();

                query = "AddProductOrder";

                foreach (Product_OrderDTO po in productsOrder)
                {
                    conn.Query<Product_OrderDTO>(query, new
                    {
                        OrderId,
                        po.ProductId,
                        po.Quantity
                    },
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
        }
    }
}
