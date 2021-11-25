using System;

namespace BMI_Exercise9
{
    class Program
    {
        public static void CalculateBMI(double heightMetric, double weightKg)
        {
            double weight = weightKg/0.45359237;
            double height = heightMetric/2.54;
            double BMI = (weight*703)/(Math.Pow((double)height, 2));
            if(BMI >= 18.5 && BMI <= 25)
            {
                Console.WriteLine("Normal BMI");
            }
            else if(BMI < 18.5)
            {
                Console.WriteLine("Underweight");
            }
            else
            {
                Console.WriteLine("Overweight");
            }
        }
        static void Main(string[] args)
        {
            
            CalculateBMI(188, 83);
        }
    }
}
