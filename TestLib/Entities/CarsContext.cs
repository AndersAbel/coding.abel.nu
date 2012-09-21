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
        { }

        public CarsContext() { }

        static CarsContext()
        {
            Database.SetInitializer(new ValidateDatabase<CarsContext>());
        }

        private DbSet<Car> cars;
        public DbSet<Car> Cars
        {
            get
            {
                return cars;
            }
            set
            {
                cars = value;
            }
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<PhoneBookEntry> PhoneBook { get; set; }
    }
}
