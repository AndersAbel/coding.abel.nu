using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Entities;
using System.Transactions;
using System.Data.Entity;
using System.Diagnostics;
using TestLib.Migrations;

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
                context.Configuration.AutoDetectChangesEnabled = false;

                Debug.WriteLine("Reading people...");
                var people = context.People.ToArray();
                Debug.WriteLine(string.Format("Type of people[0] is {0}",
                    people[0].GetType().ToString()));

                Debug.WriteLine("Updating birth year of first person...");
                people[0].BirthYear = 1965;

                Debug.WriteLine("Saving changes...");
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestSeed()
        {
            Configuration.Seed();
        }
    }
}
