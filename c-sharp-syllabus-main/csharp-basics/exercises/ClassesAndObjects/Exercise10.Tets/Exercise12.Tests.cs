using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AccountNamespace;

namespace Exercise12.Tets
{
    [TestClass]
    public class Exercise12_Tests
    {
        private Account _account1;
        private Account _account2;

        [TestInitialize]
        public void Setup()
        {
            _account1 = new Account("Andris", 10);
            _account2 = new Account("John", 100);
                
        }

        [TestMethod]
        public void Withdrawal_10_ShouldRemove10FromBalance()
        {
            //Arrange
            double amount = 10;
            double expectedAmount = 90;
            //Act
            _account2.Withdrawal(amount);
            double actualAmount = _account2.Balance();
            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        public void Withdrawal_110_ShouldThrowException()
        {
            //Arrange
            double amount = 110;
            //Assert
            Assert.ThrowsException<NotEnoughMoneyException>(() => _account2.Withdrawal(amount));
        }

        [TestMethod]
        public void ToString_ReturnNameAndMoney()
        {
            //Arrange
            string expectedResult = $"{_account1.Name}: {_account1.Balance()}";
            //Act
            string actualResult = _account1.ToString();
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Transfer_10_ShouldTransfer10()
        {
            //Arrange
            double account1BalanceBefore = _account1.Balance();
            double account2BalanceBefore = _account2.Balance();
            //Act
            Account.Transfer(_account1, _account2, 10);
            bool account1WithdrawWorks = (account1BalanceBefore - _account1.Balance()) == 10;
            bool account2AddMoneyWorks = (account2BalanceBefore - _account2.Balance()) == -10;
            //Assert
            Assert.IsTrue(account1WithdrawWorks);
            Assert.IsTrue(account2AddMoneyWorks);
        }

        [TestMethod]
        public void Deposit_10_ShouldAdd10ToBalance()
        {
            //Arrange
            double amount = 10;
            double expectedAmount = 20;
            //Act
            _account1.Deposit(amount);
            double actualAmount = _account1.Balance();
            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }
    }
}
