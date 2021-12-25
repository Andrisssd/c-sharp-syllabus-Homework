using Microsoft.VisualStudio.TestTools.UnitTesting;
using If_Scooters_ver2;

namespace If_Scooters_ver2_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Scooter_WhenRentPricePerMinuteIsLessThanZero_ShouldThrowInvalidPriceException()
        {
            //Set pricePerMinute to zero
            decimal pricePerMinute = 0;
            //Assert
            //Give pricePerMinute to new Scooter's constructor and check for Exception
            Assert.ThrowsException<InvalidPriceException>(() => new Scooter("id", pricePerMinute));
        }

        [TestMethod]
        public void GetInvokeStartRentTime_DontInvokeStartRent_ShouldThrowInvokeStartRentTimeException()
        {
            //Arrange
            //Initialize new Scooter
            Scooter scooter = new Scooter("id", 0.05M);
            //Assert
            //Check if GetInvokeStartRentTime throws an Exception 
            Assert.ThrowsException<InvokeStartRentTimeException>(() => scooter.GetInvokeStartRentTime());
        }

        [TestMethod]
        public void ScooterConstructor_MakeOneScooter_ScootersIdAndPricePerMinute()
        {
            //Arrange
            //Make one scooter
            Scooter scooter = new Scooter("id", 0.05M);
            //Act
            //Expected should be string representing scooter's id and price separated by space
            string exptected = "id 0.05";
            string actual = $"{scooter.Id} {scooter.PricePerMinute}";
            //Assert
            //Check if expected variable is equal to actual 
            Assert.AreEqual(exptected, actual);
        }
    }
}
