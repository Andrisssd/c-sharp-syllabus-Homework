using System;

namespace SumAverageRunningInt
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;
            
            const int lowerBound = 1;
            const int upperBound = 100;

            for (var number = lowerBound; number <= upperBound; ++number) 
            {
                sum += number;
            }

            int average = sum/(upperBound-lowerBound);
            
        }
    }
}
