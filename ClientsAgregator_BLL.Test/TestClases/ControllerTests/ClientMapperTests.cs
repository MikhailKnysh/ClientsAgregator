using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.Test.Sources.ClientsSources;
using ClientsAgregator_DAL.Interface;
using ClientsAgregator_DAL.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class ClientMapperTests
    {
        private Controller _controller;
        private Mock<IClientsHelper> _mock;

        [SetUp]

        public void Setup()
        {
            _mock = new Mock<IClientsHelper>();
            _controller = new Controller(_mock.Object, null, null, null);
        }

        [TestCaseSource(typeof(GetModelsClientsByIdFromDTOSourse))]
        public void GetClientByIdModelsTests_WhenValidTestPassed_ShouldResultClientById(
            ClientDTO actualClientById, ClientModel expected)
        {
            _mock.Setup(ClientsHelper => ClientsHelper.GetClientById(1)).Returns(actualClientById);
            ClientModel actual = _controller.GetClientByIdModels(1);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetClientModelsFromClientDTO))]
        public void GetClientsModelsFromClientDTO_WhenValidTestPassed_ShouldResultClientModels(List<ClientDTO> clientDTO, List<ClientModel> expected)
        {
            _mock.Setup(clientsHelper => clientsHelper.GetClients()).Returns(clientDTO);

            List<ClientModel> actual = _controller.GetClientsModels();

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetClientDTOFromAddClientModelSource))]
        public void GetUpdateClientsDTOFromAddClientModel_WhenValidTestPassed_ShouldResultClientDTO( AddClientDTO expected, AddClientModel clientModel)
        {
            _mock.Setup(clientsHelper => clientsHelper.UpdateClientById(expected, 0)).Verifiable();

            _controller.UpdateClientDTO(clientModel, 0);

            _mock.Verify();
        }

        [TestCaseSource(typeof(GetClientDTOFromAddClientModelSource))]
        public  void GetClientDTOFromAddClientModel_WhenValidTestPassed_ShouldResultClientDTO (AddClientDTO expected, AddClientModel clientModel)
        {
            _mock.Setup(clientsHelper => clientsHelper.AddClient(expected)).Verifiable();

            _controller.AddClientDTO(clientModel);

            _mock.Verify();
        }


}
}
