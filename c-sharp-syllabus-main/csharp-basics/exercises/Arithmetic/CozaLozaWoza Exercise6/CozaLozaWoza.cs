using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaLozaWoza_Exercise6
{
    public class CozaLozaWoza
    {
        public string GetCozaLozaWozaOrNumber(int i)
        {
            if (i%11==1)
            {
                return $"\n{i} ";
            }
            if (i%15==0)
            {
                return "CozaLoza ";
            }
            else if (i%7==0)
            {
                return "Woza ";
            }
            else if (i%5==0)
            {
                return "Loza ";
            }
            else if (i%3==0)
            {
                return "Coza ";
            }

            return i+" ";
        }
    }
}
