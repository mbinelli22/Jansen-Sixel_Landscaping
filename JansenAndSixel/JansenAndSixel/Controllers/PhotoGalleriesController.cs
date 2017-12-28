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
    public class PhotoGalleriesController : Controller
    {
        private DbConnectionContext db = new DbConnectionContext();

        // GET: PhotoGalleries
        public ActionResult Index()
        {
            return View(db.PhotoGallery.ToList());
        }

        // GET: PhotoGalleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGallery photoGallery = db.PhotoGallery.Find(id);
            if (photoGallery == null)
            {
                return HttpNotFound();
            }
            return View(photoGallery);
        }

        // GET: PhotoGalleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhotoGalleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImagePath")] PhotoGallery photoGallery)
        {
            if (ModelState.IsValid)
            {
                db.PhotoGallery.Add(photoGallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photoGallery);
        }

        // GET: PhotoGalleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGallery photoGallery = db.PhotoGallery.Find(id);
            if (photoGallery == null)
            {
                return HttpNotFound();
            }
            return View(photoGallery);
        }

        // POST: PhotoGalleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImagePath")] PhotoGallery photoGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photoGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photoGallery);
        }

        // GET: PhotoGalleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGallery photoGallery = db.PhotoGallery.Find(id);
            if (photoGallery == null)
            {
                return HttpNotFound();
            }
            return View(photoGallery);
        }

        // POST: PhotoGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhotoGallery photoGallery = db.PhotoGallery.Find(id);
            db.PhotoGallery.Remove(photoGallery);
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
