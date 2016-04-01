using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalVaccProject.Models
{
    public class tbl_Farmer
    {
        [Key]
        public int FarmerId { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة إسم المربي")]
        [Display(Name = "إسم المربي")]
        public string Name { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة الرقم المدني")]
        [Display(Name = "الرقم المدني")]
        public string civilId { get; set; }

        [Required(ErrorMessage = "الرجاء إختيار الولاية")]
        [Display(Name = "إسم الولاية")]
        public int WID { get; set; }

        [Required(ErrorMessage = "الرجاء إختيار النيابة")]
        [Display(Name = "إسم النيابة")]
        public int NID { get; set; }

        [Required(ErrorMessage = "الرجاء إختيار القرية")]
        [Display(Name = "إسم القرية")]
        public int VID { get; set; }

        [Display(Name = "رقم الهاتف")]
        public string Tel { get; set; }

        [Display(Name = "الوظيفة")]
        public string Job { get; set; }

        public virtual ICollection<tbl_Vacc> vaccs { get; set; }
        public virtual ICollection<tbl_AgriCert> agricerts { get; set; }
        public virtual tbl_Willayat willayat { get; set; }
    }
}