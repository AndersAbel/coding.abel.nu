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
                SomeUtilClass.IsTooLate(DateTime.Now.AddDays(-1)));
            Assert.AreEqual("Yes :-(",
                SomeUtilClass.IsTooLate(DateTime.Now.AddDays(1)));

            Assert.AreEqual("Yes!", SomeUtilClass.IsSingleDigit(9));
            Assert.AreEqual("No!", SomeUtilClass.IsSingleDigit(10));

            Assert.AreEqual("Yes!", SomeUtilClass.IsSingleDigit(
                new IntStruct(9)));
            Assert.AreEqual("No!", SomeUtilClass.IsSingleDigit(
                new IntStruct(10)));

            Assert.AreEqual("Yes!", SomeUtilClass.IsSingleDigit(
                new SomeUtilClass.IntClass(9)));
            Assert.AreEqual("No!", SomeUtilClass.IsSingleDigit(
                new SomeUtilClass.IntClass(10)));

            Assert.AreEqual("Default value", SomeUtilClass.IsDefaultInt(0));
            Assert.AreEqual("Something else", SomeUtilClass.IsDefaultInt(1));
        }

        [TestMethod]
        public void TestImplementation1_IncludingNull()
        {
            TestImplementation1();

            Assert.AreEqual("Yes :-(", SomeUtilClass.IsTooLate(null));
            Assert.AreEqual("No!", SomeUtilClass.IsSingleDigit(
                (IntStruct?)null));
            Assert.AreEqual("No!", SomeUtilClass.IsSingleDigit((int?)null));
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
