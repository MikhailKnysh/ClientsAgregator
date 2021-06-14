using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.Sources.OrdedSources
{
    class GetOrderModelFromOrderDTO : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new OrderModel()
                {
                    Id = 1,
                    ClientId = 1,
                    StatusesId = 1,
                    OrderReview = "sese",
                    OrderDate = "qqq",
                    TotalPrice = 10,
                },

                new OrderDTO()
                {
                    Id = 1,
                    ClientId = 1,
                    StatusesId = 1,
                    OrderReview = "sese",
                    OrderDate = "qqq",
                    TotalPrice = 10,
                }
            };
        }
    }
}
