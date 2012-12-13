using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Infrastructure;
using TestLib.Entities;

namespace TestLibTests
{
    [TestClass]
    public class EfSavingChanges
    {
[TestMethod]
public void TestSavingChanges()
{
    using (var ctx = new CarsContext())
    {
        var objCtx = ((IObjectContextAdapter)ctx).ObjectContext;

        bool eventCalled = false;

        objCtx.SavingChanges += (sender, args) => eventCalled = true;

        ctx.SaveChanges();

        Assert.IsTrue(eventCalled);
    }
}
    }
}
