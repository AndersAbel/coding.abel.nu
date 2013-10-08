using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Entities;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;

namespace TestLibTests
{
    [TestClass]
    public class TestForExceptions
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_Using_ExpectedException()
        {
            var attributes = typeof(Brand).GetMember("Nmae").Single()
                .GetCustomAttributes(false);

            // This should throw.
            attributes.OfType<RequiredAttribute>().First()
                .FormatErrorMessage("InvalidName");
        }

        [TestMethod]
        public void Test_Using_FluentAssertions()
        {
            var attributes = typeof(Brand).GetMember("Nmae").Single()
                .GetCustomAttributes(false);

            Action a = () => attributes.OfType<RequiredAttribute>().First()
                .FormatErrorMessage("InvalidName");

            a.ShouldThrow<InvalidOperationException>();
        }
    }
}
