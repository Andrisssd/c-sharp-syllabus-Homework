using NUnit.Framework;
using GravityCalculator_7;

namespace ArithmeticsTests
{
    class Exercise7_Tests
    {
        private GravityCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new GravityCalculator();
        }

        [Test]
        public void CalculateFinalPositionAfter_10Seconds_Return481Dot1805()
        {
            //Assign
            double fallingTime = 10;
            double expectedFinalPosition = 481.1805;
            //Assert
            Assert.AreEqual(expectedFinalPosition, _calculator.CalculateFinalPositionAfter(fallingTime));
        }

        [Test]
        public void CalculateFinalPositionAfter_NegativeSeconds_ShouldThrowException()
        {
            //Assign
            double fallingTime = -1;
            //Assert
            Assert.Throws<InvalidInputTimeException>(() => _calculator.CalculateFinalPositionAfter(fallingTime));
        }

        [Test]
        public void GetResultString_ReturnResultString()
        {
            //Assign
            string expectedResult = "The object's position after 10 seconds is 481.1805 m.";
            //Act
            _calculator.CalculateFinalPositionAfter(10);
            string actualResult = _calculator.GetResultString();
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
