using System.Data.Entity;
using StudentManagementSystem.Models.Application;

namespace StudentManagementSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    /// <summary>
    /// Database instance for the system
    /// </summary>
    public class StudentMsDb : IdentityDbContext<ApplicationUser>
    {
        public StudentMsDb()
            : base("StudentMSDb", throwIfV1Schema: false)
        {
        }

        public static StudentMsDb Create()
        {
            return new StudentMsDb();
        }        

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
    }
}