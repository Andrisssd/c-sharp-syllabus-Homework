using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            int choice = GetMenu();
            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    CalculateCircleArea();
                    goto Start;
                    
                case 2:
                    Console.WriteLine();
                    CalculateRectangleArea();
                    goto Start;
                case 3:
                    Console.WriteLine();
                    CalculateTriangleArea();
                    goto Start;
                case 4:
                    Console.WriteLine();
                    Environment.Exit(0);
                    break;
                default:
                    goto Start;
            }

        }

        public static int GetMenu()
        {

            int userChoice;
            Console.WriteLine("Geometry Calculator\n");
            Console.WriteLine("1. Calculate the Area of a Circle");
            Console.WriteLine("2. Calculate the Area of a Rectangle");
            Console.WriteLine("3. Calculate the Area of a Triangle");
            Console.WriteLine("4. Quit\n");
            Console.WriteLine("Enter your choice (1-4) : ");
            var keyboard = Console.ReadKey();
            userChoice = Convert.ToInt32(keyboard.KeyChar.ToString());
            return userChoice;
        }

        public static void CalculateCircleArea()
        {
            Console.WriteLine("What is the circle's radius? ");
            decimal radius = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("The circle's area is "
                    + Geometry.AreaOfCircle(radius));
        }

        public static void CalculateRectangleArea()
        {
            decimal length = 0;
            decimal width = 0;
            Console.WriteLine("Enter length? ");
            length = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter width? ");
            width = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("The rectangle's area is "
                    + Geometry.AreaOfRectangle(length, width));
        }

        public static void CalculateTriangleArea()
        {
            decimal ground = 0;
            decimal height = 0;
            Console.WriteLine("Enter length of the triangle's base? ");
            ground  = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter triangle's height? ");
            height = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("The triangle's area is "
                    + Geometry.AreaOfTriangle(ground, height));
        }
    }
}
