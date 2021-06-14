using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;
using NUnit.Framework;
using System.Collections.Generic;
using ClientsAgregator_DAL.Interface;
using Moq;
using ClientsAgregator_BLL.Test.Sources.BulkStatusSources;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class BulkStatusMapperTests
    {
        private Controller _controller;
        private Mock<IClientsHelper> _mock;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IClientsHelper>();
            _controller = new Controller(_mock.Object, null, null, null);
        }


        [TestCaseSource(typeof(GetModelsBulkStatusFromDTOSource))]
        public void GetModelsFromDTO_WhenValidTestPassed_ShouldReturnListBulkStatusModels(List<BulkStatusDTO> actualBulkStatusesDTO, List<BulkStatusModel> expected)
        {
            _mock.Setup(сlientsHelper => сlientsHelper.GetBulkStatuses()).Returns(actualBulkStatusesDTO);
            List<BulkStatusModel> actual = _controller.GetBulkStatusesModels();

            Assert.AreEqual(expected, actual);
        }
    }
}
