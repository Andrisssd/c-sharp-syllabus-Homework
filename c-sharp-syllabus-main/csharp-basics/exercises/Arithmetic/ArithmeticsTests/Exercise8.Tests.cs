using NUnit.Framework;
using Foo_Corporation_Exercise8;


namespace ArithmeticsTests
{
    class Exerice8_Tests
    {
        private EmployeesPaymentCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new EmployeesPaymentCalculator();
        }

        [Test]
        public void GetFooEmployeesPaymentForHours_8And45_Return380()
        {
            //Arrange
            decimal expectedResult = 380M;
            //Act
            decimal actualResult = _calculator.GetFooEmployeesPaymentForHours(8, 45);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetFooEmployeesPaymentForHours_7And45_ShouldThrowException()
        {
            //Assert
            Assert.Throws<EmployeesPaymentLimitException>(() => _calculator.GetFooEmployeesPaymentForHours(7, 45));
        }

        [Test]
        public void GetFooEmployeesPaymentForHours_8And61_ShouldThrowException()
        {
            //Assert
            Assert.Throws<WeekOverworkException>(() => _calculator.GetFooEmployeesPaymentForHours(8, 61));
        }

        [Test]
        public void GetFooEmployeesPaymentForHours_8And30_ShouldThrowException()
        {
            //Arrange
            decimal expectedResult = 8 * 30;
            //Act
            decimal actualResult = _calculator.GetFooEmployeesPaymentForHours(8, 30);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
