using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.Test.Sources.OrdedSources;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Interface;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using ClientsAgregator_DAL.Models;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class OrderMapperTests
    {
        private Controller _controller;
        private Mock<IOrdersHelper> _mock;

        [SetUp]

        public void Setup()
        {
            _mock = new Mock<IOrdersHelper>();
            _controller = new Controller(null, null, _mock.Object, null);
        }

        [TestCaseSource(typeof(GetOrderInfoDTOFromOrderModels))]
        public void GetOrderModelsFromDTO_WhenValidTestPassed_ShouldReturnOrderModels(
            List<OrdersInfoDTO> ordersInfo, List<OrdersInfoModel> expected)
        {
            _mock.Setup(orderHelper => orderHelper.GetOrdersInfo()).Returns(ordersInfo);

            List<OrdersInfoModel> actual = _controller.GetOrderModels();

            Assert.AreEqual(expected, actual);
        }

        //[TestCaseSource(typeof(GetDTOsFromNewOrderInfoModel))]
        //public void GetDTOsFromNewOrderInfoModel_WhenValidTestPassed_ShouldReturnDTOs(NewOrderInfoModel newOrderInfo,
        //    OrderDTO expectedOrder, List<Product_OrderDTO> expectedProductsOrder)
        //{
        //    _mock.Setup(orderHelper => orderHelper.AddOrder(expectedProductsOrder,expectedOrder)).Verifiable();

        //    _controller.AddOrder(newOrderInfo);

        //    _mock.Verify();
        //}

        [TestCase(1,1)]
        public void DeleteOrder_WhenValidTestPassed_ShouldDeleteOrder(int id, int expectedId)
        {
            _mock.Setup(orderHelper => orderHelper.DeleteOrder(expectedId)).Verifiable();

            _controller.DeleteOrder(id);

            _mock.Verify();
        }


    }
}
