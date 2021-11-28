using System;

namespace AddNumbers_02
{
    class Program
    {
        //todo: fix the syntax
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(2, 7, 1)); // Expected 10
            Console.ReadKey();
        }

        static int Sum(int a, int b, int c)
        {
            return a + b + c;    
        }
    }
}
