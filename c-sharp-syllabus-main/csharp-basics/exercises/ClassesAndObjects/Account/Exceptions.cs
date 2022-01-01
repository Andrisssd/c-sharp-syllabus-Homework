using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AccountNamespace
{
    [Serializable]
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException() : base(String.Format("Not enough money for this operation."))
        {

        }
    }
}
