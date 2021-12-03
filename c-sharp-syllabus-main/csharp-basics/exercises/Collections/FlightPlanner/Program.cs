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
        private static string _firstCity = "  ";
        private static string _currentCity = " ";
        private static List<string> _fullPath;
       
        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(_path);
            _fullPath = new List<string>();
            string[][] array = File.ReadAllLines(_path).Select(x => x.Replace(" -> ", "-").Split('-')).ToArray();
            List<string> root = new List<string>();
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            StartPlanner(dictionary,array);
        }

        static void StartPlanner(Dictionary<int, string> dictionary, string[][] array)
        {
            dictionary = new Dictionary<int, string>();
            Program._currentCity = "  ";
            Program._firstCity = " ";
            Program._fullPath = new List<string>();
            Console.WriteLine("What would you like to do:");
            Console.WriteLine("To display list of the cities press 1");
            Console.WriteLine("To exit program press #");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    PrintAvailableCitiesFirst(dictionary, array);
                    break;
                case "#":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input, try again!");
                    StartPlanner(dictionary, array);
                    break;
            }  
                ChooseCity(dictionary, array);
        }

        static void PrintAvailableCitiesFirst(Dictionary<int, string> dictionary, string[][] array)
        {
            HashSet<string> cities = new HashSet<string>();
            foreach (var city in array)
            {
                cities.Add(city[0]);
            }

            string[] citiesWithNoDublicates = new string[cities.Count];
            cities.CopyTo(citiesWithNoDublicates);

            for(int i = 0; i < citiesWithNoDublicates.Length; i++)
            {
                dictionary.Add(i, citiesWithNoDublicates[i]);
            }

            foreach(var city in dictionary)
            {
                Console.WriteLine($"To choose {city.Value}, enter {city.Key}");
            }
        }

        static void ChooseCity(Dictionary<int, string> dictionary, string[][] array)
        {
                int choosedCity = int.Parse(Console.ReadLine());
                string city = dictionary[choosedCity];
                Program._firstCity = city;
                Console.WriteLine($"You have choosed {city}");
                Program._fullPath.Add(city);
                PrintNextAvialibleCity(city, array,dictionary);
        }

        static void PrintNextAvialibleCity(string city, string[][] array, Dictionary<int, string> dictionary)
        {
            string[][] nextCities = array.Where(x => x[0]==city).ToArray();
            Console.WriteLine("Available cities:");

            for (int i = 0; i < nextCities.Length; i++)
            {
                Console.WriteLine($"To go to {nextCities[i][1]} enter {i}");
            }

            int input = int.Parse(Console.ReadLine());
            Program._currentCity = nextCities[input][1];
            Console.WriteLine($"You have choosed {nextCities[input][1]}");
            Program._fullPath.Add(nextCities[input][1]);

            if (Program._firstCity!=Program._currentCity)
            {
                PrintNextAvialibleCity(nextCities[input][1], array, dictionary);
            }
            else
            {
                PrintFinalPath(dictionary, array);
            }

        }

        static void PrintFinalPath(Dictionary<int, string> dictionary,string[][] array)
        {
            Console.WriteLine("Welcome back home!");
            Console.WriteLine("Your full path:");
            foreach (var city in _fullPath)
            {
                Console.Write("|| "+city+" || ");
            }

            Console.WriteLine();
            AskPoint:
            Console.WriteLine("Wanna take another one trip? Y/n");
            string answer = Console.ReadLine();
            switch (answer.ToLower())
            {
                case "y":
                    Console.WriteLine("Nice!");
                    StartPlanner(dictionary, array);
                    break;
                case "n":
                    Console.WriteLine("Thanks for using our app! Bye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    goto AskPoint;      
            }
        }
    }
}