using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using TestLib;
using System.Data.SqlClient;


namespace TestLibTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void TestRetire()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Assert.IsTrue(Car.Retire("VLV100"));
                Assert.IsFalse(Car.Retire("VLV100"));
                    
                // Deliberately not commiting transaction.
            }
        }

        [TestMethod]
        public void TestCountCars()
        {
            int actualCount = (new DBContext()).Cars.Count();
            
            for(int i = 0; i < 1000; i++)
            {
                try
                {
                    Assert.AreEqual(actualCount, Car.CountCars());
                }
                catch (SqlException) { }
            }
        }
    }
}
