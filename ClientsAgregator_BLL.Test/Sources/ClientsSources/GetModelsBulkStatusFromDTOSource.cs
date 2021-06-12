using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.BulkStatusSources
{
    public class GetModelsBulkStatusFromDTOSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] {

                new List<BulkStatusDTO>()
                {
                    new BulkStatusDTO()
                    {
                        Id = 1,
                        Title = "Оптовый",
                    },
                    new BulkStatusDTO()
                    {
                        Id = 2,
                        Title = "Розничный",
                    }
                },
                new List<BulkStatusModel>()
                {
                    new BulkStatusModel()
                    {
                        Id = 1,
                        Title = "Оптовый",
                    },
                    new BulkStatusModel()
                    {
                        Id = 2,
                        Title = "Розничный",
                    }
                }
            };
        }
    }
}
