namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Sex", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Sex");
        }
    }
}
