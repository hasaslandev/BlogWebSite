namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Resumes", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Skills", "AdminID", "dbo.Admins");
            DropIndex("dbo.Jobs", new[] { "AdminID" });
            DropIndex("dbo.Resumes", new[] { "AdminID" });
            DropIndex("dbo.Skills", new[] { "AdminID" });
            AddColumn("dbo.Admins", "Job_JobID", c => c.Int());
            AddColumn("dbo.Admins", "Resume_ResumeID", c => c.Int());
            AddColumn("dbo.Admins", "Skill_SkillID", c => c.Int());
            AddColumn("dbo.Jobs", "Admin_AdminID", c => c.Int());
            AddColumn("dbo.Jobs", "Admin_AdminID1", c => c.Int());
            AddColumn("dbo.Resumes", "Admin_AdminID", c => c.Int());
            AddColumn("dbo.Resumes", "Admin_AdminID1", c => c.Int());
            AddColumn("dbo.Skills", "Admin_AdminID", c => c.Int());
            AddColumn("dbo.Skills", "Admin_AdminID1", c => c.Int());
            CreateIndex("dbo.Admins", "Job_JobID");
            CreateIndex("dbo.Admins", "Resume_ResumeID");
            CreateIndex("dbo.Admins", "Skill_SkillID");
            CreateIndex("dbo.Jobs", "Admin_AdminID");
            CreateIndex("dbo.Jobs", "Admin_AdminID1");
            CreateIndex("dbo.Resumes", "Admin_AdminID");
            CreateIndex("dbo.Resumes", "Admin_AdminID1");
            CreateIndex("dbo.Skills", "Admin_AdminID");
            CreateIndex("dbo.Skills", "Admin_AdminID1");
            AddForeignKey("dbo.Admins", "Job_JobID", "dbo.Jobs", "JobID");
            AddForeignKey("dbo.Admins", "Resume_ResumeID", "dbo.Resumes", "ResumeID");
            AddForeignKey("dbo.Admins", "Skill_SkillID", "dbo.Skills", "SkillID");
            AddForeignKey("dbo.Jobs", "Admin_AdminID1", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Resumes", "Admin_AdminID1", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Skills", "Admin_AdminID1", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Jobs", "Admin_AdminID", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Resumes", "Admin_AdminID", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Skills", "Admin_AdminID", "dbo.Admins", "AdminID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Admin_AdminID", "dbo.Admins");
            DropForeignKey("dbo.Resumes", "Admin_AdminID", "dbo.Admins");
            DropForeignKey("dbo.Jobs", "Admin_AdminID", "dbo.Admins");
            DropForeignKey("dbo.Skills", "Admin_AdminID1", "dbo.Admins");
            DropForeignKey("dbo.Resumes", "Admin_AdminID1", "dbo.Admins");
            DropForeignKey("dbo.Jobs", "Admin_AdminID1", "dbo.Admins");
            DropForeignKey("dbo.Admins", "Skill_SkillID", "dbo.Skills");
            DropForeignKey("dbo.Admins", "Resume_ResumeID", "dbo.Resumes");
            DropForeignKey("dbo.Admins", "Job_JobID", "dbo.Jobs");
            DropIndex("dbo.Skills", new[] { "Admin_AdminID1" });
            DropIndex("dbo.Skills", new[] { "Admin_AdminID" });
            DropIndex("dbo.Resumes", new[] { "Admin_AdminID1" });
            DropIndex("dbo.Resumes", new[] { "Admin_AdminID" });
            DropIndex("dbo.Jobs", new[] { "Admin_AdminID1" });
            DropIndex("dbo.Jobs", new[] { "Admin_AdminID" });
            DropIndex("dbo.Admins", new[] { "Skill_SkillID" });
            DropIndex("dbo.Admins", new[] { "Resume_ResumeID" });
            DropIndex("dbo.Admins", new[] { "Job_JobID" });
            DropColumn("dbo.Skills", "Admin_AdminID1");
            DropColumn("dbo.Skills", "Admin_AdminID");
            DropColumn("dbo.Resumes", "Admin_AdminID1");
            DropColumn("dbo.Resumes", "Admin_AdminID");
            DropColumn("dbo.Jobs", "Admin_AdminID1");
            DropColumn("dbo.Jobs", "Admin_AdminID");
            DropColumn("dbo.Admins", "Skill_SkillID");
            DropColumn("dbo.Admins", "Resume_ResumeID");
            DropColumn("dbo.Admins", "Job_JobID");
            CreateIndex("dbo.Skills", "AdminID");
            CreateIndex("dbo.Resumes", "AdminID");
            CreateIndex("dbo.Jobs", "AdminID");
            AddForeignKey("dbo.Skills", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
            AddForeignKey("dbo.Resumes", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
            AddForeignKey("dbo.Jobs", "AdminID", "dbo.Admins", "AdminID", cascadeDelete: true);
        }
    }
}
