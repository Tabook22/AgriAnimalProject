using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AnimalVaccProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<tbl_Farmer> farmers { get; set; }
        public DbSet<tbl_AgriCert> agricerts { get; set; }
        public DbSet<tbl_Willayat> willayats { get; set; }
        public DbSet<tbl_Niyabat> niyabats { get; set; }
        public DbSet<tbl_Village> villages { get; set; }
        public DbSet<tbl_Accident> accidents { get; set; }
        public DbSet<tbl_Sample> samples { get; set; }
        public DbSet<tbl_Treatment> treatments { get; set; }
        public DbSet<tbl_Vacc> vaccinations { get; set; }
        public DbSet<tbl_Animal> animals { get; set; }
        public DbSet<tbl_Dose> doses { get; set; }
        public DbSet<tbl_Disease> diseases { get; set; }
        public DbSet <treatmentType> treatmentypes { get; set; }
        public DbSet<vacTool> vactools { get; set; }
        public DbSet<SampleType> sampletypes { get; set; }
    }
}