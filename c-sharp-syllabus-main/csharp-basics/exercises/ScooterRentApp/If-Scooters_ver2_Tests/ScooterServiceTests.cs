using Microsoft.VisualStudio.TestTools.UnitTesting;
using If_Scooters_ver2;

namespace If_Scooters_ver2_Tests
{
    [TestClass]
    public class ScooterServiceTests
    {
        [TestMethod]
        public void AddScooter_OneScooter_OneScooterAdded()
        {
            //Make new ScooterService object
            IScooterService scooterService = new ScooterService();
            //Add one scooter to scooterService's scooterList
            scooterService.AddScooter("id", 0.05M);
            //Expect scooterList length equals 1
            int expectedScooterListLength = 1;
            var actualScooterListLength = scooterService.GetScooters().Count;
            //Compare expected scooterList length and actual
            Assert.AreEqual(expectedScooterListLength, actualScooterListLength);
        }

        [TestMethod]
        public void Scooter_WhenMakingTwoScootersWithOneId_ShouldThrowException()
        {
            //Initialize new IScooterService object
            IScooterService scooterService = new ScooterService();
            //Add one Scooter to ScooterService's scooterList
            scooterService.AddScooter("id", 0.05M);
            //Check if adding new Scooter with same id throws an Expection
            Assert.ThrowsException<System.Exception>(() => scooterService.AddScooter("id", 0.05M));
        }

        [TestMethod]
        public void GetScooterById_Id_ScooterWithThisId()
        {
            //Make new ScooterService object
            IScooterService scooterService = new ScooterService();
            //Add one scooter to ScooterService's scooterList
            scooterService.AddScooter("id1", 0.05M);
            //Get scooter by id
            Scooter actualScooter = scooterService.GetScooterById("id1");
            //Set expected scooter's id and actual scooter's id
            string expectedScootersId = "id1";
            string actualScootersId = actualScooter.Id;
            //Compare expected id and actual id
            Assert.AreEqual(expectedScootersId, actualScootersId);
        }

        [TestMethod]
        public void GetScooters_ScooterList()
        {
            //Make new ScooterService object
            IScooterService scooterService = new ScooterService();
            //Add one scooter to ScooterService's scooterList
            scooterService.AddScooter("id", 0.05M);
            //Set expected scooters'id and first scooterList's elements id
            var expectedScootersId = new Scooter("id", 0.05M).Id;
            var actualScootersId = scooterService.GetScooters()[0].Id;
            //Compare expected id and actual id
            Assert.AreEqual(expectedScootersId, actualScootersId);
        }

        [TestMethod]
        public void RemoveScooter_OneScooter_EmptryScooterList()
        {
            //Make new ScooterList object
            IScooterService scooterService = new ScooterService();
            //Add and remove one scooter
            scooterService.AddScooter("id", 0.05M);
            scooterService.RemoveScooter("id");
            //Set expected scooterList length and actual 
            int expectedScooterListLength = 0;
            int actualScooterListLength = scooterService.GetScooters().Count;
            //Compare scooterList length's
            Assert.AreEqual(expectedScooterListLength, actualScooterListLength);
        }
    }
}
