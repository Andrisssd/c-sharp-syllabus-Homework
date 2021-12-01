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
        
        private string[][] _array = File.ReadAllLines(_path).Select(x => x.Replace(" -> ", "-").Split('-').ToArray()).ToArray();
        private const string _path = @"C:\Users\User\Desktop\homework\c-sharp-syllabus-Homework\c-sharp-syllabus-main\csharp-basics\exercises\Collections\FlightPlanner\flights.txt";
        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(_path);
            List<string> root = new List<string>();



        }

        static void StartPlanner()
        {
            Console.WriteLine("What would you like to do:");
            Console.WriteLine("To display list of the cities press 1");
            Console.WriteLine("To exit program press #");

            
        }
    }
}