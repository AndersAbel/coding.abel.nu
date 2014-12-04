using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.NullableCodeCoverage;

namespace TestLibTests
{
    [TestClass]
    public class NullableCodeCoverage
    {
        [TestMethod]
        public void TestImplementation1()
        {
            Assert.AreEqual("No!",
                SomeUtilClass1.IsTooLate(DateTime.Now.AddDays(-1)));
            Assert.AreEqual("Yes :-(",
                SomeUtilClass1.IsTooLate(DateTime.Now.AddDays(1)));

            Assert.AreEqual("Yes!", SomeUtilClass1.IsSingleDigit(9));
            Assert.AreEqual("No!", SomeUtilClass1.IsSingleDigit(10));

            Assert.AreEqual("Yes!", SomeUtilClass1.IsSingleDigit(
                new IntStruct(9)));
            Assert.AreEqual("No!", SomeUtilClass1.IsSingleDigit(
                new IntStruct(10)));

            Assert.AreEqual("Yes!", SomeUtilClass1.IsSingleDigit(
                new SomeUtilClass1.IntClass(9)));
            Assert.AreEqual("No!", SomeUtilClass1.IsSingleDigit(
                new SomeUtilClass1.IntClass(10)));
        }

        [TestMethod]
        public void TestImplementation1_IncludingNull()
        {
            TestImplementation1();

            Assert.AreEqual("Yes :-(", SomeUtilClass1.IsTooLate(null));
            Assert.AreEqual("No!", SomeUtilClass1.IsSingleDigit(
                (IntStruct?)null));
        }

        [TestMethod]
        public void TestImplementation2()
        {
            Assert.AreEqual("No!",
                SomeUtilClass2.IsTooLate(DateTime.Now.AddDays(-1)));
            Assert.AreEqual("Yes :-(",
                SomeUtilClass2.IsTooLate(DateTime.Now.AddDays(1)));

            Assert.AreEqual("Yes!", SomeUtilClass2.IsSingleDigit(
                new SomeUtilClass2.IntStruct(9)));
            Assert.AreEqual("No!", SomeUtilClass2.IsSingleDigit(
                new SomeUtilClass2.IntStruct(10)));
        }
    }
}
