using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestLib.Entities;

namespace MvcApplication.Controllers
{ 
    public class CarController : Controller
    {
        private CarsContext db = new CarsContext();

        //
        // GET: /Car/

        public ViewResult Index()
        {
            var cars = db.Cars.Include(c => c.Brand);
            return View(cars.ToList());
        }

        //
        // GET: /Car/Details/5

        public ViewResult Details(int id)
        {
            Car car = db.Cars.Find(id);
            return View(car);
        }

        //
        // GET: /Car/Create

        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name");
            return View();
        } 

        //
        // POST: /Car/Create

        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", car.BrandId);
            return View(car);
        }
        
        //
        // GET: /Car/Edit/5
 
        public ActionResult Edit(int id)
        {
            Car car = db.Cars.Find(id);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", car.BrandId);
            return View(car);
        }

        //
        // POST: /Car/Edit/5

        [HttpPost]
public ActionResult Edit(Car car)
{
    if (ModelState.IsValid)
    {
        db.Entry(car).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", car.BrandId);
    return View(car);
}

        //
        // GET: /Car/Delete/5
 
        public ActionResult Delete(int id)
        {
            Car car = db.Cars.Find(id);
            return View(car);
        }

        //
        // POST: /Car/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}