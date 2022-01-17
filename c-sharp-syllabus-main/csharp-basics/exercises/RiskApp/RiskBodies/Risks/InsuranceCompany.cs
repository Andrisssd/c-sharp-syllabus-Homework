using Risks.Exceptions;

namespace Risks
{
    public class InsuranceCompany : IInsuranceCompany
    {
        public string Name { get; }

        private IList<Policy> _policies = new List<Policy>();

        public IList<Risk> AvailableRisks { get; set; }

        public InsuranceCompany(string name)
        {
            Name = name;
            AvailableRisks = new List<Risk>();
        }

        public void AddRisk(string nameOfInsuredObject, Risk risk, DateTime validFrom)
        {
            AvailableRisks.Add(risk);
            List<Policy> policies = _policies.Where(p => p.NameOfInsuredObject == nameOfInsuredObject && p.ValidFrom <= validFrom).ToList();
            foreach (var policy in policies)
            {
                policy.InsuredRisks.Add(risk);
                policy.Premium += risk.YearlyPrice;
            }
        }

        public IPolicy GetPolicy(string nameOfInsuredObject, DateTime effectiveDate)
        {
            Policy policy = _policies.Where(p => p.ValidTill >= effectiveDate && p.ValidFrom <= effectiveDate && p.NameOfInsuredObject == nameOfInsuredObject).FirstOrDefault();
            if (policy != null)
            {
                return new Policy(policy);
            }

            throw new PolicyNotFoundException();
        }

        public IPolicy SellPolicy(string nameOfInsuredObject, DateTime validFrom, short validMonths, IList<Risk> selectedRisks)
        {
            if (Validator.IsPolicyValid(nameOfInsuredObject, validFrom, validMonths, this._policies))
            {
                DateTime validTill = validFrom.AddMonths(validMonths);
                Policy policy = new Policy(nameOfInsuredObject, validFrom, validTill, selectedRisks.ToList());
                _policies.Add(policy);
                return new Policy(policy);
            }

            throw new ObjectAlreadyInsuredException();
        }
    }
}
