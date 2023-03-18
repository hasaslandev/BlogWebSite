namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.Admins", "ResumeID", "dbo.Resumes");
            DropForeignKey("dbo.Admins", "SkillID", "dbo.Skills");
            DropIndex("dbo.Admins", new[] { "ResumeID" });
            DropIndex("dbo.Admins", new[] { "JobID" });
            DropIndex("dbo.Admins", new[] { "SkillID" });
            AddColumn("dbo.Jobs", "AdminID", c => c.Int(nullable: false));
            AddColumn("dbo.Resumes", "AdminID", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "AdminID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "AdminID");
            CreateIndex("dbo.Resumes", "AdminID");
            CreateIndex("dbo.Skills", "AdminID");
            AddForeignKey("dbo.Jobs", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
            AddForeignKey("dbo.Resumes", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
            AddForeignKey("dbo.Skills", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
            DropColumn("dbo.Admins", "ResumeID");
            DropColumn("dbo.Admins", "JobID");
            DropColumn("dbo.Admins", "SkillID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "SkillID", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "JobID", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "ResumeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Skills", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Resumes", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Jobs", "AdminID", "dbo.Admins");
            DropIndex("dbo.Skills", new[] { "AdminID" });
            DropIndex("dbo.Resumes", new[] { "AdminID" });
            DropIndex("dbo.Jobs", new[] { "AdminID" });
            DropColumn("dbo.Skills", "AdminID");
            DropColumn("dbo.Resumes", "AdminID");
            DropColumn("dbo.Jobs", "AdminID");
            CreateIndex("dbo.Admins", "SkillID");
            CreateIndex("dbo.Admins", "JobID");
            CreateIndex("dbo.Admins", "ResumeID");
            AddForeignKey("dbo.Admins", "SkillID", "dbo.Skills", "SkillID", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "ResumeID", "dbo.Resumes", "ResumeID", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "JobID", "dbo.Jobs", "JobID", cascadeDelete: true);
        }
    }
}
