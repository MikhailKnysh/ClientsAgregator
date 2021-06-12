using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.Sources.ClientsSources
{
    class GetProductsBuyClientModelsFromDTOSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<ProductsBuyClientDTO>(){

                    new ProductsBuyClientDTO()
                    {
                        Articul = "322",
                        GroupName = "напитки",
                        ProductId = 1,
                        SubGroupName = "спиртное",
                        SUMQuantity = 300,
                        Title = "Квас"
                    },
                    new ProductsBuyClientDTO()
                    {
                        Articul = "3221",
                        GroupName = "напитки1",
                        ProductId = 11,
                        SubGroupName = "спиртное1",
                        SUMQuantity = 3001,
                        Title = "Квас1"
                    },
                },
                new List<ProductBuyClientModel>(){

                    new ProductBuyClientModel()
                    {
                        Articul = "322",
                        GroupName = "напитки",
                        ProductId = 1,
                        SubGroupName = "спиртное",
                        SUMQuantity = 300,
                        Title = "Квас"
                    },
                    new ProductBuyClientModel()
                    {
                        Articul = "3221",
                        GroupName = "напитки1",
                        ProductId = 11,
                        SubGroupName = "спиртное1",
                        SUMQuantity = 3001,
                        Title = "Квас1"
                    },
                }
            };
        }
    }
}
