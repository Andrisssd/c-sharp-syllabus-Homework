using NUnit.Framework;
using Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace ClassesAndObjectsTests
{
    public class Exercise1_Tests
    {
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product("banana", 1.4, 5);
        }

        [Test]
        public void GetNamePriceAndAmount_ReturnParameterValueDictionary()
        {
            //Arrange
            string expectedName = "banana";
            double expectedPrice = 1.4;
            int expectedAmount = 5;
            //Act
            Dictionary<string, object> dictionary = _product.GetNamePriceAndAmount();
            var actualName = dictionary["Name"];
            var actualPrice = dictionary["Price"];
            var actualAmount = dictionary["Amount"];
            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedPrice, actualPrice);
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void SetNewPrice_5_ShouldSetPriceTo5()
        {
            //Arrange
            double expectedPrice = 5;
            //Act
            _product.SetNewPrice(expectedPrice);
            double actualPrice = (double)_product.GetNamePriceAndAmount()["Price"];
            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void SetNewPrice_InvalidPrice_ShouldThrowException()
        {
            //Arrange
            double invalidPrice = -5;
            //Assert
            Assert.Throws<PriceIsLowerThanZeroException>(() => _product.SetNewPrice(invalidPrice));
        }

        [Test]
        public void SetNewAmount_5_ShouldSetAmountTo5()
        {
            //Arrange
            int expectedAmount = 5;
            //Act
            _product.SetNewAmount(expectedAmount);
            int actualAmount = (int)_product.GetNamePriceAndAmount()["Amount"];
            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void SetNewAmount_InvalidAmount_ShouldThrowException()
        {
            //Arrange
            int invalidAmount = -1;
            //Assert
            Assert.Throws<AmountIsLowerThanZeroException>(() => _product.SetNewAmount(invalidAmount));
        }
    }
}