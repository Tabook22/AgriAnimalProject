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
    public class WillayatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Willayats
        public ActionResult Index()
        {
            return View(db.willayats.ToList());
        }

        // GET: Willayats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Willayat tbl_Willayat = db.willayats.Find(id);
            if (tbl_Willayat == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Willayat);
        }

        // GET: Willayats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Willayats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WID,WName")] tbl_Willayat tbl_Willayat)
        {
            if (ModelState.IsValid)
            {
                db.willayats.Add(tbl_Willayat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Willayat);
        }

        // GET: Willayats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Willayat tbl_Willayat = db.willayats.Find(id);
            if (tbl_Willayat == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Willayat);
        }

        // POST: Willayats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WID,WName")] tbl_Willayat tbl_Willayat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Willayat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Willayat);
        }

        // GET: Willayats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Willayat tbl_Willayat = db.willayats.Find(id);
            if (tbl_Willayat == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Willayat);
        }

        // POST: Willayats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Willayat tbl_Willayat = db.willayats.Find(id);
            db.willayats.Remove(tbl_Willayat);
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
