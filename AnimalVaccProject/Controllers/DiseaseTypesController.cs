using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalVaccProject.Models;

namespace AnimalVaccProject.Controllers
{
    public class DiseaseTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DiseaseTypes
        public ActionResult Index()
        {
            return View(db.diseasetypes.ToList());
        }

        // GET: DiseaseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseType diseaseType = db.diseasetypes.Find(id);
            if (diseaseType == null)
            {
                return HttpNotFound();
            }
            return View(diseaseType);
        }

        // GET: DiseaseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiseaseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DType")] DiseaseType diseaseType)
        {
            if (ModelState.IsValid)
            {
                db.diseasetypes.Add(diseaseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diseaseType);
        }

        // GET: DiseaseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseType diseaseType = db.diseasetypes.Find(id);
            if (diseaseType == null)
            {
                return HttpNotFound();
            }
            return View(diseaseType);
        }

        // POST: DiseaseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DType")] DiseaseType diseaseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diseaseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diseaseType);
        }

        // GET: DiseaseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseType diseaseType = db.diseasetypes.Find(id);
            if (diseaseType == null)
            {
                return HttpNotFound();
            }
            return View(diseaseType);
        }

        // POST: DiseaseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiseaseType diseaseType = db.diseasetypes.Find(id);
            db.diseasetypes.Remove(diseaseType);
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
