using NUnit.Framework;
using CozaLozaWoza_Exercise6;

namespace ArithmeticsTests
{
    class Exercise6_Tests
    {
        private CozaLozaWoza _core;

        [SetUp]
        public void Setup()
        {
            _core = new CozaLozaWoza();
        }

        [Test]
        public void GetCozaLozaWozaOrNumber_NumberThatDividesByFifteen_ReturnCozaLoza()
        {
            //Assign
            int number = 15;
            string expectedResult = "CozaLoza ";
            //Assert
            Assert.AreEqual(expectedResult, _core.GetCozaLozaWozaOrNumber(number));
        }

        [Test]
        public void GetCozaLozaWozaOrNumber_NumberThatDividesBySeven_ReturnWoza()
        {
            //Assign
            int number = 7;
            string expectedResult = "Woza ";
            //Assert
            Assert.AreEqual(expectedResult, _core.GetCozaLozaWozaOrNumber(number));
        }

        [Test]
        public void GetCozaLozaWozaOrNumber_NumberThatDividesByFive_ReturnLoza()
        {
            //Assign
            int number = 5;
            string expectedResult = "Loza ";
            //Assert
            Assert.AreEqual(expectedResult, _core.GetCozaLozaWozaOrNumber(number));
        }

        [Test]
        public void GetCozaLozaWozaOrNumber_NumberThatDividesByThree_ReturnCoza()
        {
            //Assign
            int number = 3;
            string expectedResult = "Coza ";
            //Assert
            Assert.AreEqual(expectedResult, _core.GetCozaLozaWozaOrNumber(number));
        }

        [Test]
        public void GetCozaLozaWozaOrNumber_NumberThatCantBeDividedByFifteenSevenFiveOrThree_ReturnNumber()
        {
            //Assign
            int firstNumber = 11;
            int secondNumber = 1;
            string expectedResult1 = $"{firstNumber} ";
            string expectedResult2 = $"{secondNumber} ";
            //Assert
            Assert.AreEqual(expectedResult1, _core.GetCozaLozaWozaOrNumber(firstNumber));
            Assert.AreEqual(expectedResult2, _core.GetCozaLozaWozaOrNumber(secondNumber));
        }
    }
}
