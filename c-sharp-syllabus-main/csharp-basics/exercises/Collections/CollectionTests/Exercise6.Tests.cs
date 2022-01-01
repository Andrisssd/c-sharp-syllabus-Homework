using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightPlanner;

namespace CollectionTests
{
    [TestClass]
    public class Exercise6_Tests
    {
        [TestMethod]
        public void ConvertArrayToDictionary_3Flights_2Departures3DestinationsExpected()
        {
            //Arrange
            string[] flights = { "Manhattan -> Jurmala", "Barcelona -> Riga", "Barcelona -> Minsk" };
            //Act
            var expected = new Dictionary<string, string>()
            {
                {"Barcelona", "Riga,Minsk"},
                {"Manhattan", "Jurmala"}
            };
            var actual = Program.ConvertArrayToDictionary(flights);
            //Assert
            Assert.IsTrue(actual.All(e => expected.Contains(e)));
        }

        [TestMethod]
        public void ReturnDepartures_RigaLiepajaDepartures_RigaLiepajaDeparturesExpected()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>()
            {
                {"Madrid", "Slavenogorsk,Budapest"},
                {"Slavenogorsk", "Jurmala"}
            };
            //Act
            var expected = "Departure: Madrid.\n" +
                           "Departure: Slavenogorsk.\n";
            var actual = Program.ReturnDepartures(dictionary);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnDestination_3Flights_2Departures3DestinationsExpected()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>()
            {
                {"Madrid", "Slavenogorsk,Budapest"},
                {"Slavenogorsk", "Jurmala"}
            };
            //Act
            var expected = "Departure: Madrid. Destination: Slavenogorsk,Budapest\n" +
                           "Departure: Slavenogorsk. Destination: Jurmala\n";
            var actual = Program.ReturnDestinations(dictionary);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
