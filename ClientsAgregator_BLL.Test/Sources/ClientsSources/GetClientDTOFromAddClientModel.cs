using System.Collections;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.Sources.ClientsSources
{
    class GetClientDTOFromAddClientModel : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AddClientDTO()
                {
                    LastName ="Ivan",
                    FirstName = "Ivanov",
                    MiddleName = "Ivanovish",
                    Phone = "+123451212",
                    Email ="assd@.com",
                    BulkStatusId = 1,
                    Male = "he",
                    СommentAboutСlient = "qazwsxedc"
                },

                new AddClientModel()
                {
                    LastName ="Ivan",
                    FirstName = "Ivanov",
                    MiddleName = "Ivanovish",
                    Phone = "+123451212",
                    Email ="assd@.com",
                    BulkStatusId = 1,
                    Male = "he",
                    СommentAboutСlient = "qazwsxedc"
                },
            };
        }
    }
}
