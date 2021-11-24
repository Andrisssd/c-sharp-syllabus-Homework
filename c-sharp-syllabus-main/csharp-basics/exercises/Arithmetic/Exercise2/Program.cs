using System;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
        Start:
            Console.Write("Enter number:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{ReturnNumOddEven(number)} number!");
            QuitPoint:
            Console.WriteLine("Quit? Y/n");
            string quitChoice = Console.ReadLine().ToLower();

            if (quitChoice=="y" || quitChoice=="n")
            {
                switch (quitChoice)
                {
                    case "y":
                        Console.WriteLine("bye!");
                        Environment.Exit(0);
                        break;
                    case "n":
                        goto Start;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong input");
                goto QuitPoint;
            }
            
        }
        public static string ReturnNumOddEven(int number)
        {
            if (number%2==0)
            {
                return "Even";
            }
            return "Odd";
        }
    }
}
