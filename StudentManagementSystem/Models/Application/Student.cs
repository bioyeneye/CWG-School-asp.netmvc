using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models.Application
{
    /// <summary>
    /// Student entity 
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public int Sex { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        /*public virtual ICollection<FilePath> FilePaths { get; set; }
        public ApplicationForm ApplicationForm { get; set; }
        public int ApplicationFormId { get; set; }*/

    }    
}