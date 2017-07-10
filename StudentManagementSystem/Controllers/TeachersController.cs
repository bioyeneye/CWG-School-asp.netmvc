using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Application;
using StudentManagementSystem.Models.Application.ViewModel;

namespace StudentManagementSystem.Controllers
{
    public class TeachersController : Controller
    {
        private StudentMsDb db = new StudentMsDb();

        // GET: Teachers
        public async Task<ActionResult> Index()
        {
            var teachers = db.Teachers.Include(t => t.ApplicationUser).Include(t => t.Department);
            return View(await teachers.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await db.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }

            TeacherDetailViewModel detailViewModel = new TeacherDetailViewModel();
            detailViewModel.Teacher = teacher;
            detailViewModel.Courses = db.Courses.Where(c => c.DepartmentId == teacher.DepartmentId).ToList();
            return View(detailViewModel);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {            
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,MobileNumber,Email,DepartmentId,ApplicationUserId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    Email = teacher.Email,
                    UserName = teacher.Email,
                    UserType = 2
                };

                var userManager = new UserManager<ApplicationUser>(new
                    UserStore<ApplicationUser>(StudentMsDbSingleton.SingletonStudentDb()));
                var studentResult = await userManager.CreateAsync
                    (applicationUser, teacher.Email);

                if (studentResult.Succeeded)
                {
                    teacher.ApplicationUserId = applicationUser.Id;


                    db.Teachers.Add(teacher);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");


                }           
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", teacher.ApplicationUserId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", teacher.DepartmentId);
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await db.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", teacher.ApplicationUserId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", teacher.DepartmentId);
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,MobileNumber,Email,DepartmentId,ApplicationUserId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", teacher.ApplicationUserId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", teacher.DepartmentId);
            return View(teacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Dashboard()
        {
            var id = User.Identity.GetUserId();

            Teacher teacher = db.Teachers.First(f => f.ApplicationUserId == id);
            List<Course> courses = db.Courses.Where(c => c.DepartmentId == teacher.DepartmentId).ToList();

            TeacherDashboardViewModel teacherDashboardViewModel = new TeacherDashboardViewModel
            {
                Teacher = teacher,
                Courses = courses
            };

            return View("Dashboard",teacherDashboardViewModel)  ;
        }
    }
}
