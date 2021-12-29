using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WordCount;
using System.IO;

namespace CollectionTests
{
    [TestClass]
    public class Exercise5_Tests
    {
        private TextFileInfo _textAnalizator;
        private string _textPath;

        [TestInitialize]
        public void Setup()
        {
            _textAnalizator = new TextFileInfo();
            _textPath = @"C:\Users\User\Desktop\homework\c-sharp-syllabus-Homework\c-sharp-syllabus-main\csharp-basics\exercises\Collections\CollectionTests\Texts\Text1.txt";
        }

        [TestMethod]
        public void SetTextPath_Path_ShouldSetTextPath()
        {
            //Act
            _textAnalizator.SetTextPath(_textPath);
            string expectedResult = _textPath;
            string actualResult = _textAnalizator.GetFullPath();
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SetTextPath_NotExistingPath_ShouldThrowException()
        {
            //Arrange
            string fakeTextPath = "something";
            //Assert
            Assert.ThrowsException<PathNotFoundException>(() => _textAnalizator.SetTextPath(fakeTextPath));
        }

        [TestMethod]
        public void GetNumOfChars_Path_Return248()
        {
            //Arrange
            _textAnalizator.SetTextPath(_textPath);
            int expectedNumOfChars = 248;
            //Act
            int actualNumOfChars = _textAnalizator.GetNumOfChars();
            //Assert
            Assert.AreEqual(expectedNumOfChars, actualNumOfChars);
        }

        [TestMethod]
        public void GetNumOfChars_NotExistingPath_ShouldThrowException()
        {
            //Assert
            Assert.ThrowsException<FileNotFoundException>(() => _textAnalizator.GetNumOfChars());
        }

        [TestMethod]
        public void GetNumOfLines_Path_Return6()
        {
            //Arrange
            _textAnalizator.SetTextPath(_textPath);
            int expectedNumOfLines = 6;
            //Act
            int actualNumOfLines = _textAnalizator.GetNumOfLines();
            //Assert
            Assert.AreEqual(expectedNumOfLines, actualNumOfLines);
        }

        [TestMethod]
        public void GetNumOfLines_NotExistingPath_ShouldThrowException()
        {
            //Assert
            Assert.ThrowsException<FileNotFoundException>(() => _textAnalizator.GetNumOfLines());
        }

        [TestMethod]
        public void GetNumOfWords_Path_Return47()
        {
            //Arrange
            _textAnalizator.SetTextPath(_textPath);
            int expectedNumOfWords = 47;
            //Act
            int actualNumOfWords = _textAnalizator.GetNumOfWords();
            //Assert
            Assert.AreEqual(expectedNumOfWords, actualNumOfWords);
        }

        [TestMethod]
        public void GetNumOfWords_NotExistingPath_ShouldThrowException()
        {
            //Assert
            Assert.ThrowsException<FileNotFoundException>(() => _textAnalizator.GetNumOfWords());
        }

        [TestMethod]
        public void FileValid_ValidPath_ReturnTrue()
        {
            //Assert
            Assert.IsTrue(_textAnalizator.FileValid(_textPath));
        }

        [TestMethod]
        public void FileValid_InvalidPath_ReturnFalse()
        {
            //Arrange
            string fakePath = "something";
            //Assert
            Assert.IsFalse(_textAnalizator.FileValid(fakePath));
        }
    }
}
