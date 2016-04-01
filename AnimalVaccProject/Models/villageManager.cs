using AnimalVaccProject.Models;
using AnimalVaccProject.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace AgriVaccFinal.Models.EntityManager
{
    class villageManager
    {
        //TODO: Add New Village.
        public void AddVillage(addNewVillage Vlt)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                tbl_Village VL = new tbl_Village();
                VL.VName = Vlt.VName;
                VL.NID = Vlt.NID;

                db.villages.Add(VL);
                db.SaveChanges();
            }
        }

        //TODO: Check if there is any Village befor adding a new one using Village Id and Niyabat Id, this is important during the update process
        public bool IsVillageExist(string txtName, int ID2)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.villages.Where(o => o.VName.Equals(txtName) && o.NID.Equals(ID2)).Any(); // the Any() checks at least for one match and it return true if it found one, or false if it not
            }
        }

        //TODO: Overloading the same function with different signature here checking using only Village Id this is done during the new addition of a new village
        public bool IsVillageExist(int ID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.villages.Where(o => o.VID.Equals(ID)).Any(); // the Any() checks at least for one match and it return true if it found one, or false if it not
            }
        }

        //TODO: Get Vilage Id based up the Village Name
        public int GetNiyabatID(string txtName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var village = db.villages.Where(o => o.VName.Equals(txtName));
                if (village.Any()) // if there is any result, even only one
                    return village.FirstOrDefault().VID;
            }
            return 0;
        }

        //TODO: Get All the villages based on Niyabat ID
        public List<VillageDataView> GetAllVillages(int ID2)
        {
            
            List<VillageDataView> Villageprofile = new List<VillageDataView>();
            VillageDataView VDV = new VillageDataView();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               var myV = db.villages.Where(x => x.NID == ID2).OrderBy(x => x.VName).ToList();

                foreach(var item in myV)
                {
                    VDV.VID = item.VID;
                    VDV.VName = item.VName;
                    VDV.NID = item.NID;
                    Villageprofile.Add(VDV);
                }
            }

            return Villageprofile;
        }

        //TODO: Update Village data
        public void UpdateVillageData(VillageDataView vlt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tbl_Village VU = db.villages.Find(vlt.VID);
                        VU.VName = vlt.VName;
                        VU.VID = vlt.VID;
                        VU.NID = vlt.NID;
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
