using System.Collections.Generic;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_BLL.Test.Sources.ClientsSources;
using ClientsAgregator_BLL.Test.Sources.ProductSourse;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Interface;
using ClientsAgregator_DAL.Models;
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

        [TestCaseSource(typeof(GetProductsBuyClientModelsFromDTOSource))]
        public void GetModelsFromDTO_WhenValidTestPassed_ShouldReturnProductsBuyClientModels(
            List<ProductsBuyClientDTO> actualBuyClientDTO, List<ProductBuyClientModel> expected)
        {
            Mock<IClientsHelper> mock = new Mock<IClientsHelper>();
            Controller controller = new Controller(mock.Object, null, null, null);

            mock.Setup(clientsHelper => clientsHelper.GetProductsBuyClient(1)).Returns(actualBuyClientDTO);

            List<ProductBuyClientModel> actual = controller.GetProductsBuyClientModels(1);

            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(typeof(GetProductDTOFromProductModel))]
        public void GetProductDTOFromProductModel_WhenValidTestPassed_ShouldReturnProductDTO(
            AddingProductModel productModel, ProductDTO expected)
        {
            _mock.Setup(productHelper => productHelper.AddProduct(expected)).Returns(0);
            _mock.Setup(productHelper => productHelper.AddProductSubgroup(0, productModel.SubgroupId)).Verifiable();

            _controller.AddProduct(productModel);

            _mock.Verify();
        }


        //mock.Setup(adder => (adder.Add(expextedA, expextedB))).Verifiable();

        //calc.SummSqr(a, b);

        //mock.Verify();



    }
}
