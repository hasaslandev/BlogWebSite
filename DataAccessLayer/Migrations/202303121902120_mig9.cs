namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        JobName = c.String(maxLength: 20),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.Admins", t => t.AdminID, cascadeDelete: true)
                .Index(t => t.AdminID);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ResumeID = c.Int(nullable: false, identity: true),
                        ResumeJobs = c.String(maxLength: 50),
                        ResumeStatement = c.String(maxLength: 2000),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResumeID)
                .ForeignKey("dbo.Admins", t => t.AdminID, cascadeDelete: true)
                .Index(t => t.AdminID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(maxLength: 50),
                        SkillRating = c.Int(nullable: false),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.Admins", t => t.AdminID, cascadeDelete: true)
                .Index(t => t.AdminID);
            
            AddColumn("dbo.Admins", "Degree", c => c.String(maxLength: 25));
            AddColumn("dbo.Admins", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.Admins", "Mail", c => c.String(maxLength: 27));
            AddColumn("dbo.Admins", "FreelanceEnable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "City", c => c.String(maxLength: 27));
            AddColumn("dbo.Admins", "Phone", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Resumes", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Jobs", "AdminID", "dbo.Admins");
            DropIndex("dbo.Skills", new[] { "AdminID" });
            DropIndex("dbo.Resumes", new[] { "AdminID" });
            DropIndex("dbo.Jobs", new[] { "AdminID" });
            DropColumn("dbo.Admins", "Phone");
            DropColumn("dbo.Admins", "City");
            DropColumn("dbo.Admins", "FreelanceEnable");
            DropColumn("dbo.Admins", "Mail");
            DropColumn("dbo.Admins", "Birthday");
            DropColumn("dbo.Admins", "Degree");
            DropTable("dbo.Skills");
            DropTable("dbo.Resumes");
            DropTable("dbo.Jobs");
        }
    }
}
