using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.CustomModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.Sources.ProductSources
{
    class GetModelsProductInfoFromDTOSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<ProductInfoDTO>(){
                    new ProductInfoDTO()
                    {
                    Id = 1,
                    Articul = "123",
                    Title = "123",
                    Price = 10,
                    Quantity = 123,
                    MeasureUnit = "1234",
                    Subgroup = "ball",
                    Group = "sport"
                    },
                    new ProductInfoDTO()
                    {
                    Id = 11,
                    Articul = "1231",
                    Title = "1231",
                    Price = 101,
                    Quantity = 1231,
                    MeasureUnit = "12341",
                    Subgroup = "ball1",
                    Group = "sport1"
                    }
                },
                new List<ProductInfoModel>()
                {
                    new ProductInfoModel()
                    {
                    Id = 1,
                    Articul = "123",
                    Title = "123",
                    Price = 10,
                    Quantity = 123,
                    MeasureUnit = "1234",
                    Subgroup = "ball",
                    Group = "sport"
                    },
                    new ProductInfoModel()
                    {
                    Id = 11,
                    Articul = "1231",
                    Title = "1231",
                    Price = 101,
                    Quantity = 1231,
                    MeasureUnit = "12341",
                    Subgroup = "ball1",
                    Group = "sport1"
                    }
                }
            };
        }
    }
}
