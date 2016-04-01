using AnimalVaccProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace AnimalVaccProject.ViewModels
{
    public class addNewVillage
    {

        [Key]
        public int VID { get; set; }

        [Display(Name = "إسم الالقرية")]
        [Required(ErrorMessage = "الرجاء كتابة إسم القرية")]
        public string VName { get; set; }

        [Display(Name = "إسم النيابة")]
        [Required(ErrorMessage = "الرجاء إختيار النيابة")]
        public int NID { get; set; }


    }

    public class VillageDataView
    {
        public int VID { get; set; }
        public string VName { get; set; }
        public int NID { get; set; }
        public string NName { get; set; }
        public int WID { get; set; }
        public string WName { get; set; }

        public List<tbl_Niyabat> niyabatlst { get; set; } // this needed to be filled later on in the controller index action, because it can't be null

        public IEnumerable<SelectListItem> GetNiyabatList()
        {
            return niyabatlst.Select(n => new SelectListItem()
            {
                Text = n.NName,
                Value = n.NID.ToString()
            });
        }



    }
}
