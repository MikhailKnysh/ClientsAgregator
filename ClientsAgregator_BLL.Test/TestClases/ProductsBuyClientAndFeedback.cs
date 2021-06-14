using System.Collections.Generic;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.Test.Sources;
using Moq;
using NUnit.Framework;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class ProductsBuyClientAndFeedbackTest
    {
        private Mock<IController> _mock;
        private ProductsBuyClientAndFeedback productsBuyClient;

        [SetUp]

        public void Setup()
        {
            _mock = new Mock<IController>();
            productsBuyClient = new ProductsBuyClientAndFeedback(_mock.Object);
        }

        [TestCaseSource(typeof(ProductsBuyClientAndFeedbackSource))]
        public void GetProductBuyClientAndFeedback_WhenValidTestPassed_ShouldReturnProductBuyClientModel(
            List<FeedbackModel> feedbacks, List<ProductBuyClientModel> productBuyClient, List<ProductBuyClientModel> expected)
        {
            _mock.Setup(controller => controller.GetFeedbackModels()).Returns(feedbacks);
            _mock.Setup(controller => controller.GetProductsBuyClientModels(1)).Returns(productBuyClient);

            List<ProductBuyClientModel> actual = productsBuyClient.GetProductBuyClientAndFeedback(1);

            Assert.AreEqual(expected, actual);
        }
    }
}
