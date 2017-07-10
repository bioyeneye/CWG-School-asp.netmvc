using StudentManagementSystem.Models.Application;

namespace StudentManagementSystem.Repositories.Course
{
    using System.Collections.Generic;
    using Models.Application;

    /// <summary>
    /// Contract for the course repository
    /// </summary>
    public interface ICourseRepositoryContract
    {
        /// <summary>
        /// Gets all courses selected students
        /// </summary>
        /// <returns>List of all course selected by the student</returns>
        IEnumerable<SelectedCourses> SelectedCourseses();

        /// <summary>
        /// Gets all courses created by a teacher
        /// </summary>
        /// <param name="teacherId">id of the teacher</param>
        /// <returns>List of all course created by a teacher</returns>
        IEnumerable<Course> TeacherCourses(int teacherId);

        /// <summary>
        /// Gets all courses in a department
        /// </summary>
        /// <param name="departmentId">Id of the department</param>
        /// <returns>List of all course in a department</returns>
        IEnumerable<Course> DepartmentCourses(int departmentId);
    }
}
