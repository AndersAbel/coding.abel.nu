using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.LibraryCode;

namespace TestLibTests
{

    [TestClass]
    public class LibraryCodeTests
    {
        [TestMethod]
        public void TestApplicationLogger()
        {
            ApplicationLogger.Write(ApplicationLoggerSeverity.Information, "Logging!");
        }

        [TestMethod]
        public void TestLibraryLogger()
        {
            LogFactory.CreateLogger().Write(LogSeverity.SystemInformation, "Logging!");
        }
    }
}
