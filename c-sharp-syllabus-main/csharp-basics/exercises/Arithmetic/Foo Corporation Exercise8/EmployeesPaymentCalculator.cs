using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foo_Corporation_Exercise8
{
    public class EmployeesPaymentCalculator
    {
        public decimal GetFooEmployeesPaymentForHours(decimal oneHourPayment, int hourstAWeek)
        {
            if (oneHourPayment >= 8M)
            {
                if (hourstAWeek <= 60)
                {
                    if (hourstAWeek <= 40)
                    {
                        return oneHourPayment * hourstAWeek;
                    }
                    else
                    {
                        return oneHourPayment * 40 + (hourstAWeek - 40) * oneHourPayment * 1.5M;
                    }
                }

                throw new WeekOverworkException();
            }

            throw new EmployeesPaymentLimitException(oneHourPayment);
        }
    }
}
