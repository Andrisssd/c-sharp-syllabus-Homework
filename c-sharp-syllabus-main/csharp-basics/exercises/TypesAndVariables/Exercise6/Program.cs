using System;
using System.Linq;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter serie of single digit number");
            string number = Console.ReadLine();
            Console.WriteLine($"Sum = {GetSumOf(number)}");
        }

        public static int GetSumOf(string str)
        {
            int[] numArray = new int[str.Length];
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = Convert.ToInt32(str[i].ToString());
            }

            int sum = 0;
            for (int i = 0; i < numArray.Length; i++)
            {
                sum += numArray[i];
            }

            return sum;
        }
    }
}
