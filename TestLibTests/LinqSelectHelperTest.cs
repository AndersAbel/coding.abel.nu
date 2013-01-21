using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TestLib.Entities;
using CodingAbelNu.Utilities;
using System.Linq.Expressions;

namespace TestLibTests
{
    [TestClass]
    public class LinqSelectHelperTest
    {
        private class CarBasicInfo
        {
            public int CarId { get; set; }
            public string RegistrationNumber { get; set; }
        }

        private class CarExtendedInfo : CarBasicInfo
        {
            public string Color { get; set; }
            public string BrandName { get; set; }
        }

private Expression<Func<Car, CarBasicInfo>> basicSelect =
    c => new CarBasicInfo
    {
        CarId = c.CarId,
        RegistrationNumber = c.RegistrationNumber
    };

        [TestMethod]
        public void TestBasicSelect()
        {
            using (CarsContext ctx = new CarsContext())
            {
                var car = ctx.Cars.Select(basicSelect)
                    .Single(c => c.RegistrationNumber == "ABC123");

                Assert.IsNotNull(car);
            }
        }

        [TestMethod]
        public void TestMergedSelect()
        {
            using (CarsContext ctx = new CarsContext())
            {
var car = ctx.Cars.Select(basicSelect.Merge(c => new CarExtendedInfo
{
    Color = c.Color,
    BrandName = c.Brand.Name
})).Single(c => c.RegistrationNumber == "ABC123");

Assert.IsNotNull(car);
Assert.AreEqual("Red", car.Color);
Assert.AreEqual("Volvo", car.BrandName);
            }
        }
    }
}
