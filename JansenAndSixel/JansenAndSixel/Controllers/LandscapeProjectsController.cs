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
    public class LandscapeProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LandscapeProjects
        public ActionResult Index()
        {
            var landscapeProjects = db.LandscapeProjects.Include(l => l.Users);
            return View(landscapeProjects.ToList());
        }

        // GET: LandscapeProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandscapeProject landscapeProject = db.LandscapeProjects.Find(id);
            if (landscapeProject == null)
            {
                return HttpNotFound();
            }
            return View(landscapeProject);
        }

        // GET: LandscapeProjects/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: LandscapeProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,ProjectType,ProjectDiscription")] LandscapeProject landscapeProject)
        {
            if (ModelState.IsValid)
            {
                db.LandscapeProjects.Add(landscapeProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.ApplicationUsers, "Id", "Email", landscapeProject.CustomerId);
            return View(landscapeProject);
        }

        // GET: LandscapeProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandscapeProject landscapeProject = db.LandscapeProjects.Find(id);
            if (landscapeProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.ApplicationUsers, "Id", "Email", landscapeProject.CustomerId);
            return View(landscapeProject);
        }

        // POST: LandscapeProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,ProjectType,ProjectDiscription")] LandscapeProject landscapeProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(landscapeProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.ApplicationUsers, "Id", "Email", landscapeProject.CustomerId);
            return View(landscapeProject);
        }

        // GET: LandscapeProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandscapeProject landscapeProject = db.LandscapeProjects.Find(id);
            if (landscapeProject == null)
            {
                return HttpNotFound();
            }
            return View(landscapeProject);
        }

        // POST: LandscapeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LandscapeProject landscapeProject = db.LandscapeProjects.Find(id);
            db.LandscapeProjects.Remove(landscapeProject);
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
    }
}
