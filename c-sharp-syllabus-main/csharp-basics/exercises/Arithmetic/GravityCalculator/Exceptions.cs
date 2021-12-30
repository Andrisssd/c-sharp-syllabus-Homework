using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityCalculator_7
{
    public class InvalidInputTimeException : Exception
    {
        public InvalidInputTimeException() { }
        public InvalidInputTimeException(double input) : base (String.Format("Time can't be negative. {0} < 0",input))
        {

        }
    }
}
