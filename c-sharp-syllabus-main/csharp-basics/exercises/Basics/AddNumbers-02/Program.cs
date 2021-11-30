using System;

namespace AddNumbers_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(2, 7, 1));
            Console.ReadKey();
        }

        static int Sum(int a, int b, int c)
        {
            return a + b + c;    
        }
    }
}
