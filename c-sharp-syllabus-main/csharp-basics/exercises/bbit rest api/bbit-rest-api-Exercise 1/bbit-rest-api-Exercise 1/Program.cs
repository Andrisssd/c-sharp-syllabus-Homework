using System;
using System.Linq;
using System.Collections.Generic;

namespace bbit_rest_api_Exercise_1
{
    struct ArrayPoint
    {
        public int Value;
        public int DimensionZeroPos;
        public int DimensionOnePos;
    }

    class MinMaxValuesPoints
    {
        public ArrayPoint MinValue;
        public ArrayPoint MaxValue;

        public MinMaxValuesPoints()
        {
            MinValue = new ArrayPoint();
            MaxValue = new ArrayPoint();
            MinValue.Value = 100;
            MaxValue.Value = 9;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rndm = new Random();
            int[][] arr = new int[20][];
            var point = new MinMaxValuesPoints();
            List<int> arrOneD = new List<int>();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = new int[20];
                for(int j = 0; j < arr.GetLength(0); j++)
                {
                    int newRandom = rndm.Next(10, 100);

                    if (point.MinValue.Value > newRandom)
                    {
                        point.MinValue.Value = newRandom;
                        point.MinValue.DimensionZeroPos = i;
                        point.MinValue.DimensionOnePos = j;
                    }

                    if(point.MaxValue.Value < newRandom)
                    {
                        point.MaxValue.Value = newRandom;
                        point.MaxValue.DimensionZeroPos = i;
                        point.MaxValue.DimensionOnePos = j;
                    }

                    arr[i][j] = newRandom;
                    arrOneD.Add(newRandom);
                    
                    Console.Write($"[{arr[i][j]}] ");
                }
                
                Console.WriteLine();
            }

            Console.WriteLine($"MinValue = {point.MinValue.Value} at pos [{point.MinValue.DimensionZeroPos},{point.MinValue.DimensionOnePos}]");
            Console.WriteLine($"MaxValue = {point.MaxValue.Value} at pos [{point.MaxValue.DimensionZeroPos},{point.MaxValue.DimensionOnePos}]");

            int[] arr2 = arrOneD.ToArray();
            int index = 0;
            Array.Sort(arr2);

            for(int i =0; i<arr.GetLength(0); i++)
            {
                for(int j = 0; j<arr.GetLength(0); j++)
                {
                    Console.Write($"[{arr2[index]}] ");
                    index++;
                }
                
                Console.WriteLine();
            } 
        } 
    }
}
