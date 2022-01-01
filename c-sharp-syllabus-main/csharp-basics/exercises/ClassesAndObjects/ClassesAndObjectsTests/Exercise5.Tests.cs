using NUnit.Framework;
using Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;
using Exercise5;

namespace ClassesAndObjectsTests
{
    class Exercise5_Tests
    {
        private Date _date;

        [SetUp]
        public void Setup()
        {
            _date = new Date();
        }

        [Test]
        public void GetDate_ReturnThreeZeros()
        {
            //Arrange
            string expectedResult = "0/0/0";
            //Act
            string actualResult = _date.GetDate();
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SetDate_Date_ShouldSetDate()
        {
            //Arrange
            int year = 2000;
            int month = 12;
            int day = 30;
            string expectedResult = $"{year}/{month}/{day}";
            //Act
            _date.SetDate(year, month, day);
            string actualResult = _date.GetDate();
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(2000,45,3)]
        [TestCase(99999, 11, 11)]
        [TestCase(2000, 11, 45)]
        public void SetDate_InvalidDate_ShouldThrowException(int year, int month, int day)
        {
            //Assert
            Assert.Throws<InvalidParameterException>(() => _date.SetDate(year, month, day));
        }
    }
}
