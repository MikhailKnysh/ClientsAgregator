using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.ProductSources
{
    public class GetMeasureUnitFromDTOSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                    new List<MeasureUnitDTO>()
                    {
                        new MeasureUnitDTO()
                        {
                            Id = 11,
                            Title = "KG",
                        },
                         new MeasureUnitDTO()
                         {
                            Id = 111,
                            Title = "KG1",
                         }
                    },
                    new List<MeasureUnitInfoModel>()
                    {
                          new MeasureUnitInfoModel()
                        {
                            Id = 11,
                            Title = "KG",
                        },
                         new MeasureUnitInfoModel()
                         {
                            Id = 111,
                            Title = "KG1",
                         }
                    },
            };

        }
    }
}
