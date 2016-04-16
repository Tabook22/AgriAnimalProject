using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Disease
    {
        [Key]
        public int DisId { get; set; }
        [Display(Name = "نوع المرض")]
        public string DiseaseType { get; set; }
        [Display(Name = "المجموعة")]
        public int catId { get; set; }
    }
}