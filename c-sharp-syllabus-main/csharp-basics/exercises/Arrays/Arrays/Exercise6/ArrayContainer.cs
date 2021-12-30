using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    public class ArrayContainer
    {
        private IList<int[]> _arrays;
        private Random _random;

        public ArrayContainer()
        {
            _arrays = new List<int[]>();
            _random = new Random();
        }

        public int[] MakeRandomArrayWithLength(int length)
        {
            if (IsValidLength(length))
            {
                int[] array = new int[length].Select(x => x=_random.Next(1, 101)).ToArray();
                _arrays.Add(array);
                return array;
            }

            throw new NotValidLengthParameterException(length);
        }

        public void ChangeLastElementWithMinusSevenIn(int[] array)
        {
            if (IsValidLength(array.Length))
            {
                array[array.Length-1] = -7;
                return;
            }

            throw new NotValidArrayLengthException(array.Length);
        }

        public int[] CopyArrayFrom(int[] array)
        {
            int[] secondArray =  array.ToArray();
            _arrays.Add(secondArray);
            return secondArray;
        }

        public IList<int[]> GetArrays()
        {
            return _arrays.ToList();
        }

        public bool IsValidLength(int length)
        {
            return length > 0;
        }
    }
}
