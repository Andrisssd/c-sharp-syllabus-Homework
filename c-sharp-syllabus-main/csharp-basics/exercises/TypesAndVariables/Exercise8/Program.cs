using System;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of minutes: ");
            long numOfMins = long.Parse(Console.ReadLine());
            int days = (int)Math.Round(Convert.ToDecimal(numOfMins/60/24));
            int years =(int)Math.Round(Convert.ToDecimal(numOfMins/525600));
            Console.WriteLine($"Years:{years} || Days: {days%365}");
        }
    }
}
