using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;

namespace TestLibTests
{
    [TestClass]
    public class NullHandlingExtensionsTest
    {
        [TestMethod]
        public void TestTimeStamp()
        {
            string foo = NullHandlingExtensions.ExpandTimeStamp(null);
        }
    }
}
