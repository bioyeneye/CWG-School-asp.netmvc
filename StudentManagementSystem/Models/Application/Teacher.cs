namespace StudentManagementSystem.Models.Application
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Teacher entity
    /// </summary>
    public class Teacher
    {
        public Teacher()
        {
            Courses = new List<Course>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Teacher name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email address is important")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address")]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}