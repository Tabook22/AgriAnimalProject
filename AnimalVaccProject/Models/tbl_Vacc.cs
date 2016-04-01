using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Vacc
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاءكتابة رقم الحيازة")]
        [Display(Name = "رقم الحيازة")]
        public string AgriCert { get; set; }
        [Required(ErrorMessage = "الرجاء إختيار التاريخ")]
        [Display(Name = "التاريخ")]
        public DateTime VaccDate { get; set; }

        [Required(ErrorMessage = "الرجاءإختيار نوع الحيوان")]
        [Display(Name = "نوع الحيوان")]
        public int AId { get; set; }

        [Required(ErrorMessage = "الرجاء إختيار نوع الجرعة")]
        [Display(Name = "نوع الجرعة")]
        public int DoseId { get; set; }

        [Required(ErrorMessage = "الرجاء نوع المرض")]
        [Display(Name = "نوع المرض")]
        public int DisId { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة العدد")]
        [Display(Name = "عدد الحيوانات")]
        public int TotalNo { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة إسم المربي")]
        [Display(Name = "إسم المربي")]
        public int FarmerId { get; set; }

        public virtual tbl_Farmer farmer { get; set; }
        public virtual tbl_Animal animal { get; set; }
        public virtual tbl_Dose dose { get; set; }
        public virtual tbl_Disease disease { get; set; }
    }
}