namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationstatusTeacherId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationStatus", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.ApplicationStatus", new[] { "TeacherId" });
            AlterColumn("dbo.ApplicationStatus", "TeacherId", c => c.Int());
            CreateIndex("dbo.ApplicationStatus", "TeacherId");
            AddForeignKey("dbo.ApplicationStatus", "TeacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationStatus", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.ApplicationStatus", new[] { "TeacherId" });
            AlterColumn("dbo.ApplicationStatus", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplicationStatus", "TeacherId");
            AddForeignKey("dbo.ApplicationStatus", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
    }
}
