using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Niyabat
    {
        [Key]
        public int NID { get; set; }

        [Display(Name = "إسم النيابة")]
        [Required(ErrorMessage = "الرجاء كتابة إسم النيابة")]
        public string NName { get; set; }

        [Display(Name = "إسم الولاية")]
        [Required(ErrorMessage = "الرجاء إختيار النيابة")]
        public int WID { get; set; }

        public virtual tbl_Willayat tbl_Willayst { get; set; }
        public virtual ICollection<tbl_Village> village { get; set; }
    }
}