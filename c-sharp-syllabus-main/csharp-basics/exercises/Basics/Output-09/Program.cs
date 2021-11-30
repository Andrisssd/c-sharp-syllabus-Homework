using System;

namespace Output_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Concat("Hello ","World!"));
            Console.ReadKey();
        }

        static string Concat(string w1, string w2)
        {
            return string.Concat(w1, w2);
        }
    }
}
