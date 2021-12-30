
using System;

namespace GravityCalculator_7
{
    class Program
    {
        static void Main(string[] args)
        {
            GravityCalculator calculator = new GravityCalculator();
            calculator.CalculateFinalPositionAfter(10);
            Console.WriteLine(calculator.GetResultString());
        }
    }
}
