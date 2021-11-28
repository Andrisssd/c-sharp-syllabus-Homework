using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        /**
           * Origination:
           * Audi -> Germany
           * BMW -> Germany
           * Honda -> Japan
           * Mercedes -> Germany
           * VolksWagen -> Germany
           * Tesla -> USA
           */

        private static void Main(string[] args)
        {
            string[] array = { "Audi", "BMW", "Honda", "Mercedes", "VolksWagen", "Mercedes", "Tesla" };

            List<string> list = new List<string>(array);
            foreach (var brand in list)
            {
                Console.WriteLine(brand);
            }

            HashSet<string> hashSet = new HashSet<string>(array);
            foreach(var brand in hashSet)
            {
                Console.WriteLine(brand);
            }

            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                {array[0], "Germany" },
                {array[1], "Germany" },
                {array[2], "Japan" },
                {array[4], "Germany" },
                {array[5], "Germany" },
                {array[6], "USA" },
            };
            foreach(var pair in dictionary)
            {
                Console.WriteLine($"Brand: {pair.Key} is from {pair.Value}");
            }
        }
    }
}
