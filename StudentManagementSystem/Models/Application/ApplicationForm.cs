using System.ComponentModel;

namespace StudentManagementSystem.Models.Application
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Application Entity
    /// </summary>
    public class ApplicationForm
    {
        public int Id { get; set; }

        public Student Student { get; set; }
        public int? StudentId { get; set; }
        
        public Department Department { get; set; }

        [DisplayName("Select department")]
        public int DepartmentId { get; set; }

        /*public FilePath OlevelFilePath { get; set; }

        public FilePath JambFilePath { get; set; }
*/      
        [Required(ErrorMessage = "Field is important, it will be used for application approver")]
        [DisplayName("Tell us about You")]
        public string AboutYou { get; set; }
    }
}