using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.Test.Sources.FeedbackSources;
using ClientsAgregator_DAL.Models;
using NUnit.Framework;
using System.Collections.Generic;
using ClientsAgregator_DAL.Interface;
using Moq;
using ClientsAgregator_BLL.Test.Sources.FeedbackSource;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class FeedbackMapperTests
    {
        private Controller _controller;
        private Mock<IClientsHelper> _mock;
        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IClientsHelper>();
            _controller = new Controller(_mock.Object, null, null, null);
        }

        [TestCaseSource(typeof(GetModelsFromDTOSource))]
        public void GetModelsFromDTO_WhenValidTestPassed_ShouldReturnListFeedbackModels(List<FeedbackDTO> actualFeedbackDTO, List<FeedbackModel> expected)
        {

            _mock.Setup(ClientHelper => ClientHelper.GetFeedbacks()).Returns(actualFeedbackDTO);

            List<FeedbackModel> actual = _controller.GetFeedbackModels();

            Assert.AreEqual(expected, actual);
        }
    }
}
