using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Models;
using ClientsAgregator_DAL.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            Console.WriteLine("Hello World!");

            List<OrdersInfoModel> models = controller.GetOrderModels();

            List<ClientsFullNameModel> clients = controller.GetClientsFullNameModels();

            List<ProductTitleModel> productTitles = controller.GetProductTitlesModels();

            List<StatusModel> statusTitles = controller.GetStatusModels();

            NewOrderInfoModel newOrderInfoModel = new NewOrderInfoModel()
            {
                ClientId = 1,
                OrderDate = "12.12.2021",
                StatusesId = 1,
                OrderReview = "Some review",
                TotalPrice = 127.59,
                productsInOrder = new List<ProductInOrderModel>()
                {
                    new ProductInOrderModel()
                    {
                        Articul = "121AER",
                        ProductId = 2,
                        ProductTitle = "Bread",
                        Price = 12.99,
                        Quantity = 23,
                        MeasureUnitTitle = 1,
                        GroupTitle = "Food",
                        SubgroupTitle = "Bakery",
                        Rate = 4
                    },
                    new ProductInOrderModel()
                    {
                        Articul = "131OIk",
                        ProductId = 2,
                        ProductTitle = "Spoons",
                        Price = 12.99,
                        Quantity = 17,
                        MeasureUnitTitle = 1,
                        GroupTitle = "Food",
                        SubgroupTitle = "Bakery",
                        Rate = 4
                    }
                }
            };

            //try
            //{
            //    controller.AddOrder(newOrderInfoModel);
            //}
            //catch (ArgumentException)
            //{
            //    Console.WriteLine("List is empty!");
            //}

            controller.DeleteOrder(orderId: 12);
        }
    }
}