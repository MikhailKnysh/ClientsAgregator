using System.Collections;
using System.Collections.Generic;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.CustomModels;

namespace ClientsAgregator_BLL.Test.Sources.ProductSourse
{
    class GetModelsFromDTOSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
              new  List<ProductSubgroupDTO>(){
                  new ProductSubgroupDTO()
                  {
                      ProductId = 1,
                      ProductTitle = "манго",
                      SubgroupId = 1,
                      SubgroupTitle = "фрукты"
                  },
                  new ProductSubgroupDTO()
                  {
                      ProductId = 2,
                      ProductTitle = "манго1",
                      SubgroupId = 2,
                      SubgroupTitle = "фрукты1"
                  }
                },
              new List<ProductsSubgropModel>()
              {
                  new ProductsSubgropModel()
                  {
                      ProductId = 1,
                      ProductTitle = "манго",
                      SubgroupId = 1,
                      SubgroupTitle = "фрукты"
                  },
                  new ProductsSubgropModel()
                  {
                      ProductId = 2,
                      ProductTitle = "манго1",
                      SubgroupId = 2,
                      SubgroupTitle = "фрукты1"
                  }
              }
            };
        }
    }
}
