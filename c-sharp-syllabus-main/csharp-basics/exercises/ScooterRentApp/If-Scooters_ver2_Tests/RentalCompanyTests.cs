using Microsoft.VisualStudio.TestTools.UnitTesting;
using If_Scooters_ver2;
using System;

namespace If_Scooters_ver2_Tests
{
    [TestClass]
    public class RentalCompanyTests
    {
        [TestMethod]
        public void StartRent_InitializedNonRentedScootersId_ShouldSetScootersIsRentedToTrue()
        {
            //Arrange
            // Make IScooterService and IRentalCompany objects
            IScooterService scooterService = new ScooterService();
            IRentalCompany rentalCompany = new RentalCompany("CompanyName", scooterService);
            //Act
            //Add scooter and start rent for this scooter
            scooterService.AddScooter("id", 0.05M);
            rentalCompany.StartRent("id");
            //Assert
            //Check if rented scooter IsRented bool is true
            Assert.IsTrue(scooterService.GetScooterById("id").IsRented);
        }

        [TestMethod]
        public void CalculateIncome_YearAndFalse_Return20M()
        {
            //Arrange
            //Make service, dataBase and company objects
            IScooterService service = new ScooterService();
            DataBase dataBase = new DataBase();
            IRentalCompany company = new RentalCompany("company", service, dataBase);
            //Act
            //Set rentStart and rentEnd DateTimes
            DateTime rentStart = new DateTime(2021, 10, 10, 00, 00, 00);
            DateTime rentEnd = new DateTime(2021, 10, 12, 00, 00, 00);
            //Put DateTimes to dataBase 
            dataBase.SetDictionaryData("id", "2", 2021, 0.05M, rentStart, rentEnd);
            //Set expected TotalIncome and get actual TotalIncome for one scooter rented for 2 days 
            decimal expected = 40M;
            decimal actual = company.CalculateIncome(2021, true);
            //Assert
            //Compare expected and actual incomes
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateIncome_YearAndTrue_Return66()
        {
            //Arrange
            //Make service, dataBase and company objects
            IScooterService service = new ScooterService();
            DataBase dataBase = new DataBase();
            IRentalCompany company = new RentalCompany("company", service, dataBase);
            //Act
            //Set rentStart and rentEnd DateTimes
            DateTime rentStart = new DateTime(2021, 10, 10, 23, 00, 00);
            DateTime rentEnd = new DateTime(2021, 10, 14, 1, 00, 00);
            //Put DateTimes to dataBase 
            dataBase.SetDictionaryData("id", "2", 2021, 0.05M, rentStart, rentEnd);
            //Set expected TotalIncome and get actual TotalIncome for one scooter rented for 3 days and 2 hours
            decimal expected = 66M;
            decimal actual = company.CalculateIncome(2021, true);
            //Assert
            //Compare expected and actual incomes
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateIncome_YearAndTrue_Return0()
        {
            //Arrange
            //Make service, dataBase and company objects
            IScooterService service = new ScooterService();
            DataBase dataBase = new DataBase();
            IRentalCompany company = new RentalCompany("company", service, dataBase);
            //Act
            //Set rentStart and rentEnd DateTimes
            DateTime rentStart = new DateTime(2021, 10, 10, 23, 00, 00);
            DateTime rentEnd = new DateTime(2021, 10, 14, 1, 00, 00);
            //Put DateTimes to dataBase 
            dataBase.SetDictionaryData("id", "2", 2021, 0.05M, rentStart, rentEnd);
            //Set expected Income and actual income, but set CalculateIncome's year to year with no rides in database
            decimal expected = 0M;
            decimal actual = company.CalculateIncome(2020, true);
            //Assert
            //Compare expected and actual incomes
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndRent_OneScooterRentedFor6Hours_Return18()
        {
            //Arrange
            //Make service, dataBase and company objects
            IScooterService service = new ScooterService();
            DataBase dataBase = new DataBase();
            IRentalCompany company = new RentalCompany("company", service, dataBase);
            //Act
            //Set rentStart to DateTime.Now - 6 hours
            DateTime rentStart = DateTime.Now - new TimeSpan(06, 00, 00);
            //Add one scooter to dataBase and set rentStart to this scooter to imitate 6 hours long ride
            service.AddScooter("id", 0.05M);
            service.GetScooterById("id").SetInvokeStartRentTime(rentStart);
            dataBase.SetDictionaryData("id", "2", 2021, 0.05M, rentStart, null);
            //Set expected EndRent return value and actual return value
            decimal expected = 18M;
            decimal actual = company.EndRent("id");
            //Assert
            //Compare expected and actual returned values
            Assert.AreEqual(expected, actual);
        }
    }
}
