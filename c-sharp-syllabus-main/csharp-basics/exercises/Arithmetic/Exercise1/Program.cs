using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int secondNumber = Convert.ToInt32(Console.ReadLine());

            bool result = (firstNumber-secondNumber == 15 
                || secondNumber - firstNumber == 15 
                || firstNumber == 15 
                || secondNumber == 15 
                || firstNumber + secondNumber == 15);

            Console.WriteLine(result);
        }
    }
}
