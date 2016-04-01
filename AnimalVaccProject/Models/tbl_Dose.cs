using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Dose
    {

        [Key]
        public int DoseId { get; set; }
        [Display(Name = "نوع الجرعة")]
        public string DoseType { get; set; }
    }
}