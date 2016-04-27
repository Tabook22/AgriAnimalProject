namespace AnimalVaccProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnimalVaccProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AnimalVaccProject.Models.ApplicationDbContext context)
        {
            //table willayats
            context.willayats.AddOrUpdate(x => x.WID,
                new Models.tbl_Willayat {WName ="صلالة" },
                 new Models.tbl_Willayat { WName = "طاقة" },
                  new Models.tbl_Willayat { WName = "مرباط" },
                   new Models.tbl_Willayat { WName = "سدح" },
                    new Models.tbl_Willayat { WName = "شليم و حجزر الحلانيات" },
                     new Models.tbl_Willayat { WName = "مقشن" },
                      new Models.tbl_Willayat { WName = "ثمريت" },
                       new Models.tbl_Willayat { WName = "المزيونة" },
                        new Models.tbl_Willayat { WName = "ضلكوت" },
                         new Models.tbl_Willayat { WName = "رخيوت" }
                );
            context.SaveChanges();

            //table animals

            context.animals.AddOrUpdate(x => x.AId,
                new Models.tbl_Animal {Name="أبقار" },
                new Models.tbl_Animal { Name = "جمال" },
                new Models.tbl_Animal { Name = "ماعز" },
                new Models.tbl_Animal { Name = "ظأن" },
                new Models.tbl_Animal { Name = "خاروف" },
                new Models.tbl_Animal { Name = "أغنام" },
                new Models.tbl_Animal { Name = "خيول" });
            context.SaveChanges();

            //table lab samples
            context.sampletypes.AddOrUpdate(x => x.Id,
                new Models.SampleType {Name ="دم"},
                new Models.SampleType { Name = "سيرم" },
                new Models.SampleType { Name = "حليب" },
                new Models.SampleType { Name = "مسحة من الفم" },
                new Models.SampleType { Name = "براز" },
                new Models.SampleType { Name = "مسحة شرجية" },
                new Models.SampleType { Name = "جثة كاملة" },
                new Models.SampleType { Name = "أجزاء جثة" },
                new Models.SampleType { Name = "سمك مجفف" },
                new Models.SampleType { Name = "بصمة عين" },
                new Models.SampleType { Name = "بثرات من الفم" });
            context.SaveChanges();
            //table treatment Type
            context.treatmentypes.AddOrUpdate(x => x.Id,
                new Models.treatmentType {Name="تحصين" },
                new Models.treatmentType {Name="علاج"});
            context.SaveChanges();
            //table disease types
            context.diseasetypes.AddOrUpdate(x => x.Id,
                new Models.DiseaseType { DType = "أمراض الجهاز الهضمي" },
                new Models.DiseaseType { DType = "أمراض الجهاز التنفسي" },
                new Models.DiseaseType { DType = "أمراض الجهاز البولي و التناسلي" },
                new Models.DiseaseType { DType = "أمراض النقص الغذائي" },
                new Models.DiseaseType { DType = "الإمراض الطفيلية" },
                new Models.DiseaseType { DType = "أمراض وبائية و معدية" },
                new Models.DiseaseType { DType = "حالات جراحية" },
                new Models.DiseaseType { DType = "أمراض أخرى" },
                new Models.DiseaseType { DType = "" });
            context.SaveChanges();
            //table Diseases
            context.diseases.AddOrUpdate(x => x.DisId,
             new Models.tbl_Disease { DiseaseType ="إسهال", catId=1, dtype= 2},
             new Models.tbl_Disease { DiseaseType = "إمساك", catId = 1, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "نفاخ", catId = 1, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إلتهاب  بالفم", catId = 1, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "تخمة غذائية", catId = 1, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "نزلة معوية", catId = 1, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إلتهاب الفم", catId = 1, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إلتهاب رئوية", catId = 2, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "نزلة شعبية", catId = 2, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "عسر ولادة", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إحتباس مشيمة", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إلتهاب رحمي", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إنقلاب رحمي", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إلتواء رحمي", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إلتواء مهبلي", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إنقلاب مهبلي", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إلتهاب الضرع", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إلتهاب الخصية", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إحتباس البول", catId = 3, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "إلتهاب القضيب", catId = 3, dtype = 2},
             new Models.tbl_Disease { DiseaseType = "نقص كالسيوم", catId = 4, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "نقص نحاس", catId = 4, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "نقص فيتامينات", catId = 4, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "فقدان الشهية", catId = 4, dtype = 2 },
             new Models.tbl_Disease { DiseaseType = "ضعف علم", catId = 4, dtype = 2 });
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
