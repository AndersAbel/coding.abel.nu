using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;
using System.Xml.Linq;


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

        [TestMethod]
        public void TestGetServerName()
        {
            XElement config = new XElement("config");

            Assert.AreEqual("(local)", NullHandlingExtensions.GetServerName1(config));
            Assert.AreEqual("(local)", NullHandlingExtensions.GetServerName2(config));
        }
    }
}
