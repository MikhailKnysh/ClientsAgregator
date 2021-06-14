using System.Collections;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.Sources.ClientsSources
{
    class GetClientDTOFromAddClientModelSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AddClientDTO()
                {
                    BulkStatusId = 1,
                    Email = "mail.com",
                    FirstName = "Sergei",
                    LastName = "Kotov",
                    Male = "men",
                    MiddleName = "Sergo",
                    Phone = "+3456",
                    CommentAboutClient = "eto"
                },

                new AddClientModel()
                {
                    BulkStatusId = 1,
                    Email = "mail.com",
                    FirstName = "Sergei",
                    LastName = "Kotov",
                    Male = "men",
                    MiddleName = "Sergo",
                    Phone = "+3456",
                    CommentAboutClient = "eto"
                },
            };
        }
    }
}
