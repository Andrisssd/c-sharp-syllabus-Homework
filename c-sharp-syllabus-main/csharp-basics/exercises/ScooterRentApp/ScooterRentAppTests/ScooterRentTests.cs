using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ScooterRentApp;
using System;

namespace ScooterRentAppTests
{
    [TestClass]
    public class ScooterRentTests
    {
        [TestMethod]
        public void Get_Scooter_By_Id_0x003()
        {
            ScooterService a = new ScooterService();

            a.AddScooter("0x003", 0.05M);

            Scooter expected = new Scooter("0x003", 0.05M);

            Scooter actual = a.GetScooterById("0x003");

            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestMethod]
        public void Remove_One_Scooter()
        {
            ScooterService dictionary = new ScooterService();

            dictionary.AddScooter("0x003", 0.05M);
            dictionary.AddScooter("0x002", 0.05M);
            dictionary.RemoveScooter("0x002");

            int actualDictionaryLength = dictionary.GetScooters().Count;
            int expectedDictionaryLength = 1;

            Assert.AreEqual(expectedDictionaryLength, actualDictionaryLength);
        }

        [TestMethod]
        public void Count_Total_Rent_Time_For_8_Minutes()
        {
            Scooter scooter = new Scooter("0x003", 0.05M);
            DateTime startTime = new DateTime(2000, 01, 01, 23, 00, 00);
            scooter.StartRent(startTime);
            DateTime finalTime = new DateTime(2000, 01, 01, 23, 08, 00);

            double expectedMinutes = 8;
            double actual = scooter.CountTotalRentTime(finalTime).TotalMinutes;

            Assert.AreEqual(expectedMinutes, actual);
        }

        [TestMethod]
        public void Add_One_Scooter_To_Dictionary()
        {
            ScooterService service = new ScooterService();

            service.AddScooter("0x004", 0.5M);

            int expectedDictionaryLength = service._scooterDictionary.Count+1;
            int actualDictionaryLength = service._scooterDictionary.Count;

            Assert.IsTrue(actualDictionaryLength == expectedDictionaryLength);
        }

        [TestMethod]
        public void End_Rent_After_2_Days()
        {
            ScooterService service = new ScooterService();
            RentalCompany company = new RentalCompany();

            service.AddScooter("0x005", 0.05M);
            company.StartRent("0x005", service.GetScooters());

            DateTime currentPlus2 = DateTime.Now.AddDays(2);

            decimal expectedRentPrice = 40M;
            decimal actualRentPrice = company.EndRent("0x005", service.GetScooters(), currentPlus2);

            Assert.AreEqual(expectedRentPrice, actualRentPrice);
        }

        [TestMethod]
        public void Count_Total_Income_From_Two_Rented_Scooter_For_3_Days()
        {
            ScooterService service = new ScooterService();
            RentalCompany company = new RentalCompany();

            var scooters = service.GetScooters();

            service.AddScooter("0x003", 0.05M);
            service.AddScooter("0x004", 0.05M);
            company.StartRent("0x004", scooters);
            company.StartRent("0x003", scooters);
            var dateTimePlus3Days = DateTime.Now.AddDays(3);

            company.EndRent("0x003", scooters, dateTimePlus3Days);
            company.EndRent("0x004", scooters, dateTimePlus3Days);

            decimal expectedIncome = 120M;
            decimal actuelIncome = company.CalculateIncome(2021, true, service.GetScooters(), DateTime.Now);

            Assert.AreEqual(expectedIncome, actuelIncome);
        }

        [TestMethod]
        public void Count_Total_Income_For_One_Active_Scooter_For_4_Hours()
        {
            ScooterService service = new ScooterService();
            RentalCompany company = new RentalCompany();

            var scooters = service.GetScooters();

            service.AddScooter("0x003", 0.05M);   
            company.StartRent("0x003", scooters);
            company.EndRent("0x003", scooters, DateTime.Now.AddHours(4));

            decimal expectedIncome = 12M;
            decimal actuelIncome = company.CalculateIncome(2021, true, service.GetScooters(), DateTime.Now);

            Assert.AreEqual(expectedIncome, actuelIncome);
        }

        [TestMethod]
        public void Count_Total_Income_For_One_Active_Scooter_For_4_Hours_IncludeActiveScooters_False()
        {
            ScooterService service = new ScooterService();
            RentalCompany company = new RentalCompany();

            var scooters = service.GetScooters();

            service.AddScooter("0x003", 0.05M);
            company.StartRent("0x003", scooters);
            company.EndRent("0x003", scooters, DateTime.Now.AddHours(4));

            decimal expectedIncome = 12M;
            decimal actuelIncome = company.CalculateIncome(2021, false, service.GetScooters(),DateTime.Now);

            Assert.AreEqual(expectedIncome, actuelIncome);
        }

        [TestMethod]
        public void Count_Total_Income_For_One_Active_NonEnded_Scooter_For_4_Hours()
        {
            ScooterService service = new ScooterService();
            RentalCompany company = new RentalCompany();

            var scooters = service.GetScooters();
            service.AddScooter("0x003", 0.05M);
            company.StartRent("0x003", scooters);
            decimal expectedIncome = 12M;
            decimal actuelIncome = company.CalculateIncome(2021, true, service.GetScooters(), DateTime.Now.AddHours(4));

            Assert.AreEqual(expectedIncome, actuelIncome);
        }
    }
}
