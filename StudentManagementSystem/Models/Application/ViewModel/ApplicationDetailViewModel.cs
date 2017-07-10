using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Application.ViewModel
{
    public class ApplicationDetailViewModel
    {
        public ApplicationForm ApplicationForm { get; set; }
        public Student Student { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}