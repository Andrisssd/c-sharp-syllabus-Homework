using System;

namespace Logic_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Trim(" Codelex"));
            Console.ReadKey();
        }

        static string Trim(string codelex)
        {
            return codelex.Trim();
        }
    }
}
