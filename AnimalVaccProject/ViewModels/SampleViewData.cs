using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.ViewModels
{
    public class SampleViewData
    {
        public int Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SampleDate { get; set; }
        public string TestDetails { get; set; }
        public int SampleTypeId { get; set; }
        public string SampleTypeName { get; set; }
        public string SampleNo { get; set; }
        public int Results { get; set; }
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public string civilId { get; set; }
    }
}