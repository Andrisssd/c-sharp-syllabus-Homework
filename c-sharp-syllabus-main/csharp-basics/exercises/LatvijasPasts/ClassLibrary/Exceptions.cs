using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CVNotFoundException : Exception
    {
        public CVNotFoundException(int id) : base (String.Format("CV with id {0} not found", id))
        {

        }
    }
}
