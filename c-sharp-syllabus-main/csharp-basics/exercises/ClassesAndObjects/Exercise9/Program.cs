using System;
using System.Drawing;

namespace Exercise9
{
    class Program
    {
        public static void SwapPoints(ref Point firstPoint,ref Point secondPoint)
        {
            int bufferX, bufferY;
            bufferX = firstPoint.X;
            bufferY = firstPoint.Y;
            firstPoint.X = secondPoint.X;
            firstPoint.Y = secondPoint.Y;
            secondPoint.X = bufferX;
            secondPoint.Y = bufferY;
        }
        static void Main(string[] args)
        {
            Point point1 = new Point(3, 4);
            Point point2 = new Point(-3, 6);
            SwapPoints(ref point1,ref point2);
            Console.WriteLine($"({point1.X},{point1.Y})");
            Console.WriteLine($"({point2.X},{point2.Y})");
        }
    }
}
