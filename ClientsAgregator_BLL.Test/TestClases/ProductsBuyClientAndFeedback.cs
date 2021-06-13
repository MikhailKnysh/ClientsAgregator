using System;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Interface;
using Moq;
using NUnit.Framework;

namespace ClientsAgregator_BLL.Test.TestClases
{
    class ProductsBuyClientAndFeedback
    {
        private Mock<List<FeedbackModel>> _mock;
        
        [SetUp]

        public void Setup()
        {
            _mock = new Mock<List<FeedbackModel>>();

        }

        public void qqqqq()
        {
            _mock.Setup()
        }

    }
}
