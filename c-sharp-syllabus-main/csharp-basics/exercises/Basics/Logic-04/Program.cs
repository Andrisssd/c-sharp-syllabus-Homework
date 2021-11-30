using System;

namespace Logic_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Multiply(1,3,4));
            Console.ReadKey();
        }

        static int Multiply(int a, int b, int c)
        {
            var z = a * b * c;
            return z;
        }
    }
}
