using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    [Serializable]
    public class TypeNotExistException : Exception
    {
        public TypeNotExistException(string typeName) : base(String.Format("Type '{0}' doesn't exist.",typeName))
        {

        }
    }

    [Serializable]
    public class WrongFoodCountException : Exception
    {
        public WrongFoodCountException(string foodCount) : base(String.Format("'{0}' can't be parsed to integer.",foodCount))
        {

        }
    }

    [Serializable]
    public class StringToDoubleParseException : Exception
    {
        public StringToDoubleParseException(string doubleString) : base(String.Format("'{0}' can't be parsed to double", doubleString))
        {

        }
    }

    [Serializable]
    public class WrongFoodTypeException : Exception
    {
        public WrongFoodTypeException() : base(String.Format("This animal don't eat this food."))
        {

        }
    }

    [Serializable]
    public class StringToIntParseException : Exception
    {
        public StringToIntParseException(string intString) : base(String.Format("'{0}' can't be parsed to integer", intString))
        {

        }
    }
}
