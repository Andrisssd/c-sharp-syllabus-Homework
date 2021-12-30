using NUnit.Framework;
using Exercise1;

namespace ArithmeticsTests
{
    public class Exercise1_Tests
    {
        private CompareFabric _fabric;
        private int _numberToCompareWith;

        [SetUp]
        public void Setup()
        {
            _numberToCompareWith = 15;
            _fabric = new CompareFabric(_numberToCompareWith);
        }

        [Test]
        public void SumValid_ValidNumbers_ReturnTrue()
        {
            //Arrange
            int firstNum = 10;
            int secondNum = 5;
            //Assert
            Assert.IsTrue(_fabric.IsSumValid(firstNum, secondNum));
        }

        [Test]
        public void SumValid_InvalidNumbers_ReturnFalse()
        {
            //Arrange
            int num = 10;
            //Assert
            Assert.IsFalse(_fabric.IsSumValid(num, num));
        }

        [Test]
        public void DifferenceValid_ValidNumbers_ReturnTrue()
        {
            //Arrange
            int firstNum = 20;
            int secondNum = 5;
            //Assert
            Assert.IsTrue(_fabric.DifferenceValid(firstNum, secondNum));
        }

        [Test]
        public void DifferenceValid_InvalidNumbers_ReturnFalse()
        {
            //Arrange
            int firstNum = 20;
            int secondNum = 20;
            //Assert
            Assert.IsFalse(_fabric.DifferenceValid(firstNum, secondNum));
        }

        [Test]
        public void IsAnyNumberTheOneWeNeed_InvalidNumbers_ReturnFalse()
        {
            //Arrange
            int firstNum = 10;
            int secondNum = 14;
            //Assert
            Assert.IsFalse(_fabric.IsAnyNumberTheOneWeNeed(firstNum, secondNum));
        }

        [Test]
        public void IsAnyNumberTheOneWeNeed_ValidNumbers_ReturnTrue()
        {
            //Arrange
            int firstNum = 15;
            int secondNum = 14;
            //Assert
            Assert.IsTrue(_fabric.IsAnyNumberTheOneWeNeed(firstNum, secondNum));
        }

        [Test]
        public void IsNumberValid_ValidNumbers_ReturnTrue()
        {
            //Arrange
            int firstNum = 15;
            int secondNum = 14;
            //Assert
            Assert.IsTrue(_fabric.IsNumberValid(firstNum, secondNum));
        }

        [Test]
        public void IsNumberValid_InvalidNumbers_ReturnFalse()
        {
            //Arrange
            int firstNum = 14;
            int secondNum = 14;
            //Assert
            Assert.IsFalse(_fabric.IsNumberValid(firstNum, secondNum));
        }
    }
}