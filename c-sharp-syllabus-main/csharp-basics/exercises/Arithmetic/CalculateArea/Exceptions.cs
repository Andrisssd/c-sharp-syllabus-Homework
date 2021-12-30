using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException() { }

        public InvalidParameterException(decimal parameter) : base (String.Format("{0} is lower than zero!",parameter))
        {

        }
    }
}
