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

                if (projectType.TypeOfProject == "Landscape")
                {
                    return RedirectToAction("CreateLandscapeProject");
                }
                else if (projectType.TypeOfProject == "Hardscape")
                {
                    return RedirectToAction("CreateHardscapeProject");
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


        //Get Create Landscaping Project
        public ActionResult CreateLandscapeProject()
        {
            return View();
        }

        //Post Create Landscaping Project
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLandscapeProject([Bind(Include = "Id, Name, TypeOfLandscapeProject")] CustomProject customProject)
        {
            if (ModelState.IsValid)
            {
                db.CustomProjects.Add(customProject);
                db.SaveChanges();
                var landscapeType = new CustomProject { TypeOfLandscapeProject = customProject.TypeOfLandscapeProject };
                db.CustomProjects.Add(landscapeType);
                db.SaveChanges();

                if(landscapeType.TypeOfLandscapeProject == "Bed Edging")
                {
                    return RedirectToAction("BedEdging");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Mulching")
                {
                    return RedirectToAction("Mulching");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Tree/ Shrub Planting/Removal")
                {
                    return RedirectToAction("TreeShrubPlantingRemoval");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Tree Pruning")
                {
                    return RedirectToAction("TreePruning");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Flower Gardens")
                {
                    return RedirectToAction("FlowerGardens");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Erosion Control")
                {
                    return RedirectToAction("ErosionConrol");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Top Soil Delivery")
                {
                    return RedirectToAction("TopSoilDelivery");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Power Washing")
                {
                    return RedirectToAction("PowerWashing");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Gutter Cleaning")
                {
                    return RedirectToAction("GutterCleaning");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Stump Grinding")
                {
                    return RedirectToAction("StupmpGrinding");
                }
                else if(landscapeType.TypeOfLandscapeProject == "Lawn Installation")
                {
                    return RedirectToAction("LawnInstallation");
                }
                else
                {
                    return CreateLandscapeProject();
                }
               
            }
            return CreateLandscapeProject();
        }

        //Get Create Hardscaping Project
        public ActionResult CreateHardscapeProject()
        {
            return View();
        }

        //Post Create Hardscaping Project
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHardscapeProject([Bind(Include = "Id, Name, TypeOfHardscapeProject")] CustomProject customProject)
        {

        }

    }
}
