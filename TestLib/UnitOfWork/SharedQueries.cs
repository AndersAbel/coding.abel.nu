using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestLib.Entities;

namespace TestLib.UnitOfWork
{
    public static class SharedQueries
    {
public static Entities.Car GetCar(int id)
{
    using (var uow = new UnitOfWorkScope<CarsContext>(UnitOfWorkScopePurpose.Reading))
    {
        return uow.DbContext.Cars.Single(c => c.CarId == id);
    }
}
    }
}
