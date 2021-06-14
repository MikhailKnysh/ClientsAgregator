using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace ClientsAgregator_BLL.Test.TestClases
{
    public class ValidationDataTests
    {
        [TestCase ("actual@gmail.com", true)]
        [TestCase("@gmail.com", false)]
        [TestCase(".actual@gmail.com", false)]
        [TestCase("gn79FQv8Bu1ZKnHxiT5NKiYKgTw4sj@yx2w0IPX89OVIZq.59Z", true)]
        [TestCase(null, false)]

        public void IsValidEmail_WhenStringEmail_ThenReturnBool(string email, bool expected)
        {
            bool actual = ValidationData.IsValidEmail(email);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("+12345678912", true)]
        [TestCase("+1234567891234567", true)]
        [TestCase("123456789123", false)]
        [TestCase("+1234567891", false)]
        [TestCase("+12345678912345678", false)]
        [TestCase(null, false)]

        public void IsValidPhone_WhenStringPhone_ThenReturnBool(string phone, bool expected)
        {
            bool actual = ValidationData.IsValidPhone(phone);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("+12345678912", 12, true)]
        [TestCase("+1234567891234567", 25, true)]
        [TestCase("123456789123", 5, false)]
        [TestCase(null, 10, true)]
        [TestCase("123456789123", -5, false)]

        public void IsValidStringLenght_WhenString_ThenReturnBool(string testStr, int IsValidStringLenght, bool expected)
        {
            bool actual = ValidationData.IsValidStringLenght(testStr, IsValidStringLenght);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("actual@gmail.com", true)]
        [TestCase("", false)]
        [TestCase(null, false)]

        public void IsStringNotNull_WhenString_ThenReturnBool(string testStr, bool expected)
        {
            bool actual = ValidationData.IsStringNotNull(testStr);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("7845", true)]
        [TestCase("77.44", false)]
        [TestCase("77,44", true)]
        [TestCase("77fgjjhg44", false)]
        [TestCase(null, true)]

        public void IsNumber_WhenString_ThenReturnBool(string testStr, bool expected)
        {
            bool actual = ValidationData.IsNumber(testStr);

            Assert.AreEqual(expected, actual);
        }
    }
}
