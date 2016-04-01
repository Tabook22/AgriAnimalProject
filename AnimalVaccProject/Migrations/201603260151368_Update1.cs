namespace AnimalVaccProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_AgriCert",
                c => new
                    {
                        AgriCertId = c.Int(nullable: false, identity: true),
                        AgriCertNo = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ExpDate = c.DateTime(nullable: false),
                        FarmerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgriCertId)
                .ForeignKey("dbo.tbl_Farmer", t => t.FarmerId, cascadeDelete: true)
                .Index(t => t.FarmerId);
            
            CreateTable(
                "dbo.tbl_Farmer",
                c => new
                    {
                        FarmerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        civilId = c.String(nullable: false),
                        WID = c.Int(nullable: false),
                        NID = c.Int(nullable: false),
                        VID = c.Int(nullable: false),
                        Tel = c.String(),
                        Job = c.String(),
                    })
                .PrimaryKey(t => t.FarmerId)
                .ForeignKey("dbo.tbl_Willayat", t => t.WID, cascadeDelete: true)
                .Index(t => t.WID);
            
            CreateTable(
                "dbo.tbl_Willayat",
                c => new
                    {
                        WID = c.Int(nullable: false, identity: true),
                        WName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.WID);
            
            CreateTable(
                "dbo.tbl_Niyabat",
                c => new
                    {
                        NID = c.Int(nullable: false, identity: true),
                        NName = c.String(nullable: false),
                        WID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NID)
                .ForeignKey("dbo.tbl_Willayat", t => t.WID, cascadeDelete: true)
                .Index(t => t.WID);
            
            CreateTable(
                "dbo.tbl_Village",
                c => new
                    {
                        VID = c.Int(nullable: false, identity: true),
                        VName = c.String(nullable: false),
                        NID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VID)
                .ForeignKey("dbo.tbl_Niyabat", t => t.NID, cascadeDelete: true)
                .Index(t => t.NID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tbl_Village", "NID", "dbo.tbl_Niyabat");
            DropForeignKey("dbo.tbl_Niyabat", "WID", "dbo.tbl_Willayat");
            DropForeignKey("dbo.tbl_Farmer", "WID", "dbo.tbl_Willayat");
            DropForeignKey("dbo.tbl_AgriCert", "FarmerId", "dbo.tbl_Farmer");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tbl_Village", new[] { "NID" });
            DropIndex("dbo.tbl_Niyabat", new[] { "WID" });
            DropIndex("dbo.tbl_Farmer", new[] { "WID" });
            DropIndex("dbo.tbl_AgriCert", new[] { "FarmerId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tbl_Village");
            DropTable("dbo.tbl_Niyabat");
            DropTable("dbo.tbl_Willayat");
            DropTable("dbo.tbl_Farmer");
            DropTable("dbo.tbl_AgriCert");
        }
    }
}
