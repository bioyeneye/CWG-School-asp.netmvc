namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherApplication : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Teachers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Teachers", "ApplicationUserId");
            RenameColumn(table: "dbo.Teachers", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Teachers", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Teachers", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Teachers", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Teachers", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Teachers", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Teachers", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "ApplicationUser_Id");
        }
    }
}
