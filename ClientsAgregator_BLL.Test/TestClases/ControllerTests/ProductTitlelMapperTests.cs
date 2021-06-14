using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.Test.Sources.ClientsSources;
using ClientsAgregator_BLL.Test.Sources.ProductSourse;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Interface;
using ClientsAgregator_DAL.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.TestClases
{
    public class ProductTitlelMapperTests
    {
        private Controller _controller;
        private Mock<IOrdersHelper> _mock;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IOrdersHelper>();
            _controller = new Controller(null, null, _mock.Object, null);
        }

        [TestCaseSource(typeof(GetProductTitlesDTOSourse))]
        public void GetProductTitlesDTOSourse_WhenValidTestPassed_ShouldReturnProductTitles(List<ProductSubgroupDTO> productSubgroupDTOs, List<ProductTitleModel> expected)
        {
            _mock.Setup(ordersHelper => ordersHelper.GetProductTitles()).Returns(productSubgroupDTOs);

            List<ProductTitleModel> actual = _controller.GetProductTitlesModels();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetStatusModelsFromDTOSourse))]
        public void GetStatusOrderDTOSourse_WhenValidTestPassed_ShouldReturnStatusOrders(List<StatusDTO> statusDTOs , List<StatusModel> expected)
        {
            _mock.Setup(ordersHelper => ordersHelper.GetStatusTitles()).Returns(statusDTOs);

            List<StatusModel> actual = _controller.GetStatusModels();

            Assert.AreEqual(expected, actual);
        }

    }
}
