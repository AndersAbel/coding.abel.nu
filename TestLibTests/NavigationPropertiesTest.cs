using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;

namespace TestLibTests
{
    [TestClass]
    public class NavigationPropertiesTest
    {
        private void CheckValues(PersonInfo pi)
        {
            Assert.AreEqual("Nisse Karlsson", pi.Name);
            Assert.AreEqual(7, pi.CarsOwnedCount);
        }

        [TestMethod]
        public void TestJoin()
        {
            CheckValues(PersonInfo.GetWithJoin(3));
        }

        [TestMethod]
        public void TestNav()
        {
            CheckValues(PersonInfo.GetWithNavProperties(3));
        }

        [TestMethod]
        public void GetSimple()
        {
            using (DBContext ctx = new DBContext())
            {
                var q1 =
from p in ctx.Persons
join c in ctx.Cities
on p.BornIn equals c.CityID
select new
{
    p.FirstName,
    c.Name
};

                var q2 =
from p in ctx.Persons
select new
{
    p.FirstName,
    p.BornInCity.Name
};

            }
        }
    }
}
