using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Entities;
using System.Transactions;
using System.Data.Entity;
using System.Diagnostics;
using TestLib.Migrations;

namespace TestLibTests
{
    [TestClass]
    public class EntitiesTests
    {
        [TestMethod]
        public void TestStoreBrand()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                Brand volvo = new Brand { Name = "Volvo" };
                context.Brands.Add(volvo);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestStoreCar()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                Brand volvo = new Brand { Name = "Volvo" };
                Car myVolvo = new Car
                {
                    Brand = volvo,
                    RegistrationNumber = "ABC123"
                };

                context.Cars.Add(myVolvo);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestChangeTracking()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                Debug.WriteLine("Reading people...");
                var people = context.People.ToArray();
                Debug.WriteLine(string.Format("Type of people[0] is {0}",
                    people[0].GetType().ToString()));

                Debug.WriteLine("Updating birth year of first person...");
                people[0].BirthYear = 1965;

                Debug.WriteLine("Saving changes...");
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestSeed()
        {
            Configuration.Seed();
        }

        [TestMethod]
        public void TestNavigationAndForeignKeySetKey()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                var brands = context.Brands.Include(b => b.Cars).OrderBy(b => b.BrandId);
                var car = brands.First().Cars.First();

                Debug.WriteLine("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name);
                Brand newBrand = brands.Skip(1).First();
                Debug.WriteLine(string.Format("Setting BrandId to {0}", newBrand.BrandId));
                car.BrandId = newBrand.BrandId;
                Debug.WriteLine(string.Format("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name));

                Debug.WriteLine("Saving Changes...");
                context.SaveChanges();
                Debug.WriteLine(string.Format("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name));
            }
        }

        [TestMethod]
        public void TestNavigationAndForeignKeySetNavigationProperty()
        { 
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                var brands = context.Brands.Include(b => b.Cars).OrderBy(b => b.BrandId);
                var car = brands.First().Cars.First();

                Debug.WriteLine("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name);
                Brand newBrand = brands.Skip(1).First();
                Debug.WriteLine(string.Format("Setting Brand to {0}", newBrand.Name));
                car.Brand = newBrand;
                Debug.WriteLine(string.Format("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name));

                Debug.WriteLine("Saving Changes...");
                context.SaveChanges();
                Debug.WriteLine(string.Format("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name));
            }
        }

        [TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void TestNavigationAndForeignKeyConflictingChanges()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                var brands = context.Brands.Include(b => b.Cars).OrderBy(b => b.BrandId);
                var car = brands.First().Cars.First();

                Debug.WriteLine("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name);
                Brand newBrand = brands.Skip(1).First();
                int newBrandId = brands.Skip(2).First().BrandId;

                Debug.WriteLine(string.Format("Setting Brand to {0}", newBrand.Name));
                car.Brand = newBrand;
                Debug.WriteLine(string.Format("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name));

                Debug.WriteLine(string.Format("Setting BrandId to {0}", newBrandId));
                car.BrandId = newBrandId;
                Debug.WriteLine(string.Format("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name));

                Debug.WriteLine("Saving Changes...");
                context.SaveChanges();
                Debug.WriteLine(string.Format("The car has BrandId {0} pointing to Brand \"{1}\"",
                    car.BrandId, car.Brand.Name));
            }
        }

        [TestMethod]
        public void TestNavigationAndForeignKeySetKeyWithProxy()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                var genders = context.Genders.Include(g => g.People).OrderBy(g => g.GenderId);
                var person = genders.First().People.First();

                Debug.WriteLine("The person has GenderId {0} pointing to Gender \"{1}\"",
                    person.GenderId, person.Gender.Description);
                Gender newGender = genders.Skip(1).First();
                Debug.WriteLine(string.Format("Setting GenderId to {0}", newGender.GenderId));
                person.GenderId = newGender.GenderId;
                Debug.WriteLine("The person has GenderId {0} pointing to Gender \"{1}\"",
                    person.GenderId, person.Gender.Description);

                Debug.WriteLine("Saving Changes...");
                context.SaveChanges();
                Debug.WriteLine("The person has GenderId {0} pointing to Gender \"{1}\"",
                    person.GenderId, person.Gender.Description);
            }
        }

        [TestMethod]
        public void TestNavigationAndForeignKeySetNavigationPropertyWithProxy()
        {
            using (TransactionScope ts = new TransactionScope())
            using (CarsContext context = new CarsContext())
            {
                var genders = context.Genders.Include(g => g.People).OrderBy(g => g.GenderId);
                var person = genders.First().People.First();

                Debug.WriteLine("The person has GenderId {0} pointing to Gender \"{1}\"",
                    person.GenderId, person.Gender.Description);
                Gender newGender = genders.Skip(1).First();
                Debug.WriteLine(string.Format("Setting Gender to {0}", newGender.Description));
                person.Gender = newGender;
                Debug.WriteLine("The person has GenderId {0} pointing to Gender \"{1}\"",
                    person.GenderId, person.Gender.Description);

                Debug.WriteLine("Saving Changes...");
                context.SaveChanges();
                Debug.WriteLine("The person has GenderId {0} pointing to Gender \"{1}\"",
                    person.GenderId, person.Gender.Description);
            }
        }
    }
}
