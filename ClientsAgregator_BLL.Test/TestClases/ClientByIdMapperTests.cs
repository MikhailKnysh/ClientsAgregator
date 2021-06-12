using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.Test.Sources.ClientsSources;
using ClientsAgregator_DAL.Interface;
using ClientsAgregator_DAL.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class ClientByIdMapperTests
    {
        private Controller _controller;
        private Mock<IClientsHelper> _mock;

        [SetUp]

        public void Setup()
        {
            _mock = new Mock<IClientsHelper>();
            _controller = new Controller(_mock.Object, null, null, null);
        }

        [TestCaseSource(typeof(GetModelsClientsByIdFromDTO))]
        public void GetGetClientByIdModelsTests_WhenValidTest_ShouldResultClientById(
            ClientDTO actualClientById, ClientModel expected)
        {
            _mock.Setup(ClientsHelper => ClientsHelper.GetClientById(1)).Returns(actualClientById);
            ClientModel actual = _controller.GetClientByIdModels(1);

            Assert.AreEqual(expected, actual);
        }
    }
}
