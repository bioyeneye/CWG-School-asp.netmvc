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
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Models.Application;
using StudentManagementSystem.Models.Application.ViewModel;
using StudentManagementSystem.Repositories.Student;

namespace StudentManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private StudentMsDb db = new StudentMsDb();
        private EntityStudentRepository _studentRepository;

        public StudentsController()
        {
            _studentRepository = new EntityStudentRepository();
        }

        public new async Task<ActionResult> Profile()
        {
            StudentProfileViewModel profileViewModel = new StudentProfileViewModel
            {
                Student = await _studentRepository.GetByUserId(User.Identity.GetUserId())
            };

            profileViewModel.ApplicationForm = await db.ApplicationForms.FirstOrDefaultAsync(f => f.StudentId == profileViewModel.Student.Id);
            profileViewModel.ApplicationStatus = (profileViewModel.ApplicationForm != null)
                ? db.ApplicationStatuses.FirstOrDefault(
                    f => f.ApplicationFormId == profileViewModel.ApplicationForm.Id)
                : null;            

            return View(profileViewModel);            
        }
    
        
        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _studentRepository.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }        

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _studentRepository.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", student.ApplicationUserId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address,Sex,ApplicationUserId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Profile");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", student.ApplicationUserId);
            return View(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
