using System.Collections;
using System.Collections.Generic;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.Sources
{
    class ProductsBuyClientAndFeedbackSource : IEnumerable
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
                        ProductId = 2,
                        Description = "Хорошо",
                        Date = "06.06.2021",
                        Rate = 3,
                    },
                    new FeedbackModel()
                    {
                        Id = 2,
                        ClientId = 2,
                        ProductId = 2,
                        Description = "Плохо",
                        Date = "06.06.2021",
                        Rate = 1,
                    },  new FeedbackModel()
                    {
                        Id = 1,
                        ClientId = 1,
                        ProductId = 2,
                        Description = "Хорошо",
                        Date = "06.06.2021",
                        Rate = 5,
                    },
                    new FeedbackModel()
                    {
                        Id = 2,
                        ClientId = 2,
                        ProductId = 1,
                        Description = "Плохо",
                        Date = "06.06.2021",
                        Rate = 3,
                    },
                    new FeedbackModel()
                    {
                        Id = 1,
                        ClientId = 1,
                        ProductId = 1,
                        Description = "Хорошо",
                        Date = "06.06.2021",
                        Rate = 3,
                    },
                    new FeedbackModel()
                    {
                        Id = 2,
                        ClientId = 2,
                        ProductId = 1,
                        Description = "Плохо",
                        Date = "06.06.2021",
                        Rate = 3,
                    }
                },
                new List<ProductBuyClientModel>
                {
                    new ProductBuyClientModel()
                    {
                        ProductId = 1,
                        Articul = "111",
                        Title = "111",
                        SUMQuantity = 30,
                        GroupName = "111",
                        SubGroupName = "111",
                        AVGRate = "3"
                    },
                    new ProductBuyClientModel()
                    {
                        ProductId = 2,
                        Articul = "111",
                        Title = "111",
                        SUMQuantity = 30,
                        GroupName = "111",
                        SubGroupName = "111",
                        AVGRate = "3"
                    },
                }

            };
        }
    }
}
