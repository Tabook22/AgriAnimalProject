using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Sample
    {
        [Key]
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public string AgriCert { get; set; }
        public DateTime SampleDate { get; set; }
        public string TestDetails { get; set; }
        public int SampleType { get; set; }
        public int SampleNo { get; set; }
        public int Results { get; set; }

        public virtual tbl_Farmer  framer { get; set; }
    }
}