using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.CustomModels;

namespace ClientsAgregator_BLL.Test.Sources.GetInterestedClientInfoBySubgroupSource
{
    class GetModelsFromDTO : IEnumerable

    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<InterestedClientInfoByProductDTO>()
                {
                    new InterestedClientInfoByProductDTO()
                    {
                        ClientId = 1,
                        LastName = "Котов",
                        FirstName = "Сергей",
                        MiddleName = "Cерго",
                        Phone = "+12345",
                        BulkStatusTitle = "Оптовый",
                        ProductId = 1,
                        ProductTitle = "Курица",
                        SumQuantity = 10,
                        AVGRate = 5,
                    },
                    new InterestedClientInfoByProductDTO()
                    {
                        ClientId = 2,
                        LastName = "Котов2",
                        FirstName = "Сергей2",
                        MiddleName = "Cерго2",
                        Phone = "+123452",
                        BulkStatusTitle = "Оптовый2",
                        ProductId = 12,
                        ProductTitle = "Курица2",
                        SumQuantity = 102,
                        AVGRate = 52,

                    }
                },
                new List<InterestedClientInfoByProductModel>()
                {
                    new InterestedClientInfoByProductModel()
                    {
                        ClientId = 1,
                        LastName = "Котов",
                        FirstName = "Сергей",
                        MiddleName = "Cерго",
                        Phone = "+12345",
                        BulkStatusTitle = "Оптовый",
                        ProductId = 1,
                        ProductTitle = "Курица",
                        SumQuantity = 10,
                        AVGRate = "5",
                    },
                    new InterestedClientInfoByProductModel()
                    {
                        ClientId = 2,
                        LastName = "Котов2",
                        FirstName = "Сергей2",
                        MiddleName = "Cерго2",
                        Phone = "+123452",
                        BulkStatusTitle = "Оптовый2",
                        ProductId = 12,
                        ProductTitle = "Курица2",
                        SumQuantity = 102,
                        AVGRate = "52",
                    }
                }
            };
        }
    }
}
