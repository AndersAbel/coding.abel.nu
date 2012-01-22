using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingAbelNu.Utilities.ToSelectList;
using System.Web.Mvc;

namespace CodingAbelNu.UtilitiesTest
{
    [TestClass]
    public class ToSelectListTest
    {
        [TestMethod]
        public void TestToSelectList()
        {
            Dictionary<int, string> dict = new Dictionary<int,string> { { 1, "A" }, { 2, "B" } };

            SelectList sl = dict.ToSelectList(kvp => kvp.Key, kvp => kvp.Value);

            Assert.AreEqual(sl.First().Text, "A");
            Assert.AreEqual(sl.First().Value, "1");
       } 
    }
}
