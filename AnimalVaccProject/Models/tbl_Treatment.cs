using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Treatment
    {
        [Key]
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public string AgriCert { get; set; }
        public DateTime TreDate { get; set; }
        public string AnimalType { get; set; }
        public string DiseaseType { get; set; }
        public string TreType { get; set; }
        public int TotalNo { get; set; }
    }
}