using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareFabric fabric = new CompareFabric(15);

            Console.WriteLine("Enter first number");
            int firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number");
            int secondNumber = Convert.ToInt32(Console.ReadLine());

            bool result = fabric.IsNumberValid(firstNumber, secondNumber);

            Console.WriteLine(result);
        }
    }
}
