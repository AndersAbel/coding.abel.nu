using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Extensions;
using System.Diagnostics;

namespace TestLibTests
{
    [TestClass]
    public class ExtensionMethods
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] Animals = new string[] { "Dog", "Cat", "Horse", "Cow" };

string[] wishList1 =
    Enumerable.ToArray(
    Enumerable.Select(Enumerable.Where(Animals, a => a.StartsWith("A"))
    , a => string.Format("I want a {0}.", a)));

string[] wishList2 = Animals.Where(a => a.StartsWith("A"))
    .Select(a => string.Format("I want a {0}.", a)).ToArray();

        }

        [TestMethod]
        public void TestIsEmail()
        {
            string[] strings = new string[]
            {
                "a@example.com",
                "someone@email.invalid",
                "another.example@of.an.email.org",
            };

foreach (string s in strings)
{
    if (s.IsEmail())
    {
        Debug.WriteLine("{0} is a valid email address", (object)s);
    }
    else
    {
        Debug.WriteLine("{0} is not a valid email address", (object)s);
    }
}
        }

        [TestMethod]
        public void TestMyWhere()
        {
            var nums = Enumerable.Range(0, 10);

            Assert.AreEqual(5, nums.MyWhere(n => n == 5).Single());
            Assert.AreEqual(5, nums.MyWhere(n => n % 2 == 0).Count());
        }

        [TestMethod]
        public void TestRide()
        {
Debug.WriteLine("Riding horse...");
Horse horse = new Horse();
horse.Ride();

Debug.WriteLine("Riding wild horse...");
WildHorse wildHorse = new WildHorse();
wildHorse.Ride();

Debug.WriteLine("Treating wild horse as horse...");
horse = wildHorse;
horse.Ride();
        }

        [TestMethod]
        public void TestDynamic()
        {
dynamic horse = new Horse();
horse.Ride();
        }
    }

}
