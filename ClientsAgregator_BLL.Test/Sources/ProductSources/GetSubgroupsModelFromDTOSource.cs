using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.ProductSources
{
    public class GetSubgroupsModelFromDTOSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
           {
                    new List<SubgroupDTO>()
                    {
                        new SubgroupDTO()
                        {
                            Id = 1,
                            Title = "son",
                        },
                         new SubgroupDTO()
                         {
                            Id = 11,
                            Title = "soni",
                         }
                    },
                    new List<SubgroupInfoModel>()
                    {
                          new SubgroupInfoModel()
                        {
                            Id = 1,
                            Title = "son",
                        },
                         new SubgroupInfoModel()
                         {
                            Id = 11,
                            Title = "soni",
                         }
                    },
           };
        }
    }
}
