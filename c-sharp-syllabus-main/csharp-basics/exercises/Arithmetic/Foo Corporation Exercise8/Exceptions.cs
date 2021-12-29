using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foo_Corporation_Exercise8
{
    [Serializable]
    public class WeekOverworkException : Exception
    {
        public WeekOverworkException() { }

        public WeekOverworkException(int hoursWorked) : base (String.Format("Employees total work hours per week shouldn't be negative and more than 65!"))
        {

        }
    }

    [Serializable]
    public class EmployeesPaymentLimitException : Exception
    {
        public EmployeesPaymentLimitException() { }

        public EmployeesPaymentLimitException(decimal oneHourPayment) : base (String.Format("{0} $/h is less than 8 $/h!",oneHourPayment)) 
        {

        }
    }
}
