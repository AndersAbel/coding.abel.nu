using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.TestingCoverage;

namespace TestLibTests
{
    [TestClass]
    public class TestingCoverage
    {
        [TestMethod]
        public void Test()
        {
            var result = ValueFormatter.Format(null);

            Assert.AreEqual("The value is 42.", result);
        }

        [TestMethod]
        public void TestDefaultValue()
        {
            var result = ValueFormatter.Format(null);

            Assert.AreEqual("The value is 42.", result);
        }

        [TestMethod]
        public void TestGivenValue()
        {
            var result = ValueFormatter.Format(7);

            Assert.AreEqual("The value is 7.", result);
        }
    }
}
