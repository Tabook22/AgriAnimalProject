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
    public class NiyabatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Niyabats
        public ActionResult Index()
        {
            var niyabats = db.niyabats.Include(t => t.tbl_Willayst).OrderBy(t => t.WID);
            return View(niyabats.ToList());
        }

        // GET: Niyabats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Niyabat tbl_Niyabat = db.niyabats.Find(id);
            if (tbl_Niyabat == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Niyabat);
        }

        // GET: Niyabats/Create
        public ActionResult Create()
        {
            ViewBag.WID = new SelectList(db.willayats, "WID", "WName");
            return View();
        }

        // POST: Niyabats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NID,NName,WID")] tbl_Niyabat tbl_Niyabat)
        {
            if (ModelState.IsValid)
            {
                db.niyabats.Add(tbl_Niyabat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WID = new SelectList(db.willayats, "WID", "WName", tbl_Niyabat.WID);
            return View(tbl_Niyabat);
        }

        // GET: Niyabats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Niyabat tbl_Niyabat = db.niyabats.Find(id);
            if (tbl_Niyabat == null)
            {
                return HttpNotFound();
            }
            ViewBag.WID = new SelectList(db.willayats, "WID", "WName", tbl_Niyabat.WID);
            return View(tbl_Niyabat);
        }

        // POST: Niyabats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NID,NName,WID")] tbl_Niyabat tbl_Niyabat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Niyabat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WID = new SelectList(db.willayats, "WID", "WName", tbl_Niyabat.WID);
            return View(tbl_Niyabat);
        }

        // GET: Niyabats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Niyabat tbl_Niyabat = db.niyabats.Find(id);
            if (tbl_Niyabat == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Niyabat);
        }

        // POST: Niyabats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Niyabat tbl_Niyabat = db.niyabats.Find(id);
            db.niyabats.Remove(tbl_Niyabat);
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
