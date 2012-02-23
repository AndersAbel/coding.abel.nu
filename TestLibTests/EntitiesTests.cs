using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Entities;
using System.Transactions;
using System.Data.Entity;
using System.Diagnostics;

namespace TestLibTests
{
    [TestClass]
    public class EntitiesTests
    {
        [TestMethod]
        public void TestStoreBrand()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                Brand volvo = new Brand { Name = "Volvo" };
                context.Brands.Add(volvo);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestStoreCar()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                Brand volvo = new Brand { Name = "Volvo" };
                Car myVolvo = new Car
                {
                    //BodyStyle = CarBodyStyle.StationWagon,
                    Brand = volvo,
                    RegistrationNumber = "ABC123"
                };

                context.Cars.Add(myVolvo);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestChangeTracking()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                Debug.WriteLine("Reading cars...");
                var cars = context.Cars.ToArray();
                Debug.WriteLine("Updating top speed of the first car...");
                Debug.WriteLine(string.Format("Type of car[0] is {0}", cars[0].GetType().ToString()));
                cars[0].TopSpeed = 260;

                Debug.WriteLine("Saving changes...");
                context.SaveChanges();
            }
        }
    }
}
