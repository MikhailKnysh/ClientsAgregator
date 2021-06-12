using System.Collections.Generic;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_BLL.Test.Sources.ProductSourse;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Interface;
using Moq;
using NUnit.Framework;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class ProductMapperTests
    {
        Controller _controller;
        private Mock<IProductsHelper> _mock;

        [SetUp]

        public void Setup()
        {
            _mock = new Mock<IProductsHelper>();
            _controller = new Controller(null, _mock.Object, null, null);
        }

        [TestCaseSource(typeof(GetModelFromDTOSource))]
        public void GetModelFromDTO_WhenValidTestPassed_ShouldReturnProductInfoModel(
            ProductInfoDTO actualProductInfoDTO, ProductInfoModel expected)
        {
            _mock.Setup(productHelper => productHelper.GetProductInfoById(1)).Returns(actualProductInfoDTO);

            ProductInfoModel actual = _controller.GetProductInfoModel(1);

            Assert.AreEqual(expected, actual);
        }
    }
}
