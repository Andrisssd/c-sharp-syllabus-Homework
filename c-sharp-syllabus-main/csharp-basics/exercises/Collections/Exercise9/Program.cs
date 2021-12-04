using System;
using System.Collections.Generic;

namespace Exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> collection = new HashSet<string>();

            for(int i = 0; i < 5; i++)
            {
                collection.Add(i.ToString());
            } 

            foreach(var item in collection)
            {
                Console.WriteLine(item);
            }

            collection.Clear();
            collection.Add("a");
            collection.Add("a");
            foreach(var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
