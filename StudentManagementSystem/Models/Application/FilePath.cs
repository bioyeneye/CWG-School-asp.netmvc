namespace StudentManagementSystem.Models.Application
{
    using System.ComponentModel.DataAnnotations;

    public class FilePath
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }
        public FileType FileType { get; set; }
        
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
    }

    public enum FileType
    {
        Avatar = 1, Photo = 2 , Pdf = 3
    }
}