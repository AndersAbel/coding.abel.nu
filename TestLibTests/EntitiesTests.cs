using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Entities;
using System.Transactions;
using System.Data.Entity;

namespace TestLibTests
{
    [TestClass]
    public class EntitiesTests
    {
        [TestInitialize]
        public void CreateDb()
        {
            CarsContext context = new CarsContext();
            context.Database.CreateIfNotExists();
        }

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
                    BodyStyle = CarBodyStyle.StationWagon,
                    Brand = volvo,
                    RegistrationNumber = "ABC123"
                };

                context.Cars.Add(myVolvo);
                context.SaveChanges();
            }
        }
    }
}
