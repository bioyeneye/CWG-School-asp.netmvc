namespace StudentManagementSystem.Repositories.Student
{
    using System.Collections.Generic;
    using Models.Application;

    /// <summary>
    /// Contract for the student repository
    /// </summary>
    public interface IStudentRepositoryContract
    {
        /// <summary>
        /// Checks admission status
        /// </summary>
        /// <returns>True if accepted else false</returns>
        bool CheckApplicationStatus();

        /// <summary>
        /// Apply for admission in the school using the application/registration form
        /// </summary>
        /// <param name="applicationForm">Form filled by the student</param>
        /// <returns>True if sent else false</returns>
        bool ApplyForAdmission(ApplicationForm applicationForm);

        /// <summary>
        /// Check application status
        /// </summary>
        /// <param name="applicationStatus">Application Status</param>
        /// <returns>True for approved, False for declined, Null for not touch</returns>
        bool CheckStatus(ApplicationStatus applicationStatus);

        /// <summary>
        /// Gets all pending students waiting for approve
        /// </summary>
        /// <returns>Students list that are pending for acceptance</returns>
        IEnumerable<Student> PendingStudents();

        /// <summary>
        /// Gets all the approved students
        /// </summary>
        /// <returns>Students list that are approved</returns>
        IEnumerable<Student> ApprovedStudents();

        /// <summary>
        /// Gets all rejected students
        /// </summary>
        /// <returns>Student list that are regected</returns>
        IEnumerable<Student> RejectedStudents();
    }
}
