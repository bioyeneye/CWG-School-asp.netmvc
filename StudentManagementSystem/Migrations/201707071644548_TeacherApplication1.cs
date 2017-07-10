namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherApplication1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "DepartmentId");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropColumn("dbo.Teachers", "DepartmentId");
        }
    }
}
