namespace StudentManagementSystem.Models.Application
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Status entity
    /// </summary>
    public class ApplicationStatus
    {
        public int Id { get; set; }

        public bool? IsAccepted { get; set; }

        public ApplicationForm ApplicationForm { get; set; }
        public int ApplicationFormId { get; set; }

        public Teacher Teacher { get; set; }
        public int? TeacherId { get; set; }

    }
}