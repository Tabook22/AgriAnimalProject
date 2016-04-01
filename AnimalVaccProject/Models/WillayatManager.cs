using AnimalVaccProject.Models;
using AnimalVaccProject.ViewModels;
using System.Linq;

namespace AgriVaccFinal.Models.EntityManager
{
    public class WillayatManager
    {
        //The AddWillayat() is a method that inserts data to the database using Entity Framework.
        public void AddWillayat(addNewWillayat Wlt)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                tbl_Willayat WL = new tbl_Willayat();
                WL.WName =Wlt.WName ;

                db.willayats.Add(WL);
                db.SaveChanges();
            }
        }

        //Check if there is any willayat befor adding a new one
        public bool IsWillayatExist(string WName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.willayats.Where(o => o.WName.Equals(WName)).Any(); // the Any() checks at least for one match and it return true if it found one, or false if it not
            }
        }

        // Get Willayat ID
        public int GetWillayaID(string WName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var willayat = db.willayats.Where(o => o.WName.Equals(WName));
                if (willayat.Any()) // if there is any result, even only one
                    return willayat.FirstOrDefault().WID;
            }
            return 0;
        }

        //Get willayat profile with all the niyabat
        public WillayatDataView GetWillayatDataView(string WName)
        {
            WillayatDataView WDV = new WillayatDataView();
            int? WID = 0;

            WID = GetWillayaID(WName);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var getW = db.willayats.Where(o => o.WName.Equals(WName));
                foreach (var item in getW)
                {
                    WDV.WID = item.WID;
                    WDV.WName = item.WName;
                    WDV.tbl_Niyabat = db.niyabats.Where(x => x.WID == item.WID);
                }
               
                return WDV;
            }
        }

        // Update willayat data
        public void UpdateWillayatData(WillayatDataView wlt)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tbl_Willayat WU = db.willayats.Find(wlt.WID);
                        WU.WName = wlt.WName;
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
