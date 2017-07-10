namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDepartment : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Departments] ON INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (1, N'Computer Science') INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (2, N'Chemical Engineering')
                INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (3, N'Electronical Electrical') INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (4, N'Mechanical Engineering')
                INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (5, N'Food Science') SET IDENTITY_INSERT [dbo].[Departments] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
