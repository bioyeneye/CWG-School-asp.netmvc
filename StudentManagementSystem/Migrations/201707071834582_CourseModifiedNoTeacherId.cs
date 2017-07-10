namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseModifiedNoTeacherId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            RenameColumn(table: "dbo.Courses", name: "TeacherId", newName: "Teacher_Id");
            AlterColumn("dbo.Courses", "Teacher_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Teacher_Id");
            AddForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            AlterColumn("dbo.Courses", "Teacher_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Courses", name: "Teacher_Id", newName: "TeacherId");
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
    }
}
