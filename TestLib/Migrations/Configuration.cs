namespace TestLib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestLib.Entities;
    using System.Collections.Generic;
    using CodingAbelNu.Utilities.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<TestLib.Entities.CarsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public static void Seed()
        {
            using (var context = new CarsContext())
            {
                new Configuration().Seed(context);

                context.SaveChanges();
            }
        }

        protected override void Seed(TestLib.Entities.CarsContext context)
        {
            //  This method will be called after migrating to the latest version.

            var brands = new string[] { "Volvo", "Saab", "Audi" }
                .Select(s => new Brand { Name = s })
                .ToDictionary(b => b.Name);

            context.Brands.AddOrUpdate(b => b.Name, brands["Volvo"], brands["Saab"], brands["Audi"]);

            context.Cars.AddOrUpdate(c => c.RegistrationNumber,
                new Car
                {
                    BrandId = brands["Volvo"].BrandId,
                    RegistrationNumber = "ABC123",
                    TopSpeed = 210,
                    Color = "Red"
                },
                new Car
                {
                    BrandId = brands["Saab"].BrandId,
                    RegistrationNumber = "XYZ987",
                    TopSpeed = 250,
                    Color = "Blue"
                });

            context.People.AddOrUpdate(p => p.BirthYear,
                new Person { BirthYear = 1979 },
                new Person { BirthYear = 2006 },
                new Person { BirthYear = 2009 }
                );

            context.Genders.AddOrUpdate(
                new Gender() { GenderId = Gender.UnSpecified, Description = "UnSpecified" },
                new Gender() { GenderId = Gender.Male, Description = "Male" },
                new Gender() { GenderId = Gender.Female, Description = "Female" });

            context.PhoneBook.AddOrUpdate(pbe => pbe.Name,
                new PhoneBookEntry() { Name = "Charlie", PhoneNumber = "1234" },
                new PhoneBookEntry() { Name = "Johhny", PhoneNumber = "9876" });

            context.Seed<TestLib.Entities.CarBodyStyle>();
        }
    }
}
