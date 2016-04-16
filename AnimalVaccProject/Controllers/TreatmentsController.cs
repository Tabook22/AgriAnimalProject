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
    public class TreatmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Treatments
        public ActionResult Index(int? page)
        {
            //var vaccinations = db.vaccinations.Include(t => t.animal).Include(t => t.disease).Include(t => t.dose).Include(t => t.farmer);
            var treatments = from v in db.treatments
                               join f in db.farmers on v.FarmerId equals f.FarmerId
                               select new ViewModels.TreatViewData
                               {
                                   Id = v.Id,
                                   AgriCert = v.AgriCert,
                                   TreDate = v.TreDate,
                                   FarmerId = v.FarmerId,
                                   Name = f.Name
                               };
            return View(treatments.ToList().ToPagedList(page ?? 1, 30));
            return View(db.treatments.ToList());
        }

        // GET: Treatments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Treatment tbl_Treatment = db.treatments.Find(id);
            if (tbl_Treatment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Treatment);
        }

        // GET: Treatments/Create
        public ActionResult Create()
        {
            ViewBag.SampleType = new SelectList(db.sampletypes, "Id", "Name");
            ViewBag.AnimalType = new SelectList(db.animals, "AId", "Name");
            ViewBag.DiseaseType= new SelectList(db.diseases.Where(x => x.catId == 2), "DisId", "DiseaseType");
            //ViewBag.DoseId = new SelectList(db.doses, "DoseId", "DoseType");
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name");
            return View();
        }

        // POST: Treatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FarmerId,AgriCert,TreDate,AnimalType,DiseaseType,TreType,TotalNo,SampleType")] tbl_Treatment tbl_Treatment)
        {
            if (ModelState.IsValid)
            {
                db.treatments.Add(tbl_Treatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Treatment);
        }

        // GET: Treatments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Treatment tbl_Treatment = db.treatments.Find(id);
            if (tbl_Treatment == null)
            {
                return HttpNotFound();
            }

            ViewBag.SampleType = new SelectList(db.sampletypes, "Id", "Name",tbl_Treatment.SampleType);
            ViewBag.AId = new SelectList(db.animals, "AId", "Name", tbl_Treatment.AnimalType);
            ViewBag.DisId = new SelectList(db.diseases.Where(x => x.catId == 2), "DisId", "DiseaseType",tbl_Treatment.DiseaseType);
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name", tbl_Treatment.FarmerId);
            return View(tbl_Treatment);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FarmerId,AgriCert,TreDate,AnimalType,DiseaseType,TreType,TotalNo,SampleType")] tbl_Treatment tbl_Treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Treatment);
        }

        // GET: Treatments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Treatment tbl_Treatment = db.treatments.Find(id);
            if (tbl_Treatment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Treatment);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Treatment tbl_Treatment = db.treatments.Find(id);
            db.treatments.Remove(tbl_Treatment);
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
