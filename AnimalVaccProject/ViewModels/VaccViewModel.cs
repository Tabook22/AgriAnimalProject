using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.ViewModels
{
    public class VaccViewModel
    {
       public class VaccViewData
        {
            public int Id { get; set; }
            public string AgriCert { get; set; }
            public DateTime VaccDate { get; set; }
            public int AId { get; set; }
            public string AnName { get; set; }
            public int DoseId { get; set; }
            public string DoseType { get; set; }
            public int DisId { get; set; }
            public string DiseaseType { get; set; }
            public int TotalNo { get; set; }
            public string Name { get; set; }
            public int FarmerId { get; set; }
        }
    }
}