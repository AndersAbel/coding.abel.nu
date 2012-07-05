using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib.Entities.ReadModel
{
    public class CarReadModelRepository
    {
        public CarReadModel GetById(int id)
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
    }
}
