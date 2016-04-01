using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalVaccProject.Models;
using PagedList;

namespace AnimalVaccProject.Controllers
{
    public class DiseasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Diseases
        public ActionResult Index(int? page)
        {
           
            return View(db.diseases.ToList().ToPagedList(page ?? 1, 10));
        }

        // GET: Diseases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Disease tbl_Disease = db.diseases.Find(id);
            if (tbl_Disease == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Disease);
        }

        // GET: Diseases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diseases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisId,DiseaseType")] tbl_Disease tbl_Disease)
        {
            if (ModelState.IsValid)
            {
                db.diseases.Add(tbl_Disease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Disease);
        }

        // GET: Diseases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Disease tbl_Disease = db.diseases.Find(id);
            if (tbl_Disease == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Disease);
        }

        // POST: Diseases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisId,DiseaseType")] tbl_Disease tbl_Disease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Disease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Disease);
        }

        // GET: Diseases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Disease tbl_Disease = db.diseases.Find(id);
            if (tbl_Disease == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Disease);
        }

        // POST: Diseases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Disease tbl_Disease = db.diseases.Find(id);
            db.diseases.Remove(tbl_Disease);
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
