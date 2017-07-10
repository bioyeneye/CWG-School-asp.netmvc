using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Application;
using StudentManagementSystem.Models.Application.ViewModel;
using WebGrease.Css.Extensions;

namespace StudentManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private StudentMsDb _db;

        public AdminController()
        {
            _db = new StudentMsDb();
        }

        // GET: Admin
        public async Task<ActionResult> Index()
        {
            var teachers = await _db.Teachers.ToListAsync();
            var courses = await _db.Courses.ToListAsync();
            var department = await _db.Departments.ToListAsync();

            var allStudent = await _db.Students.ToListAsync();

            var pendingStudent = _db.ApplicationStatuses
                .Include(status => status.ApplicationForm)    
                .Where(w=>w.IsAccepted == null)
                .Select(applicationStatuse => applicationStatuse.ApplicationForm.Student)
                .ToList();

            var approvedStudent = _db.ApplicationStatuses
                .Include(status => status.ApplicationForm)
                .Where(w => w.IsAccepted.Value)
                .Select(applicationStatuse => applicationStatuse.ApplicationForm.Student)
                .ToList();                        

           
            AdminIndexViewModel viewModel = new AdminIndexViewModel
            {
                AcceptedStudents = approvedStudent,
                AllStudents = allStudent,
                Departments = department,
                PendingStudents = pendingStudent,
                Teachers = teachers,
                Courses = courses
            };

            return View("Dashboard",viewModel);
        }

        public ActionResult Students()
        {
            throw new NotImplementedException();
        }

        public ActionResult Teachers()
        {
            throw new NotImplementedException();
        }

        public ActionResult Courses()
        {
            throw new NotImplementedException();
        }
    }
}