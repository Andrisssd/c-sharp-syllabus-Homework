using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter something please: ");
            string str = Console.ReadLine();
            int sumOfUppercase = default;
            for (int i = 0; i <str.Length; i++)
            {
                if (Char.IsUpper(str[i])){
                    sumOfUppercase++;
                }
            }

            Console.WriteLine($"Sum of Uppercase letters: {sumOfUppercase}");
        }
    }
}
