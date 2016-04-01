using System.Collections.Generic;
using System.Linq;
using AnimalVaccProject.ViewModels;
using AnimalVaccProject.Models;

namespace AgriVaccFinal.Models.EntityManager
{
    class FarmerManager
    {

        //TODO: Add New Farmer.
        public void AddFarmer(addNewFarmer Flt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                tbl_Farmer FL = new tbl_Farmer();
                FL.Name = Flt.Name;
                FL.civilId = Flt.civilId;
                FL.Tel = Flt.Tel;
                FL.Job = Flt.Job;
                FL.WID = Flt.WID;
                FL.NID = Flt.NID;
                FL.VID = Flt.VID;

                db.farmers.Add(FL);
                db.SaveChanges();
            }
        }

        //here we only checking the existance of the civialid, this done only when we only updating record, we check if the current civilid is equal to the added civilid
        public bool IsFarmerExist(int id, string cid)
        {
            bool Sresult = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //first we are going to delete all the details of farmer
                //tbl_Farmer frm = db.farmers.Find(id);
                //db.farmers.Remove(frm);
                // db.SaveChanges();
                string getCid = db.farmers.Where(x => x.FarmerId == id).First().civilId;
                if (getCid == cid)
                {
                    Sresult = false;
                }
                else
                {
                    bool getCount = db.farmers.Where(f => f.civilId == cid).Any();

                    if (getCount == true)
                    {
                        Sresult = true;
                    }
                    else
                    {
                        Sresult = false;
                    }
                }
                return Sresult;
            }
        }

        //here we only checking the existance of the civial id, this done only when we only adding a new record
        public bool IsFarmerExist(string cid)
        {
            bool Sresult = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Sresult = db.farmers.Where(f => f.civilId == cid).Any(); //check to see if there is any farmers with the same civil id
                return Sresult;
            }
        }

        //TODO: Get FarmerId based up the Farmer Name
        public int GetFarmerID(string txtName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var farmer = db.farmers.Where(f => f.Name.Equals(txtName));
                if (farmer.Any()) // if there is any result, even only one
                    return farmer.FirstOrDefault().VID;
            }
            return 0;
        }


        //TODO: Get All the Farmers based on Willayat Id, or Niyabat Id or Village Id
        public List<FarmerDataView> GetAllFarmers(int ID2, string locType)
        {
            List<FarmerDataView> Farmerprofile = new List<FarmerDataView>();
            FarmerDataView FDV = new FarmerDataView();
            switch (locType)
            {

                case "willayat":
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        var myFar = db.farmers.Where(f => f.WID == ID2).OrderBy(f => f.Name).ToList();

                        foreach (var item in myFar)
                        {
                            FDV.Name = item.Name;
                            FDV.civilId = item.civilId;
                            FDV.Tel = item.Tel;
                            FDV.Job = item.Job;
                            FDV.WID = item.WID;
                            FDV.NID = item.NID;
                            FDV.VID = item.VID;
                            // adding the new farmer to the list of farmers
                            Farmerprofile.Add(FDV);
                        }
                    }
                    break;
                case "niyabat":
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        var myFar = db.farmers.Where(f => f.NID == ID2).OrderBy(f => f.Name).ToList();

                        foreach (var item in myFar)
                        {
                            FDV.Name = item.Name;
                            FDV.civilId = item.civilId;
                            FDV.Tel = item.Tel;
                            FDV.Job = item.Job;
                            FDV.WID = item.WID;
                            FDV.NID = item.NID;
                            FDV.VID = item.VID;
                            // adding the new farmer to the list of farmers
                            Farmerprofile.Add(FDV);
                        }
                    }
                    break;
                case "village":
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        var myFar = db.farmers.Where(f => f.VID == ID2).OrderBy(f => f.Name).ToList();

                        foreach (var item in myFar)
                        {
                            FDV.Name = item.Name;
                            FDV.civilId = item.civilId;
                            FDV.Tel = item.Tel;
                            FDV.Job = item.Job;
                            FDV.WID = item.WID;
                            FDV.NID = item.NID;
                            FDV.VID = item.VID;
                            // adding the new farmer to the list of farmers
                            Farmerprofile.Add(FDV);
                        }
                    }
                    break;
            }
            return Farmerprofile;
        }

        //TODO: Update Farmer data
        public void UpdateFarmerData(FarmerDataView flt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tbl_Farmer FU = db.farmers.Find(flt.FarmerId);

                        FU.Name = flt.Name;
                        FU.civilId = flt.civilId;
                        FU.Tel = flt.Tel;
                        FU.Job = flt.Job;
                        FU.WID = flt.WID;
                        FU.NID = flt.NID;
                        FU.VID = flt.VID;

                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        //Check to see if the Agriculture certificate is exists or not
        public bool IsAgriCertiExist(string frmtype, string acrt)
        {
            //here am going to check to see if the frmtype is "حائز ملحق" because that means i can add him to another framer and make them share the same agricertificate
            bool Sresult = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (frmtype=="حائز ملحق")
                {
                    Sresult = false;
                }
                else
                {
  Sresult = db.agricerts .Where(a=>a.AgriCertNo == acrt).Any(); //check to see if there is any farmers with the same civil id
                }
              
                return Sresult;
            }
        }
    }
}
