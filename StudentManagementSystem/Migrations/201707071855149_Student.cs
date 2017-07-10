namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Sex", c => c.Boolean(nullable: false));
        }
    }
}
