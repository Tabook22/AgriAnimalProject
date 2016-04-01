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
    public class DosesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doses
        public ActionResult Index()
        {
            return View(db.doses.ToList());
        }

        // GET: Doses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Dose tbl_Dose = db.doses.Find(id);
            if (tbl_Dose == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Dose);
        }

        // GET: Doses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoseId,DoseType")] tbl_Dose tbl_Dose)
        {
            if (ModelState.IsValid)
            {
                db.doses.Add(tbl_Dose);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Dose);
        }

        // GET: Doses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Dose tbl_Dose = db.doses.Find(id);
            if (tbl_Dose == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Dose);
        }

        // POST: Doses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoseId,DoseType")] tbl_Dose tbl_Dose)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Dose).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Dose);
        }

        // GET: Doses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Dose tbl_Dose = db.doses.Find(id);
            if (tbl_Dose == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Dose);
        }

        // POST: Doses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Dose tbl_Dose = db.doses.Find(id);
            db.doses.Remove(tbl_Dose);
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
