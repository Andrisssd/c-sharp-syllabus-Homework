using System;

namespace Output_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Concat("hello", "from", "Codelex");

            Console.WriteLine(result);
            Console.ReadKey();
        }

        static string Concat(string w1, string w2, string w3)
        {
            return $"{w1} {w2} {w3}";
        }
    }
}
