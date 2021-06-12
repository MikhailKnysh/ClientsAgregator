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
    public class OrdersHelper : IOrdersHelper
    {
        public List<OrdersInfoDTO> GetOrdersInfo()
        {
            string query = "ClientsAgregatorDB.GetOrdersInfo";

            List<OrdersInfoDTO> orders = new List<OrdersInfoDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                orders = conn.Query<OrdersInfoDTO>(query).AsList();
            }

            return orders;
        }

        public List<ClientFullNameDTO> GetClientsFullNames()
        {
            string query = "ClientsAgregatorDB.GetClientsFullName";

            List<ClientFullNameDTO> clients = new List<ClientFullNameDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                clients = conn.Query<ClientFullNameDTO>(query).AsList();
            }

            return clients;
        }

        public List<ProductSubgroupDTO> GetProductTitles()
        {
            string query = "ClientsAgregatorDB.GetProductTitles";

            List<ProductSubgroupDTO> products = new List<ProductSubgroupDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                products = conn.Query<ProductSubgroupDTO>(query).AsList();
            }

            return products;
        }

        public List<StatusDTO> GetStatusTitles()
        {
            string query = "ClientsAgregatorDB.GetStatuses";

            List<StatusDTO> statuses = new List<StatusDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                statuses = conn.Query<StatusDTO>(query).AsList();
            }

            return statuses;
        }

        public void AddOrder(List<Product_OrderDTO> productsOrder, OrderDTO order)
        {
            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                string query = "ClientsAgregatorDB.AddOrder";

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

                query = "ClientsAgregatorDB.AddProductOrder";

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

        public void DeleteOrder(int orderId)
        {
            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                string query = "ClientsAgregatorDB.DeleteProductOrderByOrderId @OrderId";

                conn.Query<int>(query, new { orderId });

                query = "ClientsAgregatorDB.DeleteOrderById @OrderId";
                conn.Query<int>(query, new { orderId });
            }
        }

        public OrderDTO GetOrdersInfoById(int orderId)
        {
            string query = "ClientsAgregatorDB.GetOrdersInfoById @OrderId";
            OrderDTO orderDTO;

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                orderDTO = conn.Query<OrderDTO>(query, new { orderId }).FirstOrDefault();
            }

            return orderDTO;
        }

        public List<ProductInOrderDTO> GetProductsInOrderByOrderId(int orderId)
        {
            string query = "ClientsAgregatorDB.GetProductsInOrderByOrderId @OrderId";

            List<ProductInOrderDTO> productsInOrder;

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                productsInOrder = conn.Query<ProductInOrderDTO>(query, new { orderId }).AsList();
            }

            return productsInOrder;
        }
    }
}