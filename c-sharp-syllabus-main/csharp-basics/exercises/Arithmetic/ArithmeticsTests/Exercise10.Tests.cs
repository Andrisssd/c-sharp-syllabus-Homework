using NUnit.Framework;
using CalculateArea;
using System;

namespace ArithmeticsTests
{
    class Exercise10_Tests
    {
        private Geometry _geometry;

        [SetUp]
        public void Setup()
        {
            _geometry = new Geometry();
        }

        [Test]
        public void AreaOfCircle_3_Return28()
        {
            //Arrange
            decimal radius = 3;
            double expectedResult = 28;
            //Act
            double actualResult = Math.Round(_geometry.AreaOfCircle(radius));
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AreaOfCircle_DecimalLowerThanZero_ShouldThrowException()
        {
            //Arrange
            decimal radius = -1;
            //Assert
            Assert.Throws<InvalidParameterException>(() => _geometry.AreaOfCircle(radius));
        }

        [Test]
        public void AreaOfRectangle_5And5_Return25()
        {
            //Arrange
            decimal expectedResult = 25;
            //Act
            double actualResult = _geometry.AreaOfRectangle(5, 5);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AreaOfRectangle_Minus5And5_ShouldThrowException()
        {
            //Assert
            Assert.Throws<InvalidParameterException>(() => _geometry.AreaOfRectangle(-5, 5));
        }

        [Test]
        public void AreaOfRectangle_5AndMinus5_ShouldThrowException()
        {
            //Assert
            Assert.Throws<InvalidParameterException>(() => _geometry.AreaOfRectangle(5, -5));
        }

        [Test]
        public void AreaOfTriange_5And6_Return15()
        {
            //Arrange
            decimal ground = 5;
            decimal h = 6;
            double expectedResult = 15;
            //Act
            double actualResult = _geometry.AreaOfTriangle(ground, h);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AreaOfTriangle_5AndMinus5_ShouldThrowException()
        {
            //Assert
            Assert.Throws<InvalidParameterException>(() => _geometry.AreaOfTriangle(5, -5));
        }

        [Test]
        public void AreaOfTriangle_Minus5And5_ShouldThrowException()
        {
            //Assert
            Assert.Throws<InvalidParameterException>(() => _geometry.AreaOfTriangle(-5, 5));
        }
    }
}
