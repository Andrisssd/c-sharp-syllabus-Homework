using System;

namespace Exceptions
{
    [Serializable]
    public class PriceIsLowerThanZeroException : Exception
    {
        public PriceIsLowerThanZeroException(double price) : base (String.Format("Price can't be less than zero. {0} < 0!",price))
        {

        }
    }

    [Serializable]
    public class AmountIsLowerThanZeroException : Exception
    {
        public AmountIsLowerThanZeroException(int amount) : base(String.Format("Amount can't be less than zero. {0} < 0!", amount))
        {

        }
    }
}
