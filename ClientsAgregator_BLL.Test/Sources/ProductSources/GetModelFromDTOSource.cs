using System.Collections;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_DAL.CustomModels;

namespace ClientsAgregator_BLL.Test.Sources.ProductSourse
{
    class GetModelFromDTOSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ProductInfoDTO()
                {
                    Articul = "123",
                    Group = "Кофе",
                    Id = 1,
                    MeasureUnit = "кг",
                    Price = 1,
                    Quantity = 10,
                    Subgroup = "Мексика",
                    Title = "нескафе",
                },
                new ProductInfoModel()
                {
                    Articul = "123",
                    Group = "Кофе",
                    Id = 1,
                    MeasureUnit = "кг",
                    MeasureUnitId = 0,
                    Price = 1,
                    Quantity = 10,
                    Subgroup = "Мексика",
                    Title = "нескафе",
                }
            };
        }
    }
}
