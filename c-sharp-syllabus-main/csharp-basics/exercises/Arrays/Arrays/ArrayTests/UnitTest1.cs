using NUnit.Framework;
using Exercise6;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ArrayTests
{
    public class Tests
    {
        private ArrayContainer _container;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _container = new ArrayContainer();
        }

        [Test]
        public void MakeRandomArrayWithLength_10_ReturnArrayWithLength10()
        {
            //Arrange
            int length = 10;
            //Act
            int[] actualArray = _container.MakeRandomArrayWithLength(length);
            //Assert
            Assert.AreEqual(length, actualArray.Length);
        }

        [Test]
        public void MakeRandomArrayWithLength_ZeroOrLess_ShouldThrowNewException()
        {
            //Arrange
            int length = new Random().Next(-100, 0);
            //Assert
            Assert.Throws<NotValidLengthParameterException>(() => _container.MakeRandomArrayWithLength(length));
        }
        
        [Test]
        public void CopyArrayFrom_Array_ReturnNewArray()
        {
            //Arrange
            int[] arrayToCopy = _container.MakeRandomArrayWithLength(10);
            //Act
            int[] arraysCopy = _container.CopyArrayFrom(arrayToCopy);
            bool areTheSameArrays = arrayToCopy == arraysCopy;
            //Assert
            Assert.IsFalse(areTheSameArrays);
        }

        [Test]
        public void ChangeLastElementWithMinusSevenIn_Array_ShouldReplaceArraysLastElement()
        {
            //Arrange
            int[] array = _container.MakeRandomArrayWithLength(10);
            //Act
            _container.ChangeLastElementWithMinusSevenIn(array);
            //Assert
            Assert.AreEqual(-7, array.Last());
        }

        [Test]
        public void ChangeLastElementWithMinusSevenIn_EmptyArray_SchouldThrowException()
        {
            //Arrange 
            int[] array = new List<int>().ToArray();
            //Assert
            Assert.Throws<NotValidArrayLengthException>(() => _container.ChangeLastElementWithMinusSevenIn(array));
        }

        [Test]
        public void GetArrays_ReturnArrays()
        {
            //Arrange
            _container.MakeRandomArrayWithLength(10);
            //Assert
            Assert.AreEqual(1, _container.GetArrays().Count());
        }

        [Test]
        public void IsValidLength_ValidLength_ReturnTrue()
        {
            //Assert
            int validLength = new Random().Next(1, 100);
            //Assert
            Assert.IsTrue(_container.IsValidLength(validLength));
        }

        [Test]
        public void IsValidLength_NotValidLength_ReturnFalse()
        {
            //Assert
            int validLength = new Random().Next(-100, 0);
            //Assert
            Assert.IsFalse(_container.IsValidLength(validLength));
        }
    }
}