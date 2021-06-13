using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
                            GroupTitle = "еда",
                            MeasureUnitId = 0,
                            MeasureUnitTitle = "Кг",
                            Price = 20,
                            ProductId = 2,
                            ProductTitle = "Огурец",
                            Quantity = 10,
                            Rate = -1,
                            SubgroupTitle = "Овощи"
                        },
                        new ProductInOrderModel()
                        {
                            Articul = "1233",
                            GroupTitle = "еда",
                            MeasureUnitId = 0,
                            MeasureUnitTitle = "Кг",
                            Price = 20,
                            ProductId = 2,
                            ProductTitle = "Огурец",
                            Quantity = 10,
                            Rate = -1,
                            SubgroupTitle = "Овощи"
                        }

                    }
                },

                new OrderDTO(){
                    ClientId = 9,
                    Id = 0,
                    OrderDate = "22.22.22",
                    OrderReview = "pow",
                    StatusesId = 1,
                    TotalPrice = 200
                },
                new List<Product_OrderDTO>()
                {
                    new Product_OrderDTO()
                    {   Id = 0,
                        OrderId = 0,
                        ProductId = 2,
                        Quantity = 10,
                    },
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
