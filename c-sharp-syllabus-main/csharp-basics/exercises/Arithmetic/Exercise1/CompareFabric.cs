using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public class CompareFabric
    {
        private int _number;

        public CompareFabric(int numberToCopmapre)
        {
            _number = numberToCopmapre;
        }

        public bool IsSumValid(int a, int b)
        {
            return a + b == _number;
        }
        
        public bool DifferenceValid(int a, int b)
        {
            var numbers = new int[]{ a, b };
            return numbers.Max() - numbers.Min() == _number;
        }

        public bool IsAnyNumberTheOneWeNeed(int a, int b)
        {
            return a == _number || b == _number;
        }

        public bool IsNumberValid(int a, int b)
        {
            return IsSumValid(a, b) || DifferenceValid(a, b) || IsAnyNumberTheOneWeNeed(a, b);
        }
    }
}
