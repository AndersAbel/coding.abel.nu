using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.TextParser;
using System.IO;
using System.Reflection;

namespace TestLibTests
{
    [TestClass]
    public class TextParserTest
    {
        [TestMethod]
        public void TestParser()
        {
            string path = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "TextParser\\CarBrands.csv");

            BrandReader reader = new BrandReader(path);

            var results = reader.Read().ToList();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(1926, results[0].EstablishedYear);
            Assert.AreEqual("Gothenburg, Sweden; Gent, Belgium", results[0].FactoryLocation);
            Assert.AreEqual(0.345463, results[0].Profit, 0.0000001);
            Assert.AreEqual(-3009.0, results[1].Profit, 0.01);
        }
    }
}
