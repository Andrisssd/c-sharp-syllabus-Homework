using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Max value? ");
            int maxValue;
            int.TryParse(Console.ReadLine(), out maxValue);
            string baseStr = "";
            for(int i = 0; i < maxValue; i++)
            {
                if (i%15==0)
                {
                    baseStr += "FizzBuzz ";
                }
                else if(i%5==0)
                {
                    baseStr += "Buzz ";
                }
                else if (i%3==0)
                {
                    baseStr += "Fizz ";
                }
                else
                {
                    baseStr += i + " ";
                }

                if (i%20==0)
                {
                    baseStr += "\n";
                }
            }
            Console.WriteLine(baseStr);
        }
    }
}
