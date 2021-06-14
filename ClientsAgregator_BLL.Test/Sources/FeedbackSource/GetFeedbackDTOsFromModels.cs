using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.Sources.FeedbackSource
{
    class GetFeedbackDTOsFromModels : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<FeedbackModel>()
                {
                    new FeedbackModel()
                    {
                        Id = 1,
                        ClientId = 1,
                        ProductId = 1,
                        OrderId = 1,
                        Description = "qqq",
                        Date = "11.11.11",
                        Rate = 5
                    }
                },
                new List<FeedbackDTO>()
                {
                    new FeedbackDTO()
                    {
                        Id = 1,
                        ClientId = 1,
                        ProductId = 1,
                        OrderId = 1,
                        Description = "qqq",
                        Date = "11.11.11",
                        Rate = 5
                    }
                },
            };
        }
    }
}
