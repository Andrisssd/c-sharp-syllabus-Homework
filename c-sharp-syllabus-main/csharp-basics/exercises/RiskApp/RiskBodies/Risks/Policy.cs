using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risks
{
    public class Policy : IPolicy
    {
        public string NameOfInsuredObject { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTill { get; set; }

        public decimal Premium { get; set; }

        public IList<Risk> InsuredRisks { get; set; }

        public Policy(string nameOfInsuredObject, DateTime validFrom, DateTime validTill, IList<Risk> risks)
        {
            InsuredRisks = risks;
            NameOfInsuredObject = nameOfInsuredObject;
            ValidFrom = validFrom;
            ValidTill = validTill;
            Premium = Calculator.CountRisksWorth(risks);
        }

        public Policy(string nameOfInsuredObject, DateTime validFrom, DateTime validTill)
        {
            InsuredRisks = new List<Risk>();
            NameOfInsuredObject = nameOfInsuredObject;
            ValidFrom = validFrom;
            ValidTill = validTill;
            Premium = Calculator.CountRisksWorth(InsuredRisks);
        }

        public Policy(Policy policy)
        {
            this.ValidFrom = policy.ValidFrom;
            this.NameOfInsuredObject= policy.NameOfInsuredObject;
            this.ValidTill = policy.ValidTill;
            this.InsuredRisks = policy.InsuredRisks;
            this.Premium = policy.Premium;
        }
    }
}
