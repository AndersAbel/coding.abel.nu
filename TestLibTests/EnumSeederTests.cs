using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Entities;
using CodingAbelNu.Utilities.EntityFramework;

namespace TestLibTests
{
    [TestClass]
    public class EnumSeederTests
    {
        [TestMethod]
        public void RunSeedMethod()
        {
            // Not a proper unit test, nor placed in the right unit test lib,
            // but it's a great runner to use to get the code running.

            using (var ctx = new CarsContext())
            {
                ctx.Seed<CarBodyStyle>();
            }
        }
        
        [TestMethod]
        public void RunSeedMethod_WithoutDescription()
        {
            using (var ctx = new CarsContext())
            {
                ctx.Seed<CarBodyStyle>(descriptionField: null);
            }
        }
    }
}
