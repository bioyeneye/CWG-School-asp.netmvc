using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Application.ViewModel
{
    public class TeacherDetailViewModel
    {
        public Teacher Teacher { get; set; }
        public List<Course> Courses { get; set; }
    }
}