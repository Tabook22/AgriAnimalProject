using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Village
    {
        [Key]
        public int VID { get; set; }

        [Display(Name = "إسم القرية")]
        [Required(ErrorMessage = "الرجاء كتابة إسم القرية")]
        public string VName { get; set; }

        [Display(Name = "إسم النيابة")]
        [Required(ErrorMessage = "الرجاء كتابة إسم النيابة")]
        public int NID { get; set; }

        public virtual tbl_Niyabat niyabat { get; set; }
    }
}