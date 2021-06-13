using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_DAL.CustomModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.ProductSourse
{
    public class GetProductTitlesDTOSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                    new List<ProductSubgroupDTO>()
                    {
                        new ProductSubgroupDTO()
                        {
                            ProductId = 1,
                            ProductTitle = "rose",
                            SubgroupId = 2,
                            SubgroupTitle = "flowers"
                        },
                         new ProductSubgroupDTO()
                         {
                            ProductId = 11,
                            ProductTitle = "rose1",
                            SubgroupId = 21,
                            SubgroupTitle = "flowers"
                         }
                    },
                    new List<ProductTitleModel>()
                    {
                        new ProductTitleModel()
                        {
                            ProductId = 1,
                            ProductTitle = "rose",
                        },
                         new ProductTitleModel()
                         {
                            ProductId = 11,
                            ProductTitle = "rose1",
                         }
                    },
            };
        }
    }
}
