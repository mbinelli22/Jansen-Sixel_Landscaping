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
    public class CustomProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomProjects
        public ActionResult Index()
        {
            return View(db.CustomProjects.ToList());
        }

        // GET: CustomProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomProject customProject = db.CustomProjects.Find(id);
            if (customProject == null)
            {
                return HttpNotFound();
            }
            return View(customProject);
        }

        // GET: CustomProjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TypeOfProject")] CustomProject customProject)
        {
            if (ModelState.IsValid)
            {
                db.CustomProjects.Add(customProject);
                db.SaveChanges();

                var projectType = new CustomProject { TypeOfProject = customProject.TypeOfProject };
                db.CustomProjects.Add(projectType);
                db.SaveChanges();

                    if(projectType.TypeOfProject == "Landscape")
                    {
                        return RedirectToAction("Create1");
                    }
                    else if(projectType.TypeOfProject == "Hardscape")
                    {
                        return RedirectToAction("Create2");
                    }
            }

            return View(customProject);
        }

        // GET: CustomProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomProject customProject = db.CustomProjects.Find(id);
            if (customProject == null)
            {
                return HttpNotFound();
            }
            return View(customProject);
        }

        // POST: CustomProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TypeOfProject,TypeOfLandscapeProject,TypeOfHardscapeProject,TypeOfMaterial,QuantityOfMaterial,Location")] CustomProject customProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customProject);
        }

        // GET: CustomProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomProject customProject = db.CustomProjects.Find(id);
            if (customProject == null)
            {
                return HttpNotFound();
            }
            return View(customProject);
        }

        // POST: CustomProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomProject customProject = db.CustomProjects.Find(id);
            db.CustomProjects.Remove(customProject);
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
