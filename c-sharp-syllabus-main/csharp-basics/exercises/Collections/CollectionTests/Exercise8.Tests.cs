using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WordCount;
using System.IO;
using System.Collections.Generic;
using Phonebook;
using System.Linq;

namespace CollectionTests
{
    [TestClass]
    public class Exercise8
    {
        private PhoneDirectory _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new PhoneDirectory();
        }

        [TestMethod]
        public void NameExists_ValidName_ReturnTrue()
        {
            //Arrange
            _service.PutNumber("name", "number");
            //Act
            bool actualResult = _service.NameExists("name");
            //Assert
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void GetDataDictionary_ReturnDictionaryWithZeroLength()
        {
            //Arrange
            int expectedLength = 0;
            //Act
            int actualLength = _service.GetDataDictionary().Count();
            //Assert
            Assert.AreEqual(expectedLength, actualLength);
        }

        [TestMethod]
        public void PutNumber_ValidData_ShouldIncrementDataDictionaryLength()
        {
            //Arrange
            int expectedLength = 1;
            //Act
            _service.PutNumber("name", "number");
            int actualLength = _service.GetDataDictionary().Count();
            //Assert
            Assert.AreEqual(expectedLength, actualLength);
        }

        [TestMethod]
        public void PutNumber_InvalidData_ShouldThrowException()
        {
            //Arrange
            string invalidData = String.Empty;
            //Assert
            Assert.ThrowsException<PutNumberNullParameterException>(() => _service.PutNumber(invalidData, invalidData));
        }

        [TestMethod]
        public void GetNumber_ValidName_ReturnNumber()
        {
            //Arrange
            string name = "me";
            string expectedNumber = "number";
            _service.PutNumber(name, expectedNumber);
            //Act
            string actualNumber = _service.GetNumber(name);
            //Assert
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void GetNumber_InvalidName_ShouldThrowException()
        {
            //Arrange
            string invalidName = "someOne";
            //Assert
            Assert.ThrowsException<NameNotFoundException>(() => _service.GetNumber(invalidName));
        }
    }
}
