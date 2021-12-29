using System;

namespace Foo_Corporation_Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeesPaymentCalculator calculator = new EmployeesPaymentCalculator();

            Console.WriteLine($"For 45 hours a week with base pay of 8$, Foo Corparation pays employee {calculator.GetFooEmployeesPaymentForHours(8,45)} $");
        }
    }
}
