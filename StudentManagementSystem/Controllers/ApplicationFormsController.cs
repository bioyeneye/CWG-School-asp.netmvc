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
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Application;
using StudentManagementSystem.Models.Application.ViewModel;

namespace StudentManagementSystem.Controllers
{
    public class ApplicationFormsController : Controller
    {
        private StudentMsDb db = new StudentMsDb();

        // GET: ApplicationForms
        public async Task<ActionResult> Index()
        {
            var applicationForms = db.ApplicationForms.Include(a => a.Department).Include(a => a.Student);
            var statuse = db.ApplicationStatuses.ToList();

            ApplicationFormIndexViewModel applicationFormIndexViewModel = new ApplicationFormIndexViewModel();
            applicationFormIndexViewModel.ApplicationForms = await applicationForms.ToListAsync();
            applicationFormIndexViewModel.ApplicationStatuses = statuse;


            return View(applicationFormIndexViewModel);
        }

        // GET: ApplicationForms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationForm applicationForm = await db.ApplicationForms.FindAsync(id);
            
            if (applicationForm == null)
            {
                return HttpNotFound();
            }

            ApplicationDetailViewModel applicationDetailViewModel = new ApplicationDetailViewModel
            {
                ApplicationForm = applicationForm,
                Student = db.Students.First(w => w.Id == applicationForm.StudentId),
                ApplicationStatus = db.ApplicationStatuses.First(w=> w.Id == applicationForm.Id)
                
            };

            return View(applicationDetailViewModel);
        }

        // GET: ApplicationForms/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var s = db.Students.FirstOrDefault(f => f.ApplicationUserId == userId).Id;
            var form = db.ApplicationForms.FirstOrDefault(f => f.StudentId == s);
            if (form != null) return RedirectToAction("Profile", "Students");

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", "Select Department");
            return View();
        }

        // POST: ApplicationForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StudentId,DepartmentId,AboutYou")] ApplicationForm applicationForm)
        {
            applicationForm.StudentId = 0;
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                applicationForm.StudentId =
                    db.Students.FirstOrDefault(f => f.ApplicationUserId == userId).Id;
                var app = db.ApplicationForms.Add(applicationForm);               
                var value = await db.SaveChangesAsync();

                if (value > 0)
                {
                    ApplicationStatus applicationStatus = new ApplicationStatus
                    {
                        ApplicationFormId = app.Id,
                        IsAccepted = null,
                        TeacherId = null
                    };

                    db.ApplicationStatuses.Add(applicationStatus);
                    await db.SaveChangesAsync();

                }

                return RedirectToAction("Profile", "Students");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", applicationForm.DepartmentId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", applicationForm.StudentId);
            return View(applicationForm);
        }

        // GET: ApplicationForms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationForm applicationForm = await db.ApplicationForms.FindAsync(id);
            if (applicationForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", applicationForm.DepartmentId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", applicationForm.StudentId);
            return View(applicationForm);
        }

        // POST: ApplicationForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StudentId,DepartmentId,AboutYou")] ApplicationForm applicationForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationForm).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", applicationForm.DepartmentId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", applicationForm.StudentId);
            return View(applicationForm);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Approve(int id)
        {
            var applicationStatus = db.ApplicationStatuses.Include(s => s.ApplicationForm)
                .First(f => f.ApplicationFormId == id);

            applicationStatus.IsAccepted = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Reject(int id)
        {
            var applicationStatus = db.ApplicationStatuses.Include(s => s.ApplicationForm)
                .First(f => f.ApplicationFormId == id);

            applicationStatus.IsAccepted = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
