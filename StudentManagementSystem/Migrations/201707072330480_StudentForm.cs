namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentForm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationForms", "StudentId", "dbo.Students");
            DropIndex("dbo.ApplicationForms", new[] { "StudentId" });
            AlterColumn("dbo.ApplicationForms", "StudentId", c => c.Int());
            CreateIndex("dbo.ApplicationForms", "StudentId");
            AddForeignKey("dbo.ApplicationForms", "StudentId", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationForms", "StudentId", "dbo.Students");
            DropIndex("dbo.ApplicationForms", new[] { "StudentId" });
            AlterColumn("dbo.ApplicationForms", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplicationForms", "StudentId");
            AddForeignKey("dbo.ApplicationForms", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
