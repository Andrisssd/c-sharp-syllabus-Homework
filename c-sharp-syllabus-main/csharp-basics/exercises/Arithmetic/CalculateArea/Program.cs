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
            Geometry geometry = new Geometry();
            bool exitStatus = true;

            while (exitStatus)
            {
                Console.WriteLine("Calculate the Area of a Circle");
                Console.WriteLine("Calculate the Area of a Rectangle");
                Console.WriteLine("Calculate the Area of a Triangle");
                Console.WriteLine("Quit");
                Console.Write("Enter your choice (1-4): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter circle radius: ");
                        decimal radius;
                        decimal.TryParse(Console.ReadLine(), out radius);
                        Console.WriteLine($"Area of circle with radius {radius} = {geometry.AreaOfCircle(radius)}");
                        continue;
                    case "2":
                        Console.WriteLine("Enter rectangle length: ");
                        decimal length;
                        decimal.TryParse(Console.ReadLine(), out length);
                        Console.WriteLine("Enter rectange width: ");
                        decimal width;
                        decimal.TryParse(Console.ReadLine(), out width);
                        Console.WriteLine($"Area of rectangle with length {length} and width {width} = {geometry.AreaOfRectangle(length, width)}");
                        continue;
                    case "3":
                        Console.WriteLine("Enter ground of triangle: ");
                        decimal ground;
                        decimal.TryParse(Console.ReadLine(), out ground);
                        Console.WriteLine("Enter height of triangle: ");
                        decimal height;
                        decimal.TryParse(Console.ReadLine(), out height);
                        Console.WriteLine($"Area of triangle with ground {ground} and height {height} = {geometry.AreaOfTriangle(ground, height)}");
                        continue;
                    case "4":
                        exitStatus = false;
                        break;
                    default:
                        continue;
                }

                Console.WriteLine("Thanks for using our app!");
            }
        }
    }
}
