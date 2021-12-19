using Microsoft.VisualStudio.TestTools.UnitTesting;
using If_Scooters_ver2;

namespace If_Scooters_ver2_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Scooter_WhenRentPricePerMinuteIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Set pricePerMinute to zero
            decimal pricePerMinute = 0;
            //Give pricePerMinute to new Scooter's constructor and check for Exception
            Assert.ThrowsException<InvalidPriceException>(() => new Scooter("id", pricePerMinute));
        }

        [TestMethod]
        public void GetInvokeStartRentTime_DontInvokeStartRent_ShouldThrowException()
        {
            //Initialize new Scooter
            Scooter scooter = new Scooter("id", 0.05M);
            //Check if GetInvokeStartRentTime throws an Exception 
            Assert.ThrowsException<InvokeStartRentTimeException>(() => scooter.GetInvokeStartRentTime());
        }

        [TestMethod]
        public void ScooterConstructor_MakeOneScooter_ScootersIdAndPricePerMinute()
        {
            //Make one scooter
            Scooter scooter = new Scooter("id", 0.05M);
            //Expected should be string representing scooter's id and price separated by space
            string exptected = "id 0.05";
            string actual = $"{scooter.Id} {scooter.PricePerMinute}";
            //Check if expected variable is equal to actual 
            Assert.AreEqual(exptected, actual);
        }

        [TestMethod]
        public void IncrementScootersNumberOfRides_ShouldIncrementNumberOfRides()
        {
            //Make one scooter
            Scooter scooter = new Scooter("id", 0.05M);
            //Get numberOfRidesBefore
            int numberOfRidesBefore = scooter.GetNumberOfRides();
            //Set IsRented = true and increment Scooters number of rides
            scooter.IsRented = true;
            scooter.IncrementScootersNumberOfRides();
            //Get numberOfRidesAfter
            int numberOfRidesAfter = scooter.GetNumberOfRides();
            //Compare number of rides before and after
            Assert.IsTrue(numberOfRidesAfter > numberOfRidesBefore);
        }

        [TestMethod]
        public void GetNumberOfRides_ReturnNumberOfRides()
        {
            //Make IScooterService and IRentalCompany objects
            IScooterService service = new ScooterService();
            IRentalCompany company = new RentalCompany("Company", service);
            //Add one scooter to serviceScooterList and StartRent for this scooter
            service.AddScooter("id", 0.05M);
            company.StartRent("id");
            //Set expected and get actual number of rides
            int expectedNumberOfRides = 1;
            int actualNumberOfRides = service.GetScooterById("id").GetNumberOfRides();
            //Compare number of rides 
            Assert.AreEqual(expectedNumberOfRides, actualNumberOfRides);
        }
    }
}
