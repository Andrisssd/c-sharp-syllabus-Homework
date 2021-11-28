using System;
using System.Linq;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            CheckNum(number);
        }

        static void CheckNum(int number)
        {
            int lastResult = number;
            while (lastResult > 9)
            {
                int[] array = lastResult.ToString().Select(el => el - '0').ToArray();
                int sum = 0;
                foreach(var num in array)
                {
                    sum += num*num;
                }

                lastResult = sum;
            }

            if(lastResult == 1)
            {
                Console.WriteLine($"Number {number} is happy");
            }
            else
            {
                Console.WriteLine($"Number {number} isn't happy :(");
            }
        }
    }
}
