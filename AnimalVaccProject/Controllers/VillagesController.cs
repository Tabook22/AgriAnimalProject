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
    public class VillagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Villages
        public ActionResult Index()
        {
            var villages = db.villages.Include(t => t.niyabat).OrderBy(t=>t.NID);
            return View(villages.ToList());
        }

        // GET: Villages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Village tbl_Village = db.villages.Find(id);
            if (tbl_Village == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Village);
        }

        // GET: Villages/Create
        public ActionResult Create()
        {
            ViewBag.NID = new SelectList(db.niyabats, "NID", "NName");
            return View();
        }

        // POST: Villages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VID,VName,NID")] tbl_Village tbl_Village)
        {
            if (ModelState.IsValid)
            {
                db.villages.Add(tbl_Village);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NID = new SelectList(db.niyabats, "NID", "NName", tbl_Village.NID);
            return View(tbl_Village);
        }

        // GET: Villages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Village tbl_Village = db.villages.Find(id);
            if (tbl_Village == null)
            {
                return HttpNotFound();
            }
            ViewBag.NID = new SelectList(db.niyabats, "NID", "NName", tbl_Village.NID);
            return View(tbl_Village);
        }

        // POST: Villages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VID,VName,NID")] tbl_Village tbl_Village)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Village).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NID = new SelectList(db.niyabats, "NID", "NName", tbl_Village.NID);
            return View(tbl_Village);
        }

        // GET: Villages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Village tbl_Village = db.villages.Find(id);
            if (tbl_Village == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Village);
        }

        // POST: Villages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Village tbl_Village = db.villages.Find(id);
            db.villages.Remove(tbl_Village);
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
