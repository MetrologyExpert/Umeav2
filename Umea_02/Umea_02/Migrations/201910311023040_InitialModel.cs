namespace Umea_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.UncertaintyBudgets",
                c => new
                    {
                        UbId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        InstrumentId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UbId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Instruments", t => t.InstrumentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.InstrumentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Contributions",
                c => new
                    {
                        ContributionId = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        Name = c.String(),
                        EstimatedValue = c.Double(nullable: false),
                        PdfId = c.Int(nullable: false),
                        StandardUncertainty = c.Double(nullable: false),
                        SensitivityCoefficient = c.Double(nullable: false),
                        Uncertainty = c.String(),
                        UbId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContributionId)
                .ForeignKey("dbo.UncertaintyBudgets", t => t.UbId, cascadeDelete: true)
                .Index(t => t.UbId);
            
            CreateTable(
                "dbo.Pdfs",
                c => new
                    {
                        PdfId = c.Int(nullable: false, identity: true),
                        PdfName = c.String(),
                        PdfCoefficient = c.Double(nullable: false),
                        UncertaintyBudget_UbId = c.Int(),
                        Contribution_ContributionId = c.Int(),
                    })
                .PrimaryKey(t => t.PdfId)
                .ForeignKey("dbo.UncertaintyBudgets", t => t.UncertaintyBudget_UbId)
                .ForeignKey("dbo.Contributions", t => t.Contribution_ContributionId)
                .Index(t => t.UncertaintyBudget_UbId)
                .Index(t => t.Contribution_ContributionId);
            
            CreateTable(
                "dbo.Instruments",
                c => new
                    {
                        InstrumentId = c.Int(nullable: false, identity: true),
                        InstrumentName = c.String(),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        MeasurementRange = c.String(),
                        Resolution = c.Double(nullable: false),
                        Temperature = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.InstrumentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Company = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        MembershipTypeId = c.Int(nullable: false, identity: true),
                        MembershipType = c.String(),
                    })
                .PrimaryKey(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.UserMemberships",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        MembershipTypeId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Memberships", t => t.MembershipTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.MembershipTypeId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMemberships", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.UserMemberships", "MembershipTypeId", "dbo.Memberships");
            DropForeignKey("dbo.UncertaintyBudgets", "UserId", "dbo.Users");
            DropForeignKey("dbo.UncertaintyBudgets", "InstrumentId", "dbo.Instruments");
            DropForeignKey("dbo.Contributions", "UbId", "dbo.UncertaintyBudgets");
            DropForeignKey("dbo.Pdfs", "Contribution_ContributionId", "dbo.Contributions");
            DropForeignKey("dbo.Pdfs", "UncertaintyBudget_UbId", "dbo.UncertaintyBudgets");
            DropForeignKey("dbo.UncertaintyBudgets", "AuthorId", "dbo.Authors");
            DropIndex("dbo.UserMemberships", new[] { "User_UserId" });
            DropIndex("dbo.UserMemberships", new[] { "MembershipTypeId" });
            DropIndex("dbo.Pdfs", new[] { "Contribution_ContributionId" });
            DropIndex("dbo.Pdfs", new[] { "UncertaintyBudget_UbId" });
            DropIndex("dbo.Contributions", new[] { "UbId" });
            DropIndex("dbo.UncertaintyBudgets", new[] { "UserId" });
            DropIndex("dbo.UncertaintyBudgets", new[] { "InstrumentId" });
            DropIndex("dbo.UncertaintyBudgets", new[] { "AuthorId" });
            DropTable("dbo.UserMemberships");
            DropTable("dbo.Memberships");
            DropTable("dbo.Users");
            DropTable("dbo.Instruments");
            DropTable("dbo.Pdfs");
            DropTable("dbo.Contributions");
            DropTable("dbo.UncertaintyBudgets");
            DropTable("dbo.Authors");
        }
    }
}
