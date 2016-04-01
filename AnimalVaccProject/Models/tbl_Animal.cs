using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Animal
    {
        [Key]
        public int AId { get; set; }
        [Display(Name="إسم الحيوان")]
        public string Name { get; set; }

       
    }
}