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
    }
}
