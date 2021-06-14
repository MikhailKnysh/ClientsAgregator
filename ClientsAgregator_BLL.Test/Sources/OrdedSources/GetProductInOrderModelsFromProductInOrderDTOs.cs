using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_DAL.CustomModels;

namespace ClientsAgregator_BLL.Test.Sources.OrdedSources
{
    class GetProductInOrderModelsFromProductInOrderDTOs : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<ProductInOrderModel>()
                {
                    new ProductInOrderModel()
                    {
                        Articul = "111",
                        ProductId = 1,
                        ProductTitle = "111",
                        Price = 111,
                        Quantity = 111,
                        MeasureUnitId = 1,
                        MeasureUnitTitle = "111",
                        GroupTitle = "111",
                        SubgroupTitle = "111",
                        Rate = 1,
                        ProductReview = "111"
                    }
                },
                new List<ProductInOrderDTO>()
                {
                    new ProductInOrderDTO()
                    {
                        Articul = "111",
                        ProductId = 1,
                        ProductTitle = "111",
                        Price = 111,
                        Quantity = 111,
                        MeasureUnitId = 1,
                        MeasureUnitTitle = "111",
                        GroupTitle = "111",
                        SubgroupTitle = "111",
                        Rate = 1,
                        OrderReview = "111"
                    }
                },

            };
        }
    }
}
