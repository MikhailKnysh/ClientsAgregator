using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.Sources.ProductSourse
{
    class GetProductDTOFromProductModel : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AddingProductModel()
                {
                    Articul = "123",
                    MeasureId = 1,
                    Price = 10,
                    Quantity = 123,
                    SubgroupId = 1,
                    Title = "123"
                },
                new ProductDTO()
                {
                    Articul = "123",
                    MeasureId = 1,
                    Price = 10,
                    Quantity = 123,
                    Title = "123",
                    Id = 0
                }

            };
        }
    }
}
