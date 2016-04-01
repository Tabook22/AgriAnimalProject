using AnimalVaccProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace AnimalVaccProject.ViewModels
{

    public class addNewNiyabat
    {

        [Key]
        public int NID { get; set; }

        [Display(Name = "إسم النيابة")]
        [Required(ErrorMessage = "الرجاء كتابة إسم النيابة")]
        public string NName { get; set; }

        [Display(Name = "إسم الولاية")]
        [Required(ErrorMessage = "الرجاء إختيار النيابة")]
        public int WID { get; set; }


    }


    public class NiyabtDataView
    {
        public int NID { get; set; }
        public string NName { get; set; }
        public int WID { get; set; }
        public string WName { get; set; }


        public List<tbl_Willayat> willayatlst { get; set; } // this needed to be filled later on in the controller index action, because it can't be null

        public IEnumerable<SelectListItem> GetWillayatList()
        {
            return willayatlst.Select(w => new SelectListItem()
            {
                Text = w.WName,
                Value = w.WID.ToString()
            });
        }

    }

    ////Getting List of willayat for the dropdwonlist in niayabat index view
    //public class getWillayatDropDwonList
    //{
    //    public List<tbl_Willayat> willayatlst { get; set; }

    //    public IEnumerable<SelectListItem> GetWillayatList()
    //    {
    //        return willayatlst.Select(w => new SelectListItem()
    //        {
    //            Text = w.WName,
    //            Value = w.WID.ToString()
    //        });
    //    }
    //}
}
