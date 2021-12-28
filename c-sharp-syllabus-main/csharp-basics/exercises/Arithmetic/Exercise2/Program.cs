using System;
using System.Threading.Tasks;
using CheckOddEven_Exercise2;

namespace Exercise2
{
    class Program
    {       
        static void Main(string[] args)
        {
            OddEven program = new OddEven();

            bool exitStatus = true;

            while (exitStatus)
            {
                Console.Write("Enter number: ");

                Console.WriteLine(program.NumbersStatus(program.AskNumber(Console.ReadLine())));

                Console.WriteLine("Exit? Y/n");

                exitStatus = program.AskForExitStatus(Console.ReadLine());
            }

            Console.WriteLine("Bye!");
        }
    }
}
