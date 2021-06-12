using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.ClientsSources
{
    class GetModelsClientsByIdFromDTO : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                        new ClientDTO()
                        {
                          Id = 1,
                          LastName ="Ivan",
                          FirstName = "Ivanov",
                          MiddleName = "Ivanovish",
                          Phone = "+123451212",
                          Email ="assd@.com",
                          BulkStatusTitle = "Оптовый",
                          Male = "he",
                          СommentAboutСlient = "qazwsxedc"
                        },

                        new ClientModel()
                        {
                          Id = 1,
                          LastName ="Ivan",
                          FirstName = "Ivanov",
                          MiddleName = "Ivanovish",
                          Phone = "+123451212",
                          Email ="assd@.com",
                          BulkStatusTitle = "Оптовый",
                          Male = "he",
                          СommentAboutСlient = "qazwsxedc"
                        },
            };
        }
    }
}
