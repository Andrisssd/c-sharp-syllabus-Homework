using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    [Serializable]
    public class PutNumberNullParameterException : Exception
    {
        public PutNumberNullParameterException() : base(String.Format("PutNumber method doesn't take empty parameters"))
        {

        }
    }

    [Serializable]
    public class NameNotFoundException : Exception
    {
        public NameNotFoundException(string name) : base (String.Format("Name : {0} not found in dictionary!", name))
        {

        }
    }
}
