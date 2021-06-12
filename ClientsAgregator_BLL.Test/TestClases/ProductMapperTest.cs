using System.Collections.Generic;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_BLL.Test.Sources.ProductSourse;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Interface;
using Moq;
using NUnit.Framework;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class ProductMapperTest
    {
        Controller _controller;
        private Mock<IMainsHelper> _mock;

        [SetUp]

        public void Setup()
        {
            _mock = new Mock<IMainsHelper>();
            _controller = new Controller(null, null, null, _mock.Object);

        }

        [TestCaseSource(typeof(GetModelsFromDTOSource))]
        public void GetModelsFromDTO_WhenValidTestPassed_ShouldReturnProductSubgroupModels(
            List<ProductSubgroupDTO> actualProduct, List<ProductsSubgropModel> expected)
        {
            _mock.Setup(productHelper => productHelper.GetProductsSubgroup()).Returns(actualProduct);

            List<ProductsSubgropModel> actual = _controller.GetProductsSubgroupModels();

            Assert.AreEqual(expected, actual);
        }
    }
}
