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
    public class SampleTestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SampleTest
        public ActionResult Index(string searchBy, string search, int? page)
        {
            var agrVlts = from s in db.samples
                          join 
                          orderby f.Name
                          select new FarmerDataView
                          {
                              FarmerId = f.FarmerId,
                              Name = f.Name,
                              civilId = f.civilId,
                              WID = n.WID,
                              WName = w.WName,
                              NID = n.NID,
                              NName = n.NName,
                              VID = v.VID,
                              VName = v.VName,
                              Tel = f.Tel,
                              Job = f.Job
                          };

            return View(db.samples.ToList());
        }

        // GET: SampleTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Sample tbl_Sample = db.samples.Find(id);
            if (tbl_Sample == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Sample);
        }

        // GET: SampleTest/Create
        public ActionResult Create()
        {
            ViewBag.SampleType = new SelectList(db.sampletypes, "Id", "Name");
            ViewBag.AId = new SelectList(db.animals, "AId", "Name");
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name");
            return View();
        }

        // POST: SampleTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FarmerId,AgriCert,SampleDate,TestDetails,SampleType,SampleNo,Results")] tbl_Sample tbl_Sample)
        {
            // here is one approach
            Random rand = new Random((int)DateTime.Now.Ticks);
            int RandomNumber;
            RandomNumber = rand.Next(100000, 999999);


            int CharCode = rand.Next(Convert.ToInt32('a'), Convert.ToInt32('z'));
            char RandomChar = Convert.ToChar(CharCode);

            var getRandom = Convert.ToString(CharCode);

            var getCYear = DateTime.Now.Year.ToString();//get current year
                getCYear = getCYear.Substring(2);
            var getCMonth = DateTime.Now.Month.ToString();
            if (ModelState.IsValid)
            {
                tbl_Sample.SampleNo = Convert.ToString(tbl_Sample.FarmerId) +"-"+ getCYear+"-"+ getCMonth+getRandom +"-"+ RandomChar;
                db.samples.Add(tbl_Sample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Sample);
        }

        // GET: SampleTest/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Sample tbl_Sample = db.samples.Find(id);
            if (tbl_Sample == null)
            {
                return HttpNotFound();
            }
            ViewBag.SampleType = new SelectList(db.sampletypes, "Id", "Name", tbl_Sample.FarmerId);
            //ViewBag.AId = new SelectList(db.animals, "AId", "Name");
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name", tbl_Sample.FarmerId);
            return View(tbl_Sample);
        }

        // POST: SampleTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FarmerId,AgriCert,SampleDate,TestDetails,SampleType,SampleNo,Results")] tbl_Sample tbl_Sample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Sample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Sample);
        }

        // GET: SampleTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Sample tbl_Sample = db.samples.Find(id);
            if (tbl_Sample == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Sample);
        }

        // POST: SampleTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Sample tbl_Sample = db.samples.Find(id);
            db.samples.Remove(tbl_Sample);
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
