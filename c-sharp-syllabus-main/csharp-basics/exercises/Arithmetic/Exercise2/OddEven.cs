using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOddEven_Exercise2
{
    public class OddEven
    {
        public int AskNumber(string input)
        {
            int number;

            try
            {
                
                number = int.Parse(input);
            }
            catch
            {
                throw new InvalidNumberInputException(input);
            }

            return number;
        }

        public string NumbersStatus(int number)
        {
            return number%2 == 0 ? "Even" : "Odd";
        }

        public bool AskForExitStatus(string input)
        {
            return input.ToLower() != "y";
        }
    }
}
