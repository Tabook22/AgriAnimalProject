using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalVaccProject.Models;
using AgriVaccFinal.Models.EntityManager;

namespace AnimalVaccProject.Controllers
{
    public class AgriCertsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AgriCerts
        public ActionResult Index()
        {
            var agricerts = db.agricerts.Include(t => t.farmer);
            return View(agricerts.ToList());
        }

        // GET: AgriCerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_AgriCert tbl_AgriCert = db.agricerts.Find(id);
            if (tbl_AgriCert == null)
            {
                return HttpNotFound();
            }
            return View(tbl_AgriCert);
        }

        // GET: AgriCerts/Create
        public ActionResult Create()
        {
            ViewBag.FarmerId = new SelectList(db.farmers.OrderBy(x => x.Name), "FarmerId", "Name");
            return View();
        }

        // POST: AgriCerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgriCertId,AgriCertNo,Type,IssueDate,ExpDate,FarmerId")] tbl_AgriCert tbl_AgriCert)
        {
            //check to see if the willayt name exists or not
            FarmerManager FM = new FarmerManager();

            if (ModelState.IsValid)
            {
                if (!FM.IsAgriCertiExist(tbl_AgriCert.Type,tbl_AgriCert.AgriCertNo))
                {
                    db.agricerts.Add(tbl_AgriCert);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name", tbl_AgriCert.FarmerId);
            ViewBag.Error = "لم يتم حفظ البيانات الرجاء مراجعة رقم الحيازة و بقية البيانات";
            return View(tbl_AgriCert);
        }

        // GET: AgriCerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_AgriCert tbl_AgriCert = db.agricerts.Find(id);
            if (tbl_AgriCert == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name", tbl_AgriCert.FarmerId);
            return View(tbl_AgriCert);
        }

        // POST: AgriCerts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgriCertId,AgriCertNo,Type,IssueDate,ExpDate,FarmerId")] tbl_AgriCert tbl_AgriCert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_AgriCert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name", tbl_AgriCert.FarmerId);
            return View(tbl_AgriCert);
        }

        // GET: AgriCerts/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_AgriCert tbl_AgriCert = db.agricerts.Find(id);
        //    if (tbl_AgriCert == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_AgriCert);
        //}

        // POST: AgriCerts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            tbl_AgriCert tbl_AgriCert = db.agricerts.Find(id);
            //tbl_AgriCert getFrm = new tbl_AgriCert();
            string agrno = tbl_AgriCert.AgriCertNo;
            if (tbl_AgriCert.Type=="حائز أساسي")
            {
                //db.agricerts
                //    .Where(q => q.AgriCertNo ==agrno)
                //    .ForEach(q => q.AgriCertNo.RemoveAll(o => o.Value == null));

                var getFrm = from a in db.agricerts
                         where a.AgriCertNo == agrno
                         select a;

                db.agricerts.Remove(getFrm);
                db.SaveChanges();
            }
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
