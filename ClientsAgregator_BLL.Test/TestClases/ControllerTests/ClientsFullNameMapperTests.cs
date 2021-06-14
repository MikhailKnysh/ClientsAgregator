using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.Test.Sources.ClientsSources;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.Test.TestClases
{
    public class ClientsFullNameMapperTests
    {
        private Controller _controller;
        private Mock<IOrdersHelper> _mock;

        [SetUp]

        public void Setup()
        {
            _mock = new Mock<IOrdersHelper>();
            _controller = new Controller(null, null, _mock.Object, null);
        }

        [TestCaseSource(typeof(GetClientsFullNameFromDTOSourse))]

        public void GetClientsFullNameFromDTOSourse_WhenValidTestPassed_ShouldReturnFullName(List<ClientFullNameDTO> clientFullNameDTOs, List<ClientsFullNameModel> expected)
        {
            _mock.Setup(ordersHelper => ordersHelper.GetClientsFullNames()).Returns(clientFullNameDTOs);

            List<ClientsFullNameModel> actual = _controller.GetClientsFullNameModels();

            Assert.AreEqual(expected, actual);
        }
    }
}
