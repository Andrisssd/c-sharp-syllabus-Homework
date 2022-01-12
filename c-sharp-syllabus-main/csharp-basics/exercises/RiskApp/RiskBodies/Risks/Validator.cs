using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risks.Exceptions;

namespace Risks
{
    public static class Validator
    {
        public static bool PolicyIsValid(string nameOfInsuredObject, DateTime validFrom, short validMonths, IList<Policy> policyList)
        {
            DateTime validTill = validFrom.AddMonths(validMonths);
            bool isValid = true;

            foreach(var policy in policyList)
            {
                if(policy.ValidTill > validFrom && policy.ValidFrom < validFrom)
                {
                    if(policy.NameOfInsuredObject == nameOfInsuredObject)
                    {
                        isValid = false;
                    }
                }

                if (policy.ValidTill > validTill && policy.ValidFrom < validTill)
                {
                    if (policy.NameOfInsuredObject == nameOfInsuredObject)
                    {
                        isValid = false;
                    }
                }

                if (policy.ValidTill == validTill && policy.ValidFrom == validFrom)
                {
                    if (policy.NameOfInsuredObject == nameOfInsuredObject)
                    {
                        isValid = false;
                    }
                }
            }

            if(validMonths < 0)
            {
                throw new ValidMonthsNegativeException();
            }

            return isValid;
        }
    }
}
