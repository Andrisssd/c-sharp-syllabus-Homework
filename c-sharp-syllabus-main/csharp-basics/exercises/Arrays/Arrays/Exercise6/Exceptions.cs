using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    [Serializable]
    public class NotValidArrayLengthException : Exception
    {
        public NotValidArrayLengthException() { }

        public NotValidArrayLengthException(int length) : base (String.Format("Not valid array length. Actual length : {0}", length))
        {

        }
    }

    [Serializable]
    public class NotValidLengthParameterException : Exception
    {
        public NotValidLengthParameterException() { }

        public NotValidLengthParameterException(int length) : base (String.Format("Not valid array length, {0} is less than minimum array size!",length))
        {

        }
    }
}
