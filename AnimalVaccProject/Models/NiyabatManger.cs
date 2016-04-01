using AnimalVaccProject.Models;
using AnimalVaccProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgriVaccFinal.Models.EntityManager
{
    public class NiyabatManger
    {
        //TODO: The AddNiyabat() is a method that inserts data to the database using Entity Framework.
        public void AddNiyabat(addNewNiyabat Nlt)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                tbl_Niyabat NL = new tbl_Niyabat();
                NL.NName = Nlt.NName;
                NL.WID = Nlt.WID;

                db.niyabats.Add(NL);
                db.SaveChanges();
            }
        }

        //TODO: Check if there is any willayat befor adding a new one
        public bool IsNiyabatExist(string txtName, int ID2)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.niyabats.Where(o => o.NName.Equals(txtName) & o.WID.Equals(ID2)).Any(); // the Any() checks at least for one match and it return true if it found one, or false if it not
            }
        }

        //TODO: overloading the same function with different signature
        public bool IsNiyabatExist(int NID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.niyabats.Where(o => o.NID.Equals(NID)).Any(); // the Any() checks at least for one match and it return true if it found one, or false if it not
            }
        }

        //TODO:  Get Niyabat ID
        public int GetNiyabatID(string NName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var niyabat = db.niyabats.Where(o => o.NName.Equals(NName));
                if (niyabat.Any()) // if there is any result, even only one
                    return niyabat.FirstOrDefault().WID;
            }
            return 0;
        }

        //TODO: Get All Niyabat based up on willayat ID
        public NiyabtDataView GetNiyabatDataView(int WID)
        {
            villageManager VDM = new villageManager();
            NiyabtDataView NDV = new NiyabtDataView();
            List<VillageDataView> villages = new List<VillageDataView>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                int gtid;
                var getN = db.niyabats.Where(o => o.WID == WID).ToList();
                foreach (var item in getN)
                {
                    NDV.NID = item.NID;
                    NDV.NName = item.NName;
                    gtid = Convert.ToInt32(item.NID);
                    //NDV.tbl_Village = VDM.GetAllVillages(gtid);
                }
            } return NDV;
        }

        //TODO:  Update Niyabat data
        public void UpdateNiyabatData(NiyabtDataView nlt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tbl_Niyabat NU = db.niyabats.Find(nlt.NID);
                        NU.NName = nlt.NName;
                        NU.WID = nlt.WID;
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
    }
}
