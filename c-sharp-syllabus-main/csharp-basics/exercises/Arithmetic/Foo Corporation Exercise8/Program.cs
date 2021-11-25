using System;

namespace Foo_Corporation_Exercise8
{
    class Program
    {
        public static decimal GetFooEmployeesPaymentForHours(decimal oneHourPayment, int hourstAWeek)
        {
            decimal payment = 0;
            if (oneHourPayment>=8)
            {
                for (int i = 1; i <= hourstAWeek; i++)
                {
                    if (i<=40)
                    {
                        payment+=oneHourPayment;
                    }
                    else if (i>60)
                    {
                        throw new Exception("Maximum hours a week is 60!");
                    }
                    else
                    {
                        payment+=oneHourPayment*1.5M;
                    }
                }
            }
            else
            {
                throw new Exception("Base Pay is lower than 8$ per hour");
            }
            return payment;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"For 45 hours a week with base pay of 8$, Foo Corparation pays employee {GetFooEmployeesPaymentForHours(8,45)} $");
        }
    }
}
