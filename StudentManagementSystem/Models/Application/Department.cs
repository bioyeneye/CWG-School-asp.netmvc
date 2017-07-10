namespace StudentManagementSystem.Models.Application
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Department Entity
    /// </summary>
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [DisplayName("Department")]
        public string Name { get; set; }

    }
}