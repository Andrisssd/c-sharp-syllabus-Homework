using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 1;
            for (int i = 1; i<=10; i++)
            {
                sum*=i;
            }
            Console.WriteLine(sum);
        }
    }
}
