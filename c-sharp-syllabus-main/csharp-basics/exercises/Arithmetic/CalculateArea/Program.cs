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
            // Get the user's menu choice.
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
            

            // Display the menu.
            Console.WriteLine("Geometry Calculator\n");
            Console.WriteLine("1. Calculate the Area of a Circle");
            Console.WriteLine("2. Calculate the Area of a Rectangle");
            Console.WriteLine("3. Calculate the Area of a Triangle");
            Console.WriteLine("4. Quit\n");
            Console.WriteLine("Enter your choice (1-4) : ");
            var keyboard = Console.ReadKey();
            // get input from user

            userChoice = Convert.ToInt32(keyboard.KeyChar.ToString());
            // validate input

            return userChoice;
        }

        public static void CalculateCircleArea()
        {
            // Get input from user
            Console.WriteLine("What is the circle's radius? ");
            //todo
            decimal radius = Convert.ToDecimal(Console.ReadLine());

            // Display output
            Console.WriteLine("The circle's area is "
                    + Geometry.AreaOfCircle(radius));
        }

        public static void CalculateRectangleArea()
        {
            decimal length = 0;
            decimal width = 0;

            // Get input from user

            // Get length
            Console.WriteLine("Enter length? ");
            //todo
            length = Convert.ToDecimal(Console.ReadLine());
            // Get width
            Console.WriteLine("Enter width? ");
            //todo
            width = Convert.ToDecimal(Console.ReadLine());
            // Display output
            Console.WriteLine("The rectangle's area is "
                    + Geometry.AreaOfRectangle(length, width));
        }

        public static void CalculateTriangleArea()
        {
            decimal ground = 0;
            decimal height = 0;

            // Get input from user

            // Get the base
            Console.WriteLine("Enter length of the triangle's base? ");
            //todo
            //read key value
            ground  = Convert.ToDecimal(Console.ReadLine());
            // Get the height
            Console.WriteLine("Enter triangle's height? ");
            //todo
            //read key value
            height = Convert.ToDecimal(Console.ReadLine());
            // Display the triangle's area.
            Console.WriteLine("The triangle's area is "
                    + Geometry.AreaOfTriangle(ground, height));
        }
    }
}
