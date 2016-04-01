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
    public class AnimalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Animals
        public ActionResult Index()
        {
            return View(db.animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Animal tbl_Animal = db.animals.Find(id);
            if (tbl_Animal == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AId,Name")] tbl_Animal tbl_Animal)
        {
            if (ModelState.IsValid)
            {
                db.animals.Add(tbl_Animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Animal tbl_Animal = db.animals.Find(id);
            if (tbl_Animal == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AId,Name")] tbl_Animal tbl_Animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Animal tbl_Animal = db.animals.Find(id);
            if (tbl_Animal == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Animal tbl_Animal = db.animals.Find(id);
            db.animals.Remove(tbl_Animal);
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
