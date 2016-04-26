using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.ViewModels
{
    public class DiseaseViewData
    {
        public int DisId { get; set; }
        public string DiseaseType { get; set; }
        public int catId { get; set; }
        public string trtType{ get; set; }
        public int dtypeId { get; set; }
        public string DType { get; set; }
    }
}