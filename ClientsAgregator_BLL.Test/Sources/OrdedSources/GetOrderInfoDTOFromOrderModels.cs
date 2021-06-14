using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_DAL.CustomModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.OrdedSources
{
    public class GetOrderInfoDTOFromOrderModels : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<OrdersInfoDTO>()
                {
                    new OrdersInfoDTO()
                    {
                        Id = 1,
                        OrderDate = "01.11.2015",
                        LastName = "Smolov",
                        FirstName = "Sergei",
                        MiddleName = "Seg",
                        TotalPrice = 675,
                        Title = "uuf",
                        OrderReview = "qwe"
                    },
                    new OrdersInfoDTO()
                    {
                        Id = 14,
                        OrderDate = "01.11.20154",
                        LastName = "Smolov4",
                        FirstName = "Sergei4",
                        MiddleName = "Seg4",
                        TotalPrice = 6754,
                        Title = "uuf4",
                        OrderReview = "qwe4"
                    }

                },
                new List<OrdersInfoModel>()
                {
                    new OrdersInfoModel()
                    {
                        Id = 1,
                        OrderDate = "01.11.2015",
                        LastName = "Smolov",
                        FirstName = "Sergei",
                        MiddleName = "Seg",
                        TotalPrice = 675,
                        Title = "uuf",
                        OrderReview = "qwe"
                    },
                    new OrdersInfoModel()
                    {
                        Id = 14,
                        OrderDate = "01.11.20154",
                        LastName = "Smolov4",
                        FirstName = "Sergei4",
                        MiddleName = "Seg4",
                        TotalPrice = 6754,
                        Title = "uuf4",
                        OrderReview = "qwe4"
                    }
                }
            };
        }
    }
}
