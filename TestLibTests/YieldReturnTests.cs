using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;
using System.Diagnostics;

namespace TestLibTests
{
    [TestClass]
    public class YieldReturnTests
    {
        [TestMethod]
        public void RunYieldReturnNumbers()
        {
            YieldReturn.RunNumbers();
        }
    }
}
