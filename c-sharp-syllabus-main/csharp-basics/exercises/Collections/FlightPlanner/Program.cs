using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string Path = @"C:\Users\User\Desktop\homework\c-sharp-syllabus-Homework\c-sharp-syllabus-main\csharp-basics\exercises\Collections\FlightPlanner\Flights.txt";
            string[] flights = File.ReadAllLines(Path);
            Dictionary<string, string> flightDictionary = ConvertArrayToDictionary(flights);
            List<string> flightCities = new List<string>();

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("To display list of the cities press 1");
            Console.WriteLine("To exit program press #");
            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine(ReturnDestinations(flightDictionary));
            }


            Console.WriteLine("\nTo select a city from which you would like to start press 1");
            input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine(ReturnDepartures(flightDictionary));
            }


            Console.WriteLine("\nDeparture city: ");
            input = Console.ReadLine();

            if (flightDictionary.ContainsKey(input))
            {
                flightCities.Add(input);
            }

            Console.WriteLine("\nNext city to fly to:");
            Console.WriteLine("Choose from: " + flightDictionary[input]);

            var nextCity = Console.ReadLine();
            flightCities.Add(nextCity);

            do
            {
                Console.WriteLine("\nNext city to fly to:");
                Console.WriteLine("Choose from: " + flightDictionary[nextCity]);
                nextCity = Console.ReadLine();
                flightCities.Add(nextCity);
            } while (nextCity != input);

            Console.WriteLine("\nYou made a roundtrip:");
            foreach (var destination in flightCities)
            {
                Console.WriteLine(destination);
            }

            Console.ReadKey();
        }

        public static string ReturnDepartures(Dictionary<string, string> flightDictionary)
        {
            string departures = String.Empty;
            foreach (var element in flightDictionary)
            {
                departures += "Departure: " + element.Key+".\n";
            }

            return departures;
        }

        public static Dictionary<string, string> ConvertArrayToDictionary(string[] flights)
        {
            Dictionary<string, string> flightDictionary = new Dictionary<string, string>();

            foreach (var s in flights)
            {
                string[] flightArray = s.Replace(" -> ", "&").Split('&');
                for (int i = 0; i < flightArray.Length; i++)
                {
                    string elementTrim = flightArray[i].Trim();
                    flightArray[i] = elementTrim;
                }

                if (!flightDictionary.ContainsKey(flightArray[0]))
                {
                    flightDictionary.Add(flightArray[0], flightArray[1]);
                }
                else
                {
                    flightDictionary[flightArray[0]] += $",{flightArray[1]}";
                }
            }
            return flightDictionary;
        }

        public static string ReturnDestinations(Dictionary<string, string> flightDictionary)
        {
            string destinations = String.Empty;
            foreach (var element in flightDictionary)
            {
                destinations += "Departure: " + element.Key + ". Destination: " + element.Value+"\n";
            }

            return destinations;
        }
    }
}