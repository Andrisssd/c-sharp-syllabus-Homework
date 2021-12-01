using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class Program
    {
        private const string _path = @"C:\Users\User\Desktop\homework\c-sharp-syllabus-Homework\c-sharp-syllabus-main\csharp-basics\exercises\Collections\FlightPlanner\flights.txt";
        private static string[] _plannerPlan = File.ReadAllLines(_path);
        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(_path);
            var text = File.ReadAllText(_path);
            foreach (var s in readText)
            {
                Console.WriteLine(s);
            }
            InvokeFlyManager(text, readText);

            
        }

        static void InvokeFlyManager(string text, string[] textLines)
        {
            Console.WriteLine("What would you like to do:");
            Console.WriteLine("To display list of the cities press 1");
            Console.WriteLine("To exit program press #");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    PrintListOfTheCities(textLines);
                    break;
                case "#":
                default:
                    Console.WriteLine("Thanks for using our app!");
                    Environment.Exit(0);
                    break;
            }
        }

        static Dictionary<string,string> GetCityList()
        {
            HashSet<string> cityList = new HashSet<string>();
            foreach(var )
        }

        static void PrintAvialibleCities()
        {
            int indexNeeded = 0;
            foreach(var city in GetCityList())
            {
                Console.WriteLine(city.Key+$": {indexNeeded}");
                indexNeeded++;
            }
        }

        static void AskStartCity()
        {
            Console.Write("Enter number of city you are starting from: ");
        }

        static void ManageCities(string[] textLines)
        {
            Console.WriteLine("To select a city from which you would like to start press 1");
            Console.WriteLine("To exit program press #");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    PrintAvialibleCities();
                    break;
                case "#":
                    Console.WriteLine("Thanks for using our app!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    ManageCities(textLines);
                    break;
            }
        }

        static void PrintListOfTheCities(string[] textLines)
        {
            Console.WriteLine("==================================");
            foreach(var flight in textLines)
            {
                Console.WriteLine(flight);
            }

            Console.WriteLine("==================================");
            ManageCities(textLines);
        }
    }
}
