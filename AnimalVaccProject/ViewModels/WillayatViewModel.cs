using AnimalVaccProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalVaccProject.ViewModels
{
    //public class WillayatViewModel
    // {
    //adding a new willayat
    public class addNewWillayat
        {
            [Key]
            public int WID { get; set; }

            [Required(ErrorMessage ="الرجاء كتابة إسم الولاية")]
            [Display(Name ="إسم الولاية")]
            public string WName { get; set; }

        }

    // Display list of Willayats
    public class WillayatDataView
    {
        public int WID { get; set; }
        public string WName { get; set; }
        public IEnumerable<tbl_Niyabat> tbl_Niyabat { get; set; }

    }

    //}
}
