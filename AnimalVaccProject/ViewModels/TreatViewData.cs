using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.ViewModels
{
    public class TreatViewData
    {
        public int Id { get; set; }
        public string AgriCert { get; set; }
        public DateTime TreDate { get; set; }
        public string Name { get; set; }
        public int FarmerId { get; set; }
    }
}