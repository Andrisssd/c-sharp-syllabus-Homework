using NUnit.Framework;
using Risks;

namespace Risks.Tests
{
    public class Tests
    {
        private Risk _risk;

        [SetUp]
        public void Setup()
        {
            _risk = new Risk();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}