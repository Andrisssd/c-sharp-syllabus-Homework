using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    abstract class Mammal : Animal
    {
        protected string _livingRegion;

        public Mammal(string type, string name, double weight, string region) : base(name, type, weight)
        {
            _livingRegion = region;
        }
    }
}
