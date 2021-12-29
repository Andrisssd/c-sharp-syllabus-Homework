using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea
{
    public class Geometry
    {
        public double AreaOfCircle(decimal radius)
        {
            if (radius >= 0)
            {
                return (double)(Math.PI * Math.Pow((double)radius, 2));
            }

            throw new InvalidParameterException(radius);
        }

        public double AreaOfRectangle(decimal length, decimal width)
        {
            if (length >= 0 && width >= 0)
            {
                return (double)(length * width);
            }

            decimal[] parameters = { length, width };

            throw new InvalidParameterException(parameters.Min());
        }

        public double AreaOfTriangle(decimal ground, decimal h)
        {
            if (ground >= 0 && h >=0)
            {
                return (double)(h*ground/2);
            }

            decimal[] parameters = { ground, h };

            throw new InvalidParameterException(parameters.Min());
        }
    }
}
