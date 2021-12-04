using System;
using System.Collections.Generic;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            StartAsking(names);
        }

        public static void StartAsking(HashSet<string> names)
        {
            Console.Write("Enter name:");
            string input = Console.ReadLine();
            while(input != "")
            {
                names.Add(input);
                StartAsking(names);
            }

            Console.WriteLine($"Unique name list contains :{string.Join(' ',names)}");
            Environment.Exit(0);
        }
    }
}
