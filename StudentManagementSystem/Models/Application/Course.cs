namespace StudentManagementSystem.Models.Application
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Course entity for course details
    /// </summary>
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Course name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
       
        [DisplayName("Department")]
        public Department Department { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }
    }
}