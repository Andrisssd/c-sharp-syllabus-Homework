using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[10];
            string str = "";
            for(int i =0; i<array1.Length; i++)
            {
                array1[i] = new Random().Next(1, 101);
            }

            int[] array2 = new int[array1.Length];
            Array.Copy(array1, array2, array1.Length);
            array1[array1.Length-1] = -7;
            str+="Array 1: ";
            foreach(var num in array1)
            {
                str+=num+" ";
            }

            str+="\nArray 2: ";
            foreach(var num in array2)
            {
                str+=num+" ";
            }

            Console.WriteLine(str);
        }
    }
}
