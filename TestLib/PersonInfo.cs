using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib
{
    public class PersonInfo
    {
        public string Name { get; set; }
        public string BornIn { get; set; }
        public string LivesIn { get; set; }
        public string Gender { get; set; }
        public int CarsOwnedCount { get; set; }

        public static PersonInfo GetWithJoin(int personId)
        {
            using (DBContext ctx = new DBContext())
            {
                return (
from p in ctx.Persons
where p.ID == personId
join bornIn in ctx.Cities
on p.BornIn equals bornIn.CityID
join livesIn in ctx.Cities
on p.LivesIn equals livesIn.CityID
join s in ctx.Sexes
on p.SexID equals s.ID
select new PersonInfo
{
    Name = p.FirstName + " " + p.LastName,
    BornIn = bornIn.Name,
    LivesIn = livesIn.Name,
    Gender = s.Name,
    CarsOwnedCount = ctx.Cars.Where(c => c.OwnerID == p.ID).Count()
}
                        ).Single();
            }
        }

        public static PersonInfo GetWithNavProperties(int personId)
        {
            using (DBContext ctx = new DBContext())
            { 
                return (
from p in ctx.Persons
where p.ID == personId
select new PersonInfo
{
    Name = p.FirstName + " " + p.LastName,
    BornIn = p.BornInCity.Name,
    LivesIn = p.LivesInCity.Name,
    Gender = p.Sex.Name,
    CarsOwnedCount = p.Cars.Count(),
}
                        ).Single();
            }
        }
    }
}
