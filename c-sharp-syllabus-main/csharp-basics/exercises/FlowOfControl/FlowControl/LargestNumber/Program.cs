using System;
using System.Collections.Generic;

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Input the 1st number: ");
            var input1 = Console.ReadLine();
            numbers.Add(int.Parse(input1));
            Console.WriteLine("Input the 2nd number: ");
            var input2 = Console.ReadLine();
            numbers.Add(int.Parse(input2));
            Console.WriteLine("Input the 3rd number: ");
            var input3 = Console.ReadLine();
            numbers.Add(int.Parse(input3));

            int[] arrayToSort = numbers.ToArray();
            Array.Sort(arrayToSort);
            Array.Reverse(arrayToSort);
            Console.WriteLine("Largest num: {0}",arrayToSort[0]);
        }
    }
}
