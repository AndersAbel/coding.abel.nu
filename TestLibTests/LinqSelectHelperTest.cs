using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TestLib.Entities;
using CodingAbelNu.Utilities;

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

        private IQueryable<CarBasicInfo> SelectBasicInfo(IQueryable<Car> source)
        {
            return source.Select(c => new CarBasicInfo
            {
                CarId = c.CarId,
                RegistrationNumber = c.RegistrationNumber
            });
        }

        [TestMethod]
        public void TestBasicSelect()
        {
            using (CarsContext ctx = new CarsContext())
            {
                var car = SelectBasicInfo(ctx.Cars).Single(c => c.RegistrationNumber == "ABC123");

                Assert.IsNotNull(car);
            }
        }

        [TestMethod]
        public void TestMergedSelect()
        {
            using (CarsContext ctx = new CarsContext())
            {
var car = ctx.Cars.Merge(SelectBasicInfo(ctx.Cars), c => new CarExtendedInfo
    {
        Color = c.Color,
        BrandName = c.Brand.Name
    }).Single(c => c.RegistrationNumber == "ABC123");

    Assert.IsNotNull(car);
    Assert.AreEqual("Red", car.Color);
    Assert.AreEqual("Volvo", car.BrandName);
            }
        }
    }
}
