using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.CalculatorClient;

namespace TestLibTests
{
    [TestClass]
    public class Wcf32BitTest
    {
        [TestMethod]
        public void TestMultiply()
        {
            using (CalculatorClient client = new CalculatorClient())
            {
                Assert.AreEqual(6, client.Multiply(2, 3));
            }
        }
    }
}
