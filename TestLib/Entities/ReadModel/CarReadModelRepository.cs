using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib.Entities.ReadModel
{
    public static class CarReadModelRepository
    {
        public static CarReadModel GetById(int id)
        {
            using (CarsContext ctx = new CarsContext())
            {
                return (
from c in ctx.Cars
where c.CarId == id
select new CarReadModel
{
    Car = c,
    BrandName = c.Brand.Name
}
                    ).Single();
            }
        }

public static IQueryable<CarReadModel> SelectCarReadModel(this IQueryable<Car> query)
{
    return query.Select(c => new CarReadModel
    {
        Car = c,
        BrandName = c.Brand.Name
    });
}

        public static CarReadModel SearchByBrand(string brandFilter)
        {
            using (CarsContext ctx = new CarsContext())
            {
                return (
from c in ctx.Cars.SelectCarReadModel()
where c.BrandName.StartsWith(brandFilter)
select c
                ).Single();
            }   
        }

        public static CarReadModel GetById2(int id)
        {
            using( CarsContext ctx = new CarsContext())
            {
                return
(from c in ctx.Cars
 where c.CarId == id
 select c).SelectCarReadModel()
                .Single();
            }
        }
        
        public static CarReadModel GetById3(int id)
        {
            using (CarsContext ctx = new CarsContext())
            {
                return (
from c in ctx.Cars.SelectCarReadModel()
where c.Car.CarId == id
select c
                ).Single();
            }
        }
    }
}
