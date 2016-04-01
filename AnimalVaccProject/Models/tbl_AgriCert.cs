using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_AgriCert
    {
        [Key]
        public int AgriCertId { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة رقم الحيازة")]
        [Display(Name = "رقم الحيازة")]
        public string AgriCertNo { get; set; }

        [Required(ErrorMessage = "الرجاء إختيار نوع الحيازة")]
        [Display(Name = "نوع الحيازة")]
        public string Type { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة تاريخ الإصدار")]
        [Display(Name = "تاريخ الإصدار")]
        public System.DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة تاريخ الإنتهاء")]
        [Display(Name = "تاريخ الإنتهاء")]
        public System.DateTime ExpDate { get; set; }

        [Required(ErrorMessage = "الرجاء إختيار المربي")]
        [Display(Name = "إسم المربي")]
        public int FarmerId { get; set; }

        public virtual tbl_Farmer farmer { get; set; }
    }
}