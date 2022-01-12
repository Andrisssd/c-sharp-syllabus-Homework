using Risks.Exceptions;

namespace Risks
{
    public class InsuranceCompany : IInsuranceCompany
    {
        public string Name { get; }

        public IList<Policy> Policies { get; }

        public IList<Risk> AvailableRisks { get; set; }

        public InsuranceCompany(string name)
        {
            Name = name;
            Policies = new List<Policy>();
            AvailableRisks = new List<Risk>();
        }

        public void AddRisk(string nameOfInsuredObject, Risk risk, DateTime validFrom)
        {
            AvailableRisks.Add(risk);
            List<Policy> policies = Policies.Where(p => p.NameOfInsuredObject == nameOfInsuredObject && p.ValidFrom <= validFrom).ToList();
            foreach (var policy in policies)
            {
                policy.InsuredRisks.Add(risk);
                policy.Premium += risk.YearlyPrice;
            }
        }

        public IPolicy GetPolicy(string nameOfInsuredObject, DateTime effectiveDate)
        {
            Policy policy = Policies.Where(p => p.ValidTill >= effectiveDate && p.ValidFrom <= effectiveDate && p.NameOfInsuredObject == nameOfInsuredObject).FirstOrDefault();
            if (policy != null)
            {
                return (IPolicy)new Policy(policy);
            }

            throw new PolicyNotFoundException();
        }

        public IPolicy SellPolicy(string nameOfInsuredObject, DateTime validFrom, short validMonths, IList<Risk> selectedRisks)
        {
            if (Validator.PolicyIsValid(nameOfInsuredObject, validFrom, validMonths, this.Policies))
            {
                DateTime validTill = validFrom.AddMonths(validMonths);
                Policy policy = new Policy(nameOfInsuredObject, validFrom, validTill, selectedRisks.ToList());
                Policies.Add(policy);
                return (IPolicy)new Policy(policy);
            }

            throw new ObjectAlreadyInsuredException();
        }
    }
}
