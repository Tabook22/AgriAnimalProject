using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.ViewModels
{
    public class AdminMenuItem
    {
        public string Text { get; set; } //the text needed to display with each link;
        public string Action { get; set; } // we also need to know the action
        public object RouteInfo { get; set; }// this can be an announce object that has the controller name, and the area
    }
}