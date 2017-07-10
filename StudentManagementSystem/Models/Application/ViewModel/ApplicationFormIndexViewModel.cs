using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models.Application.ViewModel
{
    public class ApplicationFormIndexViewModel
    {
        public List<ApplicationForm> ApplicationForms { get; set; }
        public List<ApplicationStatus> ApplicationStatuses { get; set; }
    }
}