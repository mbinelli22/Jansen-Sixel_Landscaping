using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JansenAndSixel.Models;

namespace JansenAndSixel.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,ZipCode,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,ZipCode,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult MyProfile()
        {
            return View();
        }

        public ActionResult PhotoGallery()
        {
            return View();
        }

        public ActionResult CustomProject()
        {
            return View();
        }

        public ActionResult FullCalendar()
        {
            return View();
        }

        //Landscaping>>>>>>>>>>>>>>>

        public ActionResult LandscapingPage()
        {
            return View();
        }

        public ActionResult BedEdging()
        {
            return View();
        }

        public ActionResult Mulching()
        {
            return View();
        }

        public ActionResult TreeAndShrubPlantingAndRemoval()
        {
            return View();
        }
        public ActionResult TreePruning()
        {
            return View();
        }

        public ActionResult FlowerGardens()
        {
            return View();
        }

        public ActionResult ErosionControl()
        {
            return View();
        }

        public ActionResult TopSoilDeliveries()
        {
            return View();
        }

        public ActionResult PowerWashing()
        {
            return View();
        }

        public ActionResult GutterCleaning()
        {
            return View();
        }

        public ActionResult StumpGrinding()
        {
            return View();
        }

        public ActionResult LawnInstallation()
        {
            return View();
        }

        //Hardscaping>>>>>>>>>>>>>>>>>>>>>

        public ActionResult HardscapingPage()
        {
            return View();
        }

        public ActionResult Patios()
        {
            return View();
        }

        public ActionResult DecorativeStone()
        {
            return View();
        }

        public ActionResult RockGardens()
        {
            return View();
        }

        public ActionResult Ponds()
        {
            return View();
        }

        public ActionResult WaterwayFeatures()
        {
            return View();
        }


        public ActionResult Walls()
        {
            return View();
        }


        public ActionResult Walkways()
        {
            return View();
        }

        //Property Maintenance>>>>>>>>>>>>>>>>>>>>

        public ActionResult PropertyMaintenance()
        {
            return View();
        }

        //Snow Removal>>>>>>>>>>>>>>>>

        public ActionResult SnowRemoval()
        {
            return View();
        }
    }
}
