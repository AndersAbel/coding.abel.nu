using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Entities;
using TestLib.UnitOfWork;
using System.Transactions;
using System.Threading;

namespace TestLibTests
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void TestSimpleJoin()
        {
            using (CarsContext ctx = new CarsContext())
            {
                var q = from c in ctx.Cars
                        join b in ctx.Brands
                        on c.BrandId equals b.BrandId
                        select new
                        {
                            c.RegistrationNumber,
                            NavName = c.Brand.Name,
                            JoinName = b.Name
                        };

                q.ToList();
            }
        }

        [TestMethod]
        public void TestDifferentContexts()
        {
            using (CarsContext ctx1 = new CarsContext())
            using (CarsContext ctx2 = new CarsContext())
            {
                Car c1 = ctx1.Cars.First();
                Car c2 = ctx2.Cars.First();

                Assert.IsFalse(object.ReferenceEquals(c1, c2));
            }
        }

        [TestMethod]
        public void TestNestedScopesShareContext()
        {
            using (var uow1 = new UnitOfWorkScope<CarsContext>(UnitOfWorkScopePurpose.Reading))
            using (var uow2 = new UnitOfWorkScope<CarsContext>(UnitOfWorkScopePurpose.Reading))
            {
                Car c1 = uow1.DbContext.Cars.First();
                Car c2 = uow2.DbContext.Cars.First();

                Assert.IsTrue(object.ReferenceEquals(c1, c2));
            }
        }

        [TestMethod]
        public void TestSubsequentScopesNotShareContext()
        {
            Car c1, c2;

            using (var uow = new UnitOfWorkScope<CarsContext>(UnitOfWorkScopePurpose.Reading))
            {
                c1 = uow.DbContext.Cars.First();
            }
            using (var uow = new UnitOfWorkScope<CarsContext>(UnitOfWorkScopePurpose.Reading))
            {
                c2 = uow.DbContext.Cars.First();
            }

            Assert.IsFalse(object.ReferenceEquals(c1, c2));
        }

        [TestMethod]
        public void UpdateFirstCar()
        {
            int carId = 4;

            using (var ts = new TransactionScope())
            {
using (var uow = new UnitOfWorkScope<CarsContext>(UnitOfWorkScopePurpose.Writing))
{
    Car c = SharedQueries.GetCar(carId);
    c.Color = "White";
    uow.SaveChanges();
}

                using (var ctx = new CarsContext())
                {
                    Assert.AreEqual("White",
                        ctx.Cars.Single(c => c.CarId == carId).Color);
                }
            }

            using (var ctx = new CarsContext())
            {
                Assert.AreEqual("Red",
                    ctx.Cars.Single(c => c.CarId == carId).Color);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestWritingChildOfReadScope()
        {
            using (UnitOfWorkScope<CarsContext>
                uow1 = new UnitOfWorkScope<CarsContext>(UnitOfWorkScopePurpose.Reading),
                uow2 = new UnitOfWorkScope<CarsContext>(UnitOfWorkScopePurpose.Writing))
            { 
            
            }
        }
    }
}
