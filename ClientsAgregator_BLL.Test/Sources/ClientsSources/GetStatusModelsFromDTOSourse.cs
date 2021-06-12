using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_DAL.Models;
using System.Collections;
using System.Collections.Generic;

namespace ClientsAgregator_BLL.Test.Sources.ClientsSources
{
    class GetStatusModelsFromDTOSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<StatusDTO>()
                { 
                    new StatusDTO()
                    {
                        Id = 1,
                        Title = "Of"
                    },
                    new StatusDTO()
                    {
                        Id = 11,
                        Title = "on",
                    }
                },
                new List<StatusModel>
                { 
                    new StatusModel()
                    {
                        Id = 1,
                        Title = "Of"
                    },
                     new StatusModel()
                     {
                        Id = 11,
                        Title = "on"
                     }
                },
            };

        }
    }
}
