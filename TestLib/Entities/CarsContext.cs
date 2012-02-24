using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using CodingAbelNu.Utilities.EntityFramework;

namespace TestLib.Entities
{
    public class CarsContext : DbContext
    {
        public CarsContext(string connectionString)
            : base(connectionString)
        {}

        public CarsContext() { }

        static CarsContext()
        {
            Database.SetInitializer(new ValidateDatabase<CarsContext>());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
