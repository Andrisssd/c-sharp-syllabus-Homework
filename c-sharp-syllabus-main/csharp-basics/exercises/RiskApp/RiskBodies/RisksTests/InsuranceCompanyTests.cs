using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risks.Exceptions;

namespace Risks.Tests
{
    [TestClass()]
    public class InsuranceCompanyTests
    {
        private IInsuranceCompany _insuranceCompany;

        [TestInitialize]
        public void Setup()
        {
            _insuranceCompany = new InsuranceCompany("Company");
        }

        [TestMethod]
        public void AddRisk_OneRisk_ShouldIncrementAvailableRisksListCount()
        {
            int expectedCount = 1;
            _insuranceCompany.AddRisk("PolicyName", new Risk("Something", 9999), new DateTime(2000, 10, 10));
            int actualCount = _insuranceCompany.AvailableRisks.Count();
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void AddRisk_OneRisk_ShouldIncrementPolicysRiskListCount()
        {
            int expectedCount = 2;

            _insuranceCompany.SellPolicy("Policy", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            _insuranceCompany.AddRisk("Policy", new Risk("Something1", 1), new DateTime(2000, 10, 10));
            _insuranceCompany.AddRisk("Policy", new Risk("Something2", 2), new DateTime(2000, 10, 10));
            int actualCount = _insuranceCompany.GetPolicy("Policy", new DateTime(2000, 10, 10, 10, 10, 10)).InsuredRisks.Count();
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void AddRist_OutdatedRisk_ShouldntIncrementPolicysRiskListCount()
        {
            int expectedCount = 1;

            _insuranceCompany.SellPolicy("Policy", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            _insuranceCompany.AddRisk("Policy", new Risk("Something1", 1), new DateTime(2000, 10, 10));
            _insuranceCompany.AddRisk("Policy", new Risk("Something2", 2), new DateTime(2000, 10, 9));
            int actualCount = _insuranceCompany.GetPolicy("Policy", new DateTime(2000, 10, 10, 10, 10, 10)).InsuredRisks.Count();
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        [DataRow("Policy")]
        [DataRow("SomeName")]
        [DataRow("SomeAnotherName")]
        public void GetPolicy_ValidData_ShouldReturnPolicy(string nameOfInsuredObject)
        {
            string expectedPolicyName = nameOfInsuredObject;
            _insuranceCompany.SellPolicy(nameOfInsuredObject, new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            IPolicy policy = _insuranceCompany.GetPolicy(nameOfInsuredObject, new DateTime(2000, 11, 9));
            string actualPolicyName = policy.NameOfInsuredObject;
            Assert.AreEqual(expectedPolicyName, actualPolicyName);
        }

        [TestMethod]
        public void GetPolicy_InvalidData_ShouldThrowException()
        {
            Assert.ThrowsException<PolicyNotFoundException>(() => _insuranceCompany.GetPolicy("SomeName", new DateTime(1000, 10, 10)));
        }

        [TestMethod]
        public void SellPolicy_ValidData_ReturnNewPolicy()
        {
            var actualObject = _insuranceCompany.SellPolicy("SomeName", new DateTime(2000, 10, 10), 1, new List<Risk>());
            Assert.IsTrue(actualObject is Policy);
        }

        [TestMethod]
        public void SellPolicy_InvalidData_ShouldThrowException1()
        {

            _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, new List<Risk>());
            Assert.ThrowsException<ObjectAlreadyInsuredException>(() => _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, new List<Risk>()));
        }

        [TestMethod]
        public void SellPolicy_InvalidData_ShouldThrowException2()
        {

            _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, new List<Risk>());
            Assert.ThrowsException<ObjectAlreadyInsuredException>(() => _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 9), 1, new List<Risk>()));
        }

        [TestMethod]
        public void SellPolicy_InvalidData_ShouldThrowException3()
        {

            _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, new List<Risk>());
            Assert.ThrowsException<ObjectAlreadyInsuredException>(() => _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 11), 1, new List<Risk>()));
        }

        [TestMethod]
        public void SellPolicy_InvalidData_ShouldThrowException4()
        {

            _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, new List<Risk>());
            Assert.ThrowsException<ValidMonthsNegativeException>(() => _insuranceCompany.SellPolicy("Company", new DateTime(2000, 11, 10), -1, new List<Risk>()));
        }
    }
}