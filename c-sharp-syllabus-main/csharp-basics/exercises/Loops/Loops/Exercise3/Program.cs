using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] randomNums = new int[20];
            for(int i = 0; i < randomNums.Length; i++)
            {
                randomNums[i] = new Random().Next(0, 101);
            }

            Console.WriteLine("Write numbers position in array [from 0 to 19], any non-numeric input will cause poisition zero");
            int loggedPos;
            int.TryParse(Console.ReadLine(), out loggedPos);
            if(loggedPos<0 || loggedPos >19)
            {
                Console.WriteLine("Wrong input");
            }

            Console.WriteLine(randomNums[loggedPos]);
        }
    }
}
