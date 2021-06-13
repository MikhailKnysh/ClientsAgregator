using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.ProductSources
{
    public class GetGroupsModelFromDTOSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                    new List<GroupDTO>()
                    {
                        new GroupDTO()
                        {
                            Id = 1,
                            Title = "flowers",
                        },
                         new GroupDTO()
                         {
                            Id = 11,
                            Title = "flowers1",
                         }
                    },
                    new List<GroupInfoModel>()
                    {
                          new GroupInfoModel()
                        {
                            Id = 1,
                            Title = "flowers",
                        },
                         new GroupInfoModel()
                         {
                            Id = 11,
                            Title = "flowers1",
                         }
                    },
            };
        }
    }
}
