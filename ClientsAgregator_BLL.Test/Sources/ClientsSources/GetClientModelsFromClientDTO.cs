using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.Sources.ClientsSources
{
    class GetClientModelsFromClientDTO : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<ClientDTO>()
                {
                    new ClientDTO()
                    {
                        BulkStatusTitle = "оптовый",
                        Email = "nick@mail.com",
                        FirstName = "Коля",
                        Id = 1,
                        LastName = "Котов",
                        Male = "Мужской",
                        MiddleName = "Серго",
                        Phone = "+3890",
                        СommentAboutСlient = "Татата"
                    },
                },

                new List<ClientModel>()
                {
                    new ClientModel()
                    {
                        BulkStatusTitle = "оптовый",
                        Email = "nick@mail.com",
                        FirstName = "Коля",
                        Id = 1,
                        LastName = "Котов",
                        Male = "Мужской",
                        MiddleName = "Серго",
                        Phone = "+3890",
                        СommentAboutСlient = "Татата"
                    },
                }
            };
        }
    }
}
