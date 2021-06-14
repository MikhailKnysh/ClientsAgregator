using System;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_DAL.Interface;
using Moq;
using NUnit.Framework;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class GroupMapperTests
    {
        private Controller _controller;
        private Mock<IProductsHelper> _mock;

        [SetUp]

        public void Setup()
        {
            _mock = new Mock<IProductsHelper>();
            _controller = new Controller(null, _mock.Object, null, null);
        }

        [TestCase(1,1, "tatata")]
        public void AddSubgropGroup_WhenValidTestPassed_ShouldAddSubgropGroup(int groupId, int expectedGroupId, string subGroupTitle)
        {
            _mock.Setup(productHelper => productHelper.AddProductSubgroup(subGroupTitle)).Returns(1);
            _mock.Setup(productHelper => productHelper.AddSubgroupGroup(1,expectedGroupId)).Verifiable();

            _controller.AddSubgropGroup(groupId,subGroupTitle);

            _mock.Verify();
        }

        [TestCase("кг", "кг")]
        public void AddMeasureUnuit_WhenValidTestPassed_ShouldAddMeasureUnuit(string measureUnitTitle,
            string expectedMeasureUnitTitle)
        {
            _mock.Setup(productHelper => productHelper.AddMeasureUnits(expectedMeasureUnitTitle)).Verifiable();

            _controller.AddMeasureUnuit(measureUnitTitle);

            _mock.Verify();
        }

        [TestCase("Зимние", "Зимние")]
        public void AddGroup_WhenValidTestPassed_ShouldAddGroup(string groupTitle, string expectedGroupTitle)
        {
            _mock.Setup(productHelper => productHelper.AddProductGroup(expectedGroupTitle)).Verifiable();

            _controller.AddGroup(groupTitle);

            _mock.Verify();
        }
    }
}
