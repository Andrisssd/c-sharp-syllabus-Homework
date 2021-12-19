using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class House : IValidatable
    {
        public string UniqueId { get; set; }

        public int Number { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZIPCode { get; set; }

        public bool IsValid()
        {
            return Number > 0;
        }
    }
}
