using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.Sources.OrdedSources
{
    class GetDTOsFromNewOrderInfoModel : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new NewOrderInfoModel()
                {
                    ClientId = 9,
                    OrderDate = "22.22.22",
                    StatusesId = 1,
                    OrderReview = "pow",
                    TotalPrice = 200,
                    ProductsInOrder = new List<ProductInOrderModel>()
                    {
                        new ProductInOrderModel()
                        {
                            Articul = "1233",
                            ProductId = 2,
                            ProductTitle = "Огурец",
                            Price = 20,
                            Quantity = 10,
                            MeasureUnitId = 0,
                            MeasureUnitTitle = "Кг",
                            GroupTitle = "еда",
                            SubgroupTitle = "Овощи",
                            Rate = -1,
                            ProductReview = "qqq"
                        }
                    }
                },  new List<FeedbackModel>()
                {
                    new FeedbackModel()
                    {
                        Id = 1,
                        ClientId = 1,
                        ProductId = 1,
                        OrderId = 1,
                        Description = "qqq",
                        Date = "11.11.11",
                        Rate = 5
                    }
                },

                new List<FeedbackDTO>()
                {
                    new FeedbackDTO()
                    {
                        Id = 1,
                        ClientId = 1,
                        ProductId = 1,
                        OrderId = 1,
                        Description = "qqq",
                        Date = "11.11.11",
                        Rate = 5
                    }
                },

                new OrderDTO(){
                    Id = 0,
                    ClientId = 9,
                    StatusesId = 1,
                    OrderReview = "pow",
                    OrderDate = "22.22.22",
                    TotalPrice = 200
                },

                new List<Product_OrderDTO>()
                {
                    new Product_OrderDTO()
                    {   Id = 0,
                        OrderId = 0,
                        ProductId = 2,
                        Quantity = 10,
                    }
                }
            };
        }
    }
}
