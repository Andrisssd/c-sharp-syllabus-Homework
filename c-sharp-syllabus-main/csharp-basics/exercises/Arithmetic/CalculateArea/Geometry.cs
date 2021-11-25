using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea
{
    public class Geometry
    {
        public static double AreaOfCircle(decimal radius)
        {
            return (double)(Math.PI * Math.Pow((double)radius, 2));
        }

        public static double AreaOfRectangle(decimal length, decimal width)
        {
            return (double)(length * width);
        }

        public static double AreaOfTriangle(decimal ground, decimal h)
        {
            return (double)(h*ground/2);
        }
    }
}
