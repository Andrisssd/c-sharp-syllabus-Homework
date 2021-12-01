using System;

namespace Exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDayInWord(6);
        }

        public static void PrintDayInWord(int day)
        {
            if(day < 7 && day >=0)
            {
                switch (day)
                {
                    case 0:
                        Console.WriteLine("Monday");
                        break;
                    case 1:
                        Console.WriteLine("Tuesday");
                        break;
                    case 2:
                        Console.WriteLine("Wednesday");
                        break;
                    case 3:
                        Console.WriteLine("Thursday");
                        break;
                    case 4:
                        Console.WriteLine("Friday");
                        break;
                    case 5:
                        Console.WriteLine("Saturday");
                        break;
                    case 6:
                        Console.WriteLine("Sunday");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Not a valid day");
            }
        }
    }
}
