using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risks.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        private List<Risk> _list1;
        private List<Risk> _list2;
        private List<Risk> _list3;

        [TestInitialize]
        public void Setup()
        {
            _list1 = new List<Risk>
            {
                new Risk("1", 2),
                new Risk("2", 8),
            };
            _list2 = new List<Risk>
            {
                new Risk("1", 100),
                new Risk("2", 100),
            };
            _list3 = new List<Risk>();
        }

        [TestMethod()]
        public void CountRisksWorth_ListWith10TotalWorth_Return10()
        {
            //Arrange
            decimal expectedResult = 10;
            //Act
            decimal actualResult = Calculator.CountRisksWorth(_list1);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void CountRisksWorth_ListWith200TotalWorth_Return200()
        {
            //Arrange
            decimal expectedResult = 200;
            //Act
            decimal actualResult = Calculator.CountRisksWorth(_list2);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void CountRisksWorth_EmptyList_Return0()
        {
            //Arrange
            decimal expectedResult = 0;
            //Act
            decimal actualResult = Calculator.CountRisksWorth(_list3);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}