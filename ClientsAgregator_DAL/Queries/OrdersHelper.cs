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

        public int AddOrder(List<Product_OrderDTO> productsOrder, OrderDTO order)
        {
            int orderIdResult;
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
                orderIdResult = OrderId;

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
            return orderIdResult;
        }
        public void UpdateOrder (List<Product_OrderDTO> productsOrder, OrderDTO order, List<FeedbackDTO> feedbackDTOs)
        {
            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                string query = "ClientsAgregatorDB.UpdateOrderById";

                conn.Query<int>(query, new
                {
                    order.Id,
                    order.ClientId,
                    order.StatusesId,
                    order.OrderReview,
                    order.OrderDate,
                    order.TotalPrice
                },
                    commandType: CommandType.StoredProcedure
                );

                query = "ClientsAgregatorDB.DeleteProductOrderByOrderId @OrderId";

                int orderId = order.Id;
                conn.Query<int>(query, new { orderId });

                query = "ClientsAgregatorDB.AddProductOrder";

                foreach (Product_OrderDTO po in productsOrder)
                {
                    conn.Query<Product_OrderDTO>(query, new
                    {
                        orderId,
                        po.ProductId,
                        po.Quantity
                    },
                        commandType: CommandType.StoredProcedure
                    );
                }
                query = "ClientsAgregatorDB.DeleteFeedbacksByOrderId @OrderId";
                
                conn.Query<int>(query, new { orderId });

                query = "ClientsAgregatorDB.AddFeedback";

                foreach (FeedbackDTO f in feedbackDTOs)
                {
                    conn.Query<FeedbackDTO>(query, new
                    {
                        f.ClientId,
                        f.ProductId,
                        f.OrderId,
                        f.Description,
                        f.Date,
                        f.Rate
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

        public List<ProductInOrderDTO> GetProductsInOrderByOrderIdNew (int orderId)
        {
            List<ProductInOrderDTO> productsInOrder = new List<ProductInOrderDTO>();

            string query = "ClientsAgregatorDB.GetProductOrderByOrderId @OrderId";

            List<Product_OrderDTO> product_OrderDTOs;

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                product_OrderDTOs = conn.Query<Product_OrderDTO>(query, new { orderId }).AsList();
            }

            query = "ClientsAgregatorDB.GetProductsInfoById @Id";

            List<ProductInfoDTO> productInfoDTOs = new List<ProductInfoDTO>();

            foreach (Product_OrderDTO po in product_OrderDTOs)
            {
                using (IDbConnection conn = new SqlConnection(Options.connectionString))
                {
                    int productId = po.ProductId;
                    ProductInfoDTO newProductInfoDTO = conn.Query<ProductInfoDTO>(query, new { Id = productId }).FirstOrDefault();
                    productInfoDTOs.Add(newProductInfoDTO);
                }
            }

            foreach(ProductInfoDTO pi in productInfoDTOs)
            {
                productsInOrder.Add(new ProductInOrderDTO()
                {
                    Articul = pi.Articul,
                    ProductId = pi.Id,
                    ProductTitle = pi.Title,
                    Price = pi.Price,
                    MeasureUnitTitle = pi.MeasureUnit,
                    SubgroupTitle = pi.Subgroup,
                    GroupTitle = pi.Group
                });
            }
            foreach(ProductInOrderDTO pio in productsInOrder)
            {
                foreach (Product_OrderDTO po in product_OrderDTOs)
                {
                    if (pio.ProductId == po.ProductId)
                    {
                        pio.Quantity = po.Quantity;
                    }
                }
            }

            List<MeasureUnitDTO> measureUnitDTOs;
            
            query = "ClientsAgregatorDB.GetMeasureUnit";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                measureUnitDTOs = conn.Query<MeasureUnitDTO>(query).AsList();
            }

            foreach (ProductInOrderDTO pio in productsInOrder)
            {
                foreach (MeasureUnitDTO mu in measureUnitDTOs)
                {
                    if (pio.MeasureUnitTitle == mu.Title)
                    {
                        pio.MeasureUnitId = mu.Id;
                    }
                }
            }

            List<FeedbackDTO> feedbackDTOs;
            
            query = "ClientsAgregatorDB.GetFeedbacksByOrderId @OrderId";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                feedbackDTOs = conn.Query<FeedbackDTO>(query, new { orderId }).AsList();
            }

            foreach (ProductInOrderDTO pio in productsInOrder)
            {
                foreach (FeedbackDTO f in feedbackDTOs)
                {
                    if (pio.ProductId == f.ProductId)
                    {
                        pio.Rate = f.Rate;
                        pio.OrderReview = f.Description;
                    }
                }
            }

            return productsInOrder;
        }

        public void AddFeedbacks(List<FeedbackDTO> feedbackDTOs)
        {
            string query = "ClientsAgregatorDB.AddFeedback";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                foreach (FeedbackDTO f in feedbackDTOs)
                {
                    conn.Query<Product_OrderDTO>(query, new
                    {
                        f.ClientId,
                        f.ProductId,
                        f.OrderId,
                        f.Description,
                        f.Date,
                        f.Rate
                    },
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
        }
    }
}