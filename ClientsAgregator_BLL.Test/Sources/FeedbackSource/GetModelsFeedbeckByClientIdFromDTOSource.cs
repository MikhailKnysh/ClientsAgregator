using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.FeedbackSource
{
    public class GetModelsFeedbeckByClientIdFromDTOSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                    new FeedbackDTO()
                    {
                        Id = 1,
                        ClientId = 1,
                        ProductId = 1,
                        Description = "Хорошо",
                        Date = "06.06.2021",
                        Rate = 5,
                    },
                    new FeedbackModel()
                    {
                        Id = 1,
                        ClientId = 1,
                        ProductId = 1,
                        Description = "Хорошо",
                        Date = "06.06.2021",
                        Rate = 5,
                    },
            };

        }
    }
}
