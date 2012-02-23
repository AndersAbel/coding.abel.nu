namespace TestLib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
using TestLib.Entities;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<TestLib.Entities.CarsContext>
    {
public Configuration()
{
    AutomaticMigrationsEnabled = false;
}

        protected override void Seed(TestLib.Entities.CarsContext context)
        {
            //  This method will be called after migrating to the latest version.

            var brands = new string[] { "Volvo", "Saab" }
                .Select(s => new Brand { Name = s })
                .ToDictionary(b => b.Name);

            context.Brands.AddOrUpdate(b => b.Name, brands["Volvo"], brands["Saab"]);

            context.Cars.AddOrUpdate(c => c.RegistrationNumber,
                new Car
                {
                    Brand = brands["Volvo"],
                    RegistrationNumber = "ABC123",
                    TopSpeed = 210,
                    Color = "Red"
                },
                new Car
                {
                    Brand = brands["Saab"],
                    RegistrationNumber = "XYZ987",
                    TopSpeed = 250,
                    Color = "Blue"
                });
        }
    }
}
