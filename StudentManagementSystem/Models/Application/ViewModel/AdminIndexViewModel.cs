using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Application.ViewModel
{
    public class AdminIndexViewModel
    {
        public List<Course> Courses { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Department> Departments { get; set; }

        public List<Student> AllStudents { get; set; }
        public List<Student> PendingStudents { get; set; }
        public List<Student> AcceptedStudents { get; set; }
    }
}