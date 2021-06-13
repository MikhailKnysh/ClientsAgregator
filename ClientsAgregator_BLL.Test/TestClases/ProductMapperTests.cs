using System.Collections.Generic;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_BLL.Test.Sources.ClientsSources;
using ClientsAgregator_BLL.Test.Sources.ProductSources;
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

        [TestCaseSource(typeof(GetGroupsModelFromDTOSource))]
        public void GetModelGroupFromDTO_WhenValidTestPassed_ShouldReturnGroupInfoModel(
                    List<GroupDTO>  groupDTOs, List<GroupInfoModel> expected)
        {
            _mock.Setup(productHelper => productHelper.GetGroups()).Returns(groupDTOs);

            List<GroupInfoModel>  actual = _controller.GetGroups();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetSubgroupsModelFromDTOSource))]
        public void GetModelSubgroupFromDTO_WhenValidTestPassed_ShouldReturnSubgroupInfoModel(
            List<SubgroupDTO> subgroupDTOs , List<SubgroupInfoModel> expected)
        {
            _mock.Setup(productHelper => productHelper.GetSubgroupsInfoByGroupId(1)).Returns(subgroupDTOs);

            List<SubgroupInfoModel> actual = _controller.GetSubgroupsInfoByGroupId(1);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetMeasureUnitFromDTOSourse))]
        public void GetModelMeasureUnitFromDTO_WhenValidTestPassed_ShouldReturnMeasureUnitInfoModel(
                  List<MeasureUnitDTO> measureUnitDTOs, List<MeasureUnitInfoModel> expected)
        {
            _mock.Setup(productHelper => productHelper.GetMeasureUnits()).Returns(measureUnitDTOs);

            List<MeasureUnitInfoModel> actual = _controller.GetMeasureUnit();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetModelsProductInfoFromDTOSourse))]
        public void GetModelsProductInfoFromDTOSourse_WhenValidTestPassed_ShouldReturnProductInfoModel(
          List<ProductInfoDTO> actualProductInfoDTO,List<ProductInfoModel> expected)
        {
            _mock.Setup(productHelper => productHelper.GetProductsInfo()).Returns(actualProductInfoDTO);

            List<ProductInfoModel> actual = _controller.GetProductInfoModels();

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

        [TestCase(1,1)]
        public void DeleteProduct_WhenValidTestPassed_shouldDeleteProduct( int id, int expectedId)
        {

            _mock.Setup(productHelper => productHelper.DeleteProductById(expectedId)).Verifiable();
            _mock.Setup(productHelper => productHelper.DeleteProductSubgroupByProductId(expectedId)).Verifiable();

            _controller.DeleteProduct(id);

            _mock.Verify();
        }


    }
}
