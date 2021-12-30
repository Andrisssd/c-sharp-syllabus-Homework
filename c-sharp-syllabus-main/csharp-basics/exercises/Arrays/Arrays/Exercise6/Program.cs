using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayContainer container = new ArrayContainer();

            var array = container.MakeRandomArrayWithLength(10);
            var array2 = container.CopyArrayFrom(array);

            container.ChangeLastElementWithMinusSevenIn(array2);

            var arrays = container.GetArrays();

            foreach(var arr in arrays)
            {
                Console.WriteLine(string.Join(" ",arr));
            } 
        }
    }
}
