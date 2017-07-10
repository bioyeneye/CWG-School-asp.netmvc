namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIgrationRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationForms", "AboutYou", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationForms", "AboutYou", c => c.String());
        }
    }
}
