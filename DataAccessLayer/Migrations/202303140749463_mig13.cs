namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Admin_AdminID", "dbo.Admins");
            DropForeignKey("dbo.Jobs", "Admin_AdminID1", "dbo.Admins");
            DropForeignKey("dbo.Resumes", "Admin_AdminID", "dbo.Admins");
            DropForeignKey("dbo.Resumes", "Admin_AdminID1", "dbo.Admins");
            DropForeignKey("dbo.Skills", "Admin_AdminID", "dbo.Admins");
            DropForeignKey("dbo.Skills", "Admin_AdminID1", "dbo.Admins");
            DropForeignKey("dbo.Admins", "Job_JobID", "dbo.Jobs");
            DropForeignKey("dbo.Admins", "Resume_ResumeID", "dbo.Resumes");
            DropForeignKey("dbo.Admins", "Skill_SkillID", "dbo.Skills");
            DropIndex("dbo.Admins", new[] { "Job_JobID" });
            DropIndex("dbo.Admins", new[] { "Resume_ResumeID" });
            DropIndex("dbo.Admins", new[] { "Skill_SkillID" });
            DropIndex("dbo.Jobs", new[] { "Admin_AdminID" });
            DropIndex("dbo.Jobs", new[] { "Admin_AdminID1" });
            DropIndex("dbo.Resumes", new[] { "Admin_AdminID" });
            DropIndex("dbo.Resumes", new[] { "Admin_AdminID1" });
            DropIndex("dbo.Skills", new[] { "Admin_AdminID" });
            DropIndex("dbo.Skills", new[] { "Admin_AdminID1" });
            DropColumn("dbo.Admins", "JobID");
            DropColumn("dbo.Admins", "ResumeID");
            DropColumn("dbo.Admins", "SkillID");
            RenameColumn(table: "dbo.Admins", name: "Job_JobID", newName: "JobID");
            RenameColumn(table: "dbo.Admins", name: "Resume_ResumeID", newName: "ResumeID");
            RenameColumn(table: "dbo.Admins", name: "Skill_SkillID", newName: "SkillID");
            AlterColumn("dbo.Admins", "JobID", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "ResumeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "SkillID", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "ResumeID");
            CreateIndex("dbo.Admins", "JobID");
            CreateIndex("dbo.Admins", "SkillID");
            AddForeignKey("dbo.Admins", "JobID", "dbo.Jobs", "JobID", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "ResumeID", "dbo.Resumes", "ResumeID", cascadeDelete: true);
            AddForeignKey("dbo.Admins", "SkillID", "dbo.Skills", "SkillID", cascadeDelete: true);
            DropColumn("dbo.Jobs", "AdminID");
            DropColumn("dbo.Jobs", "Admin_AdminID");
            DropColumn("dbo.Jobs", "Admin_AdminID1");
            DropColumn("dbo.Resumes", "AdminID");
            DropColumn("dbo.Resumes", "Admin_AdminID");
            DropColumn("dbo.Resumes", "Admin_AdminID1");
            DropColumn("dbo.Skills", "AdminID");
            DropColumn("dbo.Skills", "Admin_AdminID");
            DropColumn("dbo.Skills", "Admin_AdminID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Admin_AdminID1", c => c.Int());
            AddColumn("dbo.Skills", "Admin_AdminID", c => c.Int());
            AddColumn("dbo.Skills", "AdminID", c => c.Int(nullable: false));
            AddColumn("dbo.Resumes", "Admin_AdminID1", c => c.Int());
            AddColumn("dbo.Resumes", "Admin_AdminID", c => c.Int());
            AddColumn("dbo.Resumes", "AdminID", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "Admin_AdminID1", c => c.Int());
            AddColumn("dbo.Jobs", "Admin_AdminID", c => c.Int());
            AddColumn("dbo.Jobs", "AdminID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Admins", "SkillID", "dbo.Skills");
            DropForeignKey("dbo.Admins", "ResumeID", "dbo.Resumes");
            DropForeignKey("dbo.Admins", "JobID", "dbo.Jobs");
            DropIndex("dbo.Admins", new[] { "SkillID" });
            DropIndex("dbo.Admins", new[] { "JobID" });
            DropIndex("dbo.Admins", new[] { "ResumeID" });
            AlterColumn("dbo.Admins", "SkillID", c => c.Int());
            AlterColumn("dbo.Admins", "ResumeID", c => c.Int());
            AlterColumn("dbo.Admins", "JobID", c => c.Int());
            RenameColumn(table: "dbo.Admins", name: "SkillID", newName: "Skill_SkillID");
            RenameColumn(table: "dbo.Admins", name: "ResumeID", newName: "Resume_ResumeID");
            RenameColumn(table: "dbo.Admins", name: "JobID", newName: "Job_JobID");
            AddColumn("dbo.Admins", "SkillID", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "ResumeID", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "JobID", c => c.Int(nullable: false));
            CreateIndex("dbo.Skills", "Admin_AdminID1");
            CreateIndex("dbo.Skills", "Admin_AdminID");
            CreateIndex("dbo.Resumes", "Admin_AdminID1");
            CreateIndex("dbo.Resumes", "Admin_AdminID");
            CreateIndex("dbo.Jobs", "Admin_AdminID1");
            CreateIndex("dbo.Jobs", "Admin_AdminID");
            CreateIndex("dbo.Admins", "Skill_SkillID");
            CreateIndex("dbo.Admins", "Resume_ResumeID");
            CreateIndex("dbo.Admins", "Job_JobID");
            AddForeignKey("dbo.Admins", "Skill_SkillID", "dbo.Skills", "SkillID");
            AddForeignKey("dbo.Admins", "Resume_ResumeID", "dbo.Resumes", "ResumeID");
            AddForeignKey("dbo.Admins", "Job_JobID", "dbo.Jobs", "JobID");
            AddForeignKey("dbo.Skills", "Admin_AdminID1", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Skills", "Admin_AdminID", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Resumes", "Admin_AdminID1", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Resumes", "Admin_AdminID", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Jobs", "Admin_AdminID1", "dbo.Admins", "AdminID");
            AddForeignKey("dbo.Jobs", "Admin_AdminID", "dbo.Admins", "AdminID");
        }
    }
}
