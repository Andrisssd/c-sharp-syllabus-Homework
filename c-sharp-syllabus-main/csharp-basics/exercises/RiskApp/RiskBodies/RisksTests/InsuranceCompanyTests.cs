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
            //Arrange
            int expectedCount = 1;
            _insuranceCompany.AddRisk("PolicyName", new Risk() { Name="Something",YearlyPrice=9999}, new DateTime(2000, 10, 10));
            //Act
            int actualCount = _insuranceCompany.AvailableRisks.Count();
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void AddRisk_OneRisk_ShouldIncrementPolicysRiskListCount()
        {
            //Arrange
            int expectedCount = 2;
            _insuranceCompany.SellPolicy("Policy", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            _insuranceCompany.AddRisk("Policy", new Risk() { Name="Something",YearlyPrice=1}, new DateTime(2000, 10, 10));
            _insuranceCompany.AddRisk("Policy", new Risk() { Name="Something2",YearlyPrice=2}, new DateTime(2000, 10, 10));
            //Act
            int actualCount = _insuranceCompany.GetPolicy("Policy", new DateTime(2000, 10, 10, 10, 10, 10)).InsuredRisks.Count();
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void AddRist_OutdatedRisk_ShouldntIncrementPolicysRiskListCount()
        {
            //Arrange
            int expectedCount = 1;
            _insuranceCompany.SellPolicy("Policy", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            _insuranceCompany.AddRisk("Policy", new Risk() { Name="Something1",YearlyPrice=1}, new DateTime(2000, 10, 10));
            _insuranceCompany.AddRisk("Policy", new Risk() { Name="Something2",YearlyPrice=2}, new DateTime(2000, 10, 9));
            //Act
            var actualPolicy = _insuranceCompany.GetPolicy("Policy", new DateTime(2000, 10, 10, 10, 10, 10));
            //Assert
            Assert.AreEqual(expectedCount, actualPolicy.InsuredRisks.Count());
        }

        [TestMethod]
        [DataRow("Policy")]
        [DataRow("SomeName")]
        [DataRow("SomeAnotherName")]
        public void GetPolicy_ValidData_ShouldReturnPolicy(string nameOfInsuredObject)
        {
            //Arrange
            string expectedPolicyName = nameOfInsuredObject;
            _insuranceCompany.SellPolicy(nameOfInsuredObject, new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            //Act
            IPolicy policy = _insuranceCompany.GetPolicy(nameOfInsuredObject, new DateTime(2000, 11, 9));
            //Assert
            Assert.AreEqual(expectedPolicyName, policy.NameOfInsuredObject);
        }

        [TestMethod]
        public void GetPolicy_InvalidData_ShouldThrowException()
        {
            //Assert
            Assert.ThrowsException<PolicyNotFoundException>(() => _insuranceCompany.GetPolicy("SomeName", new DateTime(1000, 10, 10)));
        }

        [TestMethod]
        public void SellPolicy_ValidData_ReturnNewPolicy()
        {
            //Arrange
            var actualObject = _insuranceCompany.SellPolicy("SomeName", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            //Assert
            Assert.IsTrue(actualObject is Policy);
        }

        [TestMethod]
        public void SellPolicy_InvalidData_ShouldThrowException1()
        {
            //Arrange
            _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            //Assert
            Assert.ThrowsException<ObjectAlreadyInsuredException>(() => _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks));
        }

        [TestMethod]
        public void SellPolicy_InvalidData_ShouldThrowException2()
        {
            //Arrange
            _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            //Assert
            Assert.ThrowsException<ObjectAlreadyInsuredException>(() => _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 9), 1, _insuranceCompany.AvailableRisks));
        }

        [TestMethod]
        public void SellPolicy_InvalidData_ShouldThrowException3()
        {
            //Arrange
            _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            //Assert
            Assert.ThrowsException<ObjectAlreadyInsuredException>(() => _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 11), 1, _insuranceCompany.AvailableRisks));
        }

        [TestMethod]
        public void SellPolicy_InvalidData_ShouldThrowException4()
        {
            //Arrange
            _insuranceCompany.SellPolicy("Company", new DateTime(2000, 10, 10), 1, _insuranceCompany.AvailableRisks);
            //Assert
            Assert.ThrowsException<ValidMonthsNegativeException>(() => _insuranceCompany.SellPolicy("Company", new DateTime(2000, 11, 10), -1, _insuranceCompany.AvailableRisks));
        }
    }
}