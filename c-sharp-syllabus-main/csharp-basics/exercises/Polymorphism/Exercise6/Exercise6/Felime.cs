using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    abstract class Felime : Mammal
    {
        public Felime(string type, string name, double weight, string region) : base(name, type, weight, region)
        {
        }
    }
}
