using AnimalVaccProject.Models;
using AnimalVaccProject.ViewModels;
using AgriVaccFinal.Models.EntityManager;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace AnimalVaccProject.Controllers
{
    public class FarmersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //

        //TODO:  Opne the index page and show a list of tbl_Farmer
        public ActionResult Index(string searchBy, string search, int? page)
        {

            if (searchBy == "Id")
            {
                var agrVlts = from f in db.farmers
                              where f.civilId ==search || search==null
                              join w in db.willayats on f.WID equals w.WID
                              join n in db.niyabats on f.NID equals n.NID
                              join v in db.villages on f.VID equals v.VID
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
                //get willayat, Niyabats and villages list, this important because we are filling the dropdownlists in the getFlist.cshtml, 
                //otherwise will we get error of null reference
                ViewBag.frWlst = db.willayats.OrderBy(x => x.WName).ToList();
                ViewBag.FrNlst = db.niyabats.OrderBy(x => x.NName).ToList();
                ViewBag.frVlst = db.villages.OrderBy(x => x.VName).ToList();
                //total Farmers
                ViewBag.TotalFarmers = db.farmers.OrderBy(x => x.Name).Count();
                return View(agrVlts.ToList().ToPagedList(page ?? 1,30));
            }

            else
            {
                var agrVlts = from f in db.farmers
                              where f.Name.StartsWith(search) || search==null
                              join w in db.willayats on f.WID equals w.WID
                              join n in db.niyabats on f.NID equals n.NID
                              join v in db.villages on f.VID equals v.VID
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
                //get willayat, Niyabats and villages list, this important because we are filling the dropdownlists in the getFlist.cshtml, 
                //otherwise will we get error of null reference
                ViewBag.frWlst = db.willayats.OrderBy(x => x.WName).ToList();
                ViewBag.FrNlst = db.niyabats.OrderBy(x => x.NName).ToList();
                ViewBag.frVlst = db.villages.OrderBy(x => x.VName).ToList();
                //total Farmers
                ViewBag.TotalFarmers = db.farmers.OrderBy(x => x.Name).Count();
                return View(agrVlts.ToList().ToPagedList(page ?? 1, 30));
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FarmerDataView frm)
        {
            return View();
        }

        //TODO: add new Farmer
        [HttpPost]
        public ActionResult AddNewFarmer(string frName, string civilID, int WID, int NID, int VID, string Tel, string Job)
        {
            //check to see if the willayt name exists or not
            FarmerManager FM = new FarmerManager();
            if (!FM.IsFarmerExist(civilID))
            {
                tbl_Farmer addFarmer = new tbl_Farmer();
                addFarmer.Name = frName;
                addFarmer.civilId = civilID;
                addFarmer.WID = WID;
                addFarmer.NID = NID;
                addFarmer.VID = VID;
                addFarmer.Tel = Tel;
                addFarmer.Job = Job;

                db.farmers.Add(addFarmer);
                db.SaveChanges();
                ViewBag.Message = "لقد تم إضافة البيانات بنجاح";
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "لقد تم إضافة البيانات بنجاح" }, JsonRequestBehavior.AllowGet);
            }
            //  ModelState.AddModelError(String.Empty, "إسم الولاية مسجل من قبل الرجاء مراجة الإسم مرة أخرى");
            ViewBag.Message = "لم يتم إضافة البيانات الرجاء التأكد من الرقم المدني و أعد المحاولة مرة أخرى";
            return RedirectToAction("Index");
            //return Json(new { success = false, message = "لم يتم إضافة البيانات الرجاء التأكد من الرقم المدني و أعد المحاولة مرة أخرى" });
        }

        //TODO: Update Farmer
        [HttpPost]
        public JsonResult UpdateFarmer(int id, string name, string cid, int wlt, int nbt, int vlg, string tel, string job)
        {
            ;
            //check to see if the willayt name exists or not
            FarmerManager FM = new FarmerManager();
            if (!FM.IsFarmerExist(id, cid))
            {
                FarmerDataView FDV = new FarmerDataView();
                FDV.FarmerId = id;
                FDV.Name = name;
                FDV.civilId = cid;
                FDV.WID = wlt;
                FDV.NID = nbt;
                FDV.VID = vlg;
                FDV.Tel = tel;
                FDV.Job = job;
                FM.UpdateFarmerData(FDV);
                //var json_string  = "{ success: \"true\" }";

                return Json(new { success = true, message = "لقد تم تحديث البيانات بنجاح" }, JsonRequestBehavior.AllowGet);
                //return Json(new { success = true });
            }
            //  ModelState.AddModelError(String.Empty, "إسم الولاية مسجل من قبل الرجاء مراجة الإسم مرة أخرى");

            return Json(new { success = false, message = "لم يتم تحديث البيانات إسم القرية مسجل من قبل الرجاء المحاولة مرة أخرى" });
        }

        //TODO: Showing the list of Farmers in the index page
        public ActionResult getFList(string searchBy, string search, int? page)
        {
            // var n = new NiyabtDataView();

            var agrVlts = from f in db.farmers
                          join w in db.willayats on f.WID equals w.WID
                          join n in db.niyabats on f.NID equals n.NID
                          join v in db.villages on f.VID equals v.VID
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
            return PartialView("_FarmerList", agrVlts.ToList().ToPagedList(page ?? 1, 3));
        }

        //TODO: Getting the Niyabats Name based on Willayat ID
        [HttpPost]
        public JsonResult getNiyabatlst(int WID)
        {

            bool anyNybt = db.niyabats.Where(x => x.WID.Equals(WID)).Any();

            if (!anyNybt == false)
            {
                var Nybtlst = from n in db.niyabats
                              where n.WID == WID
                              select new NiyabtDataView
                              {
                                  NID = n.NID,
                                  NName = n.NName
                              };

                return Json(Nybtlst, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new { success = false, message = "لا توجد نيابة تحمل هذا الإسم" }, JsonRequestBehavior.AllowGet);
            }



        }


        //TODO: Search for a village
        public JsonResult FindFarmer(string flName)
        {
            bool getFarmer = db.farmers.Where(x => x.Name.Contains(flName)).Any();
            if (!getFarmer == false)
            {
                var agrFarlst = from f in db.farmers
                                where f.Name.Contains(flName)
                                join w in db.willayats on f.WID equals w.WID
                                join n in db.niyabats on f.NID equals n.NID
                                join v in db.villages on f.VID equals v.VID
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
                return Json(new { agrFarlst }, JsonRequestBehavior.AllowGet);
                //return Json(new { success = true, agrVlts }, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new { success = false, message = "لا يوجد مربي يحمل هذا الإسم" }, JsonRequestBehavior.AllowGet);
            }

        }

        //TODO: Getting the Niyabats Name based on Willayat ID
        [HttpPost]
        public JsonResult getVillageslst(int NID)
        {
            bool anyVybt = db.niyabats.Where(x => x.NID.Equals(NID)).Any();

            if (!anyVybt == false)
            {
                var Vybtlst = from v in db.villages
                              where v.NID == NID
                              select new VillageDataView
                              {
                                  VID = v.VID,
                                  VName = v.VName
                              };

                return Json(Vybtlst, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new { success = false, message = "لا توجد قرية تحمل هذا الإسم" }, JsonRequestBehavior.AllowGet);
            }
        }
        //

        //TODO: Delete Farmer
        [HttpPost]
        public JsonResult DeleteFarmer(int? ID)
        {
            if (ID == null)
            {
                return Json(new { success = false, message = "هناك خطاء في عملية الحذف" }, JsonRequestBehavior.AllowGet);
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Farmer farmer = db.farmers.Find(ID);

            db.farmers.Remove(farmer);
            db.SaveChanges();
            return Json(new { success = true, message = "لقد تم حذف البيانات بنجاح" }, JsonRequestBehavior.AllowGet);
        }

    }
}