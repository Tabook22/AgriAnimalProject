using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Accident
    {
        [Key]
        public int Id { get; set; }
        public DateTime SampleDate { get; set; }
        public string AnimalType { get; set; }
        public string SampleType { get; set; }
        public int AnimalNo { get; set; }
        public string Causes { get; set; }
    }
}