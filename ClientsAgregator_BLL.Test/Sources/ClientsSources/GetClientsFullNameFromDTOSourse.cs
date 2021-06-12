using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_DAL.CustomModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.ClientsSources
{
    public class GetClientsFullNameFromDTOSourse : IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return new object[] 
            {
                    new List<ClientFullNameDTO>()
                    {
                        new ClientFullNameDTO()
                        {
                            Id = 1,
                            LastName = "Ivan",
                            FirstName = "Ivanov",
                            MiddleName = "Ivanovish",
                        },
                        new ClientFullNameDTO()
                        {
                            Id = 11,
                            LastName = "Ivan1",
                            FirstName = "Ivanov1",
                            MiddleName = "Ivanovish1",
                        }
                    },
                    new List<ClientsFullNameModel>()
                    {
                         new ClientsFullNameModel()
                         {
                            Id = 1,
                            FullName = "Ivan Ivanov Ivanovish",

                         },
                        new ClientsFullNameModel()
                        {
                            Id = 11,
                            FullName = "Ivan1 Ivanov1 Ivanovish1",
                        }

                    }
            };
        }
    }
}
