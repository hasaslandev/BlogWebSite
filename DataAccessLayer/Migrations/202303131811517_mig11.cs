namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ResumeID", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "JobID", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "SkillID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "SkillID");
            DropColumn("dbo.Admins", "JobID");
            DropColumn("dbo.Admins", "ResumeID");
        }
    }
}
