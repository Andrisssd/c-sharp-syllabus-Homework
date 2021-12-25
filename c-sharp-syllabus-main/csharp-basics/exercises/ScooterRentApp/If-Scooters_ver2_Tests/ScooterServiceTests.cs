﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using If_Scooters_ver2;

namespace If_Scooters_ver2_Tests
{
    [TestClass]
    public class ScooterServiceTests
    {
        [TestMethod]
        public void AddScooter_OneScooter_OneScooterAdded()
        {
            //Arrange
            //Make new ScooterService object
            IScooterService scooterService = new ScooterService();
            //Act
            //Add one scooter to scooterService's scooterList
            scooterService.AddScooter("id", 0.05M);
            //Expect scooterList length equals 1
            int expectedScooterListLength = 1;
            var actualScooterListLength = scooterService.GetScooters().Count;
            //Assert
            //Compare expected scooterList length and actual
            Assert.AreEqual(expectedScooterListLength, actualScooterListLength);
        }

        [TestMethod]
        public void Scooter_WhenMakingTwoScootersWithOneId_ShouldThrowException()
        {
            //Arrange
            //Initialize new IScooterService object
            IScooterService scooterService = new ScooterService();
            //Act
            //Add one Scooter to ScooterService's scooterList
            scooterService.AddScooter("id", 0.05M);
            //Assert
            //Check if adding new Scooter with same id throws an Expection
            Assert.ThrowsException<AddScooterMethodException>(() => scooterService.AddScooter("id", 0.05M));
        }

        [TestMethod]
        public void GetScooterById_Id_ScooterWithThisId()
        {
            //Arrange
            //Make new ScooterService object
            IScooterService scooterService = new ScooterService();
            //Act
            //Add one scooter to ScooterService's scooterList
            scooterService.AddScooter("id1", 0.05M);
            //Get scooter by id
            Scooter actualScooter = scooterService.GetScooterById("id1");
            //Set expected scooter's id and actual scooter's id
            string expectedScootersId = "id1";
            string actualScootersId = actualScooter.Id;
            //Assert
            //Compare expected id and actual id
            Assert.AreEqual(expectedScootersId, actualScootersId);
        }

        [TestMethod]
        public void GetScooters_ScooterList()
        {
            //Arrange
            //Make new ScooterService object
            IScooterService scooterService = new ScooterService();
            //Act
            //Add one scooter to ScooterService's scooterList
            scooterService.AddScooter("id", 0.05M);
            //Set expected scooters'id and first scooterList's elements id
            var expectedScootersId = new Scooter("id", 0.05M).Id;
            var actualScootersId = scooterService.GetScooters()[0].Id;
            //Assert
            //Compare expected id and actual id
            Assert.AreEqual(expectedScootersId, actualScootersId);
        }

        [TestMethod]
        public void RemoveScooter_OneScooter_EmptryScooterList()
        {
            //Arrange
            //Make new ScooterList object
            IScooterService scooterService = new ScooterService();
            //Act
            //Add and remove one scooter
            scooterService.AddScooter("id", 0.05M);
            scooterService.RemoveScooter("id");
            //Set expected scooterList length and actual 
            int expectedScooterListLength = 0;
            int actualScooterListLength = scooterService.GetScooters().Count;
            //Assert
            //Compare scooterList length's
            Assert.AreEqual(expectedScooterListLength, actualScooterListLength);
        }

        [TestMethod]
        public void GetScooterById_FakeId_ShouldThrowScooterNotFoundException()
        {
            //Arrange
            IScooterService service = new ScooterService();
            //Assert
            Assert.ThrowsException<ScooterNotFoundException>(() => service.GetScooterById("Fake id"));
        }

        [TestMethod]
        public void RemoveScooter_FakeId_ShouldThrowScooterNotFoundException()
        {
            //Arrange
            IScooterService service = new ScooterService();
            //Assert
            Assert.ThrowsException<ScooterNotFoundException>(() => service.RemoveScooter("Fake id"));
        }
    }
}
