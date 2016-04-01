using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Willayat
    {
        [Key]
        public int WID { get; set; }
        [Display(Name = "إسم الولاية")]
        [Required(ErrorMessage = "الرجاء كتابة إسم الولاية")]
        public string WName { get; set; }

        public virtual ICollection<tbl_Niyabat> niyabat { get; set; }
        public virtual ICollection<tbl_Farmer> farmer { get; set; }
    }
}