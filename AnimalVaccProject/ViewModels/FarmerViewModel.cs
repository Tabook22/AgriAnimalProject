using AnimalVaccProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AnimalVaccProject.ViewModels
{
    public class addNewFarmer
    {
        public int FarmerId { get; set; }
        public string Name { get; set; }
        public string civilId { get; set; }
        public string Tel { get; set; }
        public string Job { get; set; }
        public int WID { get; set; }
        public int NID { get; set; }
        public int VID { get; set; }

    }
    public class FarmerDataView
    {
        public int FarmerId { get; set; }
        public string Name { get; set; }
        public string civilId { get; set; }
        public string Tel { get; set; }
        public string Job { get; set; }
        public int WID { get; set; }
        public string WName { get; set; }
        public int NID { get; set; }
        public string NName { get; set; }
        public int VID { get; set; }
        public string VName { get; set; }

        //to get the list of willayats
        public List<tbl_Willayat> farmerWlst{ get; set; } // this needed to be filled later on in the controller index action, because it can't be null

        public IEnumerable<SelectListItem> GetFarmerWList()
        {
            return farmerWlst.Select(f=> new SelectListItem()
            {
                Text = f.WName,
                Value = f.WID.ToString()
            });
        }

        //to get the list of niyabats
        public List<tbl_Niyabat> farmerNlst { get; set; } // this needed to be filled later on in the controller index action, because it can't be null

        public IEnumerable<SelectListItem> GetFarmerNList()
        {
            return farmerNlst.Select(f => new SelectListItem()
            {
                Text = f.NName,
                Value = f.NID.ToString()
            });
        }

        //to get the list of village
        public List<tbl_Village> farmerVlst { get; set; } // this needed to be filled later on in the controller index action, because it can't be null

        public IEnumerable<SelectListItem> GetFarmerVList()
        {
            return farmerVlst.Select(f => new SelectListItem()
            {
                Text = f.VName,
                Value = f.VID.ToString()
            });
        }
    }
}
