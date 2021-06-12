using System.Collections.Generic;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using ClientsAgregator_BLL.Test.Sources.GetInterestedClientInfoBySubgroupSource;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Interface;
using Moq;
using NUnit.Framework;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class GetInterestedClientInfoBySubgroupTests
    {
        private Controller _controller;
        private Mock<IMainsHelper> _mock;

        [SetUp]

        public void Setup()
        {
            _mock = new Mock<IMainsHelper>();
            _controller = new Controller(null, null, null, _mock.Object);
        }

        [TestCaseSource(typeof(GetModelsFromDTO))]
        public void GetClientInfoBySubgroupTests_WhenValidTest_ShouldResultClientInfoBySubgroup(
            List<InterestedClientInfoByProductDTO> actualClientInfoByProduct,
            List<InterestedClientInfoByProductModel> expected)
        {
            _mock.Setup(mainHelper => mainHelper.GetInterestedClientInfoBySubgroup(1))
                .Returns(actualClientInfoByProduct);
            List<InterestedClientInfoByProductModel> actual = _controller.GetInterestedClientInfoBySubgroup(1);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetModelsFromDTO))]
        public void GetClientInfoByProductTests_WhenValidTest_ShouldResultClientInfoByProduct(
            List<InterestedClientInfoByProductDTO> actualClientInfoByProduct,
            List<InterestedClientInfoByProductModel> expected)
        {
            _mock.Setup(mainHelper => mainHelper.GetInterestedClientInfoByProduct(1))
                .Returns(actualClientInfoByProduct);
            List<InterestedClientInfoByProductModel> actual = _controller.GetInterestedClientInfoByProduct(1);

            Assert.AreEqual(expected, actual);
        }
    }
}