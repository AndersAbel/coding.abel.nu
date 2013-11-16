using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.ExceptionSafety;
using System.Diagnostics;
using System.Text.RegularExpressions;

#pragma warning disable 0642

namespace TestLibTests
{
    [TestClass]
    public class ExceptionSafetyTests
    {
        [TestMethod]
        public void RunNotExceptionSafe()
        {
            try
            {
                using (new NotExceptionSafe()) ;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught {0} exception ({1})", ex.GetType().Name, ex.Message);
            }
        }

        [TestMethod]
        public void RunExceptionSafe()
        {
            try
            {
                using (new ExceptionSafe()) ;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught {0} exception ({1})", ex.GetType().Name, ex.Message);
            }
        }
    }
}
