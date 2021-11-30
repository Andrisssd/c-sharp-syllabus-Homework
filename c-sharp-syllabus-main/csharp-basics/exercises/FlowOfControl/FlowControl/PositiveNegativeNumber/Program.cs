using System;

namespace PositiveNegativeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Enter the number.");
            var input = Console.ReadKey();
            try
            {
                number = int.Parse(input.KeyChar.ToString());
            }
            catch (System.FormatException)
            {

                throw new System.FormatException("Wrong input");
            }
            
            Console.WriteLine();
            if(number > 0)
            {
                Console.WriteLine("Number is positive");
            }
            else if(number == 0)
            {
                Console.WriteLine("Number is zero");
            }
            else if(number < 0)
            {
                Console.WriteLine("Number is negative");
            }
        }
    }
}
