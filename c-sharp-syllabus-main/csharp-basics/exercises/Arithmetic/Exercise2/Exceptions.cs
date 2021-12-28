using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOddEven_Exercise2
{
    [Serializable]
    public class InvalidNumberInputException : Exception
    {
        InvalidNumberInputException() { }

        public InvalidNumberInputException(string input) : base (String.Format("{0} is not a number!", input))
        {

        }
    }
}
