namespace StudentManagementSystem.Models.Application
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Selected course entity
    /// </summary>
    public class SelectedCourses
    {
        public int Id { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}