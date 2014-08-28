using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TestLib.Tuples;

namespace TestLibTests
{
    [TestClass]
    public class TupleTests
    {
        [TestMethod]
        public void Test_AggregatedAverage()
        {
            var data = new int[][]
            {
                new int[] {5},
                new int[] {1, 2, 3},
                new int[] {9, 2, 5, 2}
            };

            var average = data.SelectMany(i => i).Average();

            Assert.AreEqual(average, BadTupleSamples.AggregatedAverage(data));
        }
    }
}
