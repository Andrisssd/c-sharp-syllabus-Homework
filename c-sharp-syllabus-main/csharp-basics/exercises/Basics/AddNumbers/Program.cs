using System;

namespace AddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddNumbers(5, 5, 8));
            Console.ReadKey();
        }

        static int AddNumbers(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
