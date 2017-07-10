namespace StudentManagementSystem.Repositories.Teacher
{
    using Models.Application;

    /// <summary>
    /// Contract for the teacher repository
    /// </summary>
    public interface ITeacherRepositoryContract
    {
        bool ApproveStudentApplication(ApplicationForm applicationForm);
    }
}
