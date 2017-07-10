using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Application;
using StudentManagementSystem.Repositories.Student;

namespace StudentManagementSystem.Helpers
{
    public class IdentityHelper
    {       
        internal static async void SeedIdentities(DbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(RoleNames.ROLE_ADMINISTRATOR))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMINISTRATOR));
            }

            if (!roleManager.RoleExists(RoleNames.ROLE_STUNDENT))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_STUNDENT));
            }

            if (!roleManager.RoleExists(RoleNames.ROLE_TEACHER))
            {
                var roleResult = roleManager.Create(new IdentityRole(RoleNames.ROLE_TEACHER));
            }

            string studentUsername = "student@sms.com";
            string studentPassword = "@Student123";

            string teacherUsername = "teacher@sms.com";
            string teacherPassword = "@Teacher123";

             string adminUsername = "admin@sms.com";
            string adminPassword = "@Admin123";

            ApplicationUser student = userManager.FindByName(studentUsername);
            ApplicationUser teacher = userManager.FindByName(teacherUsername);
            ApplicationUser admin = userManager.FindByName(adminUsername);

            if (student == null)
            {
                student = new ApplicationUser()
                {
                    UserName = studentUsername,
                    Email = studentUsername,
                    EmailConfirmed = true,
                    UserType = 0
                };

                //IdentityResult studentResult = userManager.Create(student, studentPassword);
                var studentResult = await userManager.CreateAsync(student, studentPassword);
                if (studentResult.Succeeded)
                {
                    var result = userManager.AddToRole(student.Id, RoleNames.ROLE_STUNDENT);                    
                }
            }
        }

        public static bool IsStudent(string userId)
        {
            return
                StudentMsDbSingleton.SingletonStudentDb().Users.FirstOrDefault(user => user.Id == userId).UserType == 1;
        }

        public static bool IsTeacher(string userId)
        {
            return StudentMsDbSingleton.SingletonStudentDb().Users.FirstOrDefault(user => user.Id == userId).UserType == 2;
        }

        public static bool IsAdmin(string userId)
        {
            return StudentMsDbSingleton.SingletonStudentDb().Users.FirstOrDefault(user => user.Id == userId).UserType == 3;
        }
    }
}