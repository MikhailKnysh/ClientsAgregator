using ClientsAgregator_DAL.Interface;
using Moq;
using NUnit.Framework;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class SpendMoneyCountMapperTests
    {
        private Controller _controller;
        private Mock<IClientsHelper> mock;
        [SetUp]
        public void Setup()
        {
            mock = new Mock<IClientsHelper>();
            _controller = new Controller(mock.Object);
        }

        [TestCase(10, 10)]
        [TestCase(15, 15)]
        [TestCase(20, 20)]
        public void GetSpendMoney_WhenValid_WhenValidTestPassed_ShouldReturnSpendMoney(int actualSpendMoney, int expected)
        {
            mock.Setup(spendMoney => spendMoney.GetSpendMoneyCountByClientId(1)).Returns(actualSpendMoney);
            
            int actual = _controller.GetSpendMoneyCountByClientIdModels(1);

            Assert.AreEqual(expected, actual);
        }

    }
}
