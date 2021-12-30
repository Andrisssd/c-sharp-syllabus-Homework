using NUnit.Framework;
using CheckOddEven_Exercise2;
using System;

namespace ArithmeticsTests
{
    public class Exercise2_Tests
    {
        private OddEven _core;

        [SetUp]
        public void Setup()
        {
            _core = new OddEven();
        }

        [Test]
        public void AskNumber_Five_ReturnFive()
        {
            //Arrange
            string input = "5";
            int number = 5;
            //Assert
            Assert.AreEqual(number, _core.AskNumber(input));
        }

        [Test]
        public void AskNumber_InvalidInput_ThrowException()
        {
            //Arrange
            string input = "a";
            //Assert
            Assert.Throws<InvalidNumberInputException>(() => _core.AskNumber(input));
        }

        [Test]
        public void NumberStatus_OddNumber_ReturnOdd()
        {
            //Arrange
            int number = 5;
            string expectedReturn = "Odd";
            //Assert
            Assert.AreEqual(expectedReturn, _core.NumbersStatus(number));
        }

        [Test]
        public void NumberStatus_EvenNumber_ReturnEven()
        {
            //Arrange
            int number = 4;
            string expectedReturn = "Even";
            //Assert
            Assert.AreEqual(expectedReturn, _core.NumbersStatus(number));
        }

        [Test]
        public void AskForExitStatus_Y_ReturnFalse()
        {
            //Arrange
            string input = "Y";
            //Assert
            Assert.IsFalse(_core.AskForExitStatus(input));
        }

        [Test]
        public void AskForExitStatus_N_ReturnTrue()
        {
            //Arrange
            string input = "N";
            //Assert
            Assert.IsTrue(_core.AskForExitStatus(input));
        }
    }
}