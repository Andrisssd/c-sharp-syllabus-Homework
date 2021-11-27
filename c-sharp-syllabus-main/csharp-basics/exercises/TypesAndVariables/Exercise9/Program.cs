using System;

namespace Exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter distance in meters: ");
            int distance = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter hours: ");
            int hours = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter minutes: ");
            int minutes = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter seconds: ");
            int seconds = Convert.ToInt32(Console.ReadLine());

            int totalTimeSeconds = seconds + minutes*60 + hours*60*60;
            decimal metersPerSecond = (decimal)distance / (decimal)totalTimeSeconds;
            decimal kmPerHour = (decimal)(distance/1000) / (decimal)(totalTimeSeconds/60/60);
            decimal milesPerHour = (decimal)(distance/1609) / (decimal)(totalTimeSeconds/60/60);

            Console.WriteLine("Your speed in meters/second is {0}",metersPerSecond);
            Console.WriteLine("Your speed in km/h is {0}",kmPerHour);
            Console.WriteLine("Your speed in miles/h is {0}",milesPerHour);
        }
    }
}
