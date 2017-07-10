using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Application.ViewModel
{
    public class StudentProfileViewModel
    {
        public Student Student { get; set; }
        public ApplicationForm ApplicationForm { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public SelectedCourses SelectedCourses { get; set; }
    }
}