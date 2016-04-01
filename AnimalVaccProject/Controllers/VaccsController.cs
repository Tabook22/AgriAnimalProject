using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AnimalVaccProject.Models;
using PagedList;

namespace AnimalVaccProject.Controllers
{
    public class VaccsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vaccs
        public ActionResult Index(int? page)
        {
            //var vaccinations = db.vaccinations.Include(t => t.animal).Include(t => t.disease).Include(t => t.dose).Include(t => t.farmer);
            var vaccinations = from v in db.vaccinations
                               join a in db.animals on v.AId equals a.AId
                               join d in db.doses on v.DoseId equals d.DoseId
                               join de in db.diseases on v.DisId equals de.DisId
                               join f in db.farmers on v.FarmerId equals f.FarmerId
                               select new ViewModels.VaccViewModel.VaccViewData {
                                   Id=v.Id,
                                    AgriCert=v.AgriCert,
                                    VaccDate=v.VaccDate,
                                    AId=v.AId,
                                    AnName=a.Name,
                                    DoseId=d.DoseId,
                                    DoseType=d.DoseType,
                                    DisId=de.DisId,
                                    DiseaseType=de.DiseaseType,
                                    TotalNo=v.TotalNo,
                                    FarmerId=v.FarmerId,
                                    Name =f.Name
                               };
            return View(vaccinations.ToList().ToPagedList(page ?? 1, 30));
        }

        // GET: Vaccs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Vacc tbl_Vacc = db.vaccinations.Find(id);
            if (tbl_Vacc == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Vacc);
        }

        // GET: Vaccs/Create
        public ActionResult Create()
        {
            ViewBag.AId = new SelectList(db.animals, "AId", "Name");
            ViewBag.DisId = new SelectList(db.diseases, "DisId", "DiseaseType");
            ViewBag.DoseId = new SelectList(db.doses, "DoseId", "DoseType");
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name");
            return View();
        }

        // POST: Vaccs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AgriCert,VaccDate,AId,DoseId,DisId,TotalNo,FarmerId")] tbl_Vacc tbl_Vacc)
        {
            if (ModelState.IsValid)
            {
                db.vaccinations.Add(tbl_Vacc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AId = new SelectList(db.animals, "AId", "Name", tbl_Vacc.AId);
            ViewBag.DisId = new SelectList(db.diseases, "DisId", "DiseaseType", tbl_Vacc.DisId);
            ViewBag.DoseId = new SelectList(db.doses, "DoseId", "DoseType", tbl_Vacc.DoseId);
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name", tbl_Vacc.FarmerId);
            return View(tbl_Vacc);
        }

        // GET: Vaccs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Vacc tbl_Vacc = db.vaccinations.Find(id);
            if (tbl_Vacc == null)
            {
                return HttpNotFound();
            }
            ViewBag.AId = new SelectList(db.animals, "AId", "Name", tbl_Vacc.AId);
            ViewBag.DisId = new SelectList(db.diseases, "DisId", "DiseaseType", tbl_Vacc.DisId);
            ViewBag.DoseId = new SelectList(db.doses, "DoseId", "DoseType", tbl_Vacc.DoseId);
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name", tbl_Vacc.FarmerId);
            return View(tbl_Vacc);
        }

        // POST: Vaccs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AgriCert,VaccDate,AId,DoseId,DisId,TotalNo,FarmerId")] tbl_Vacc tbl_Vacc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Vacc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AId = new SelectList(db.animals, "AId", "Name", tbl_Vacc.AId);
            ViewBag.DisId = new SelectList(db.diseases, "DisId", "DiseaseType", tbl_Vacc.DisId);
            ViewBag.DoseId = new SelectList(db.doses, "DoseId", "DoseType", tbl_Vacc.DoseId);
            ViewBag.FarmerId = new SelectList(db.farmers, "FarmerId", "Name", tbl_Vacc.FarmerId);
            return View(tbl_Vacc);
        }

        // GET: Vaccs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Vacc tbl_Vacc = db.vaccinations.Find(id);
            if (tbl_Vacc == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Vacc);
        }

        // POST: Vaccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Vacc tbl_Vacc = db.vaccinations.Find(id);
            db.vaccinations.Remove(tbl_Vacc);
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
