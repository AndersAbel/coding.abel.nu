using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;

namespace TestLibTests
{
    [TestClass]
    public class LambdaEventSubscribeTests
    {
        [TestMethod]
        public void Test()
        {
            var result = new Stack<int>();

            LambdaEventSubscribe.Run(result);

            Assert.AreEqual(2, result.Count, "Count");
            Assert.AreEqual(1, result.Pop());
            Assert.AreEqual(2, result.Pop());
        }
    }
}
