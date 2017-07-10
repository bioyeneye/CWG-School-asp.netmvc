namespace StudentManagementSystem.Repositories.ApplicationForm
{
    using System.Collections.Generic;
    using Models.Application;

    /// <summary>
    /// Contract for the application form repository
    /// </summary>
    interface IApplicationFormRepositoryContract
    {
        /// <summary>
        /// Gets the student application to be approved
        /// </summary>
        /// <param name="student">student detail</param>
        /// <returns>Returns the application form of the student</returns>
        ApplicationForm StudntApplicationForm(Student student);

        /// <summary>
        /// Gets all Departmental application forms
        /// </summary>
        /// <param name="department">department instance</param>
        /// <returns>Returns all the application forms for a particular department</returns>
        IEnumerable<ApplicationForm> DepartmentApplicationForms(Department department);


    }
}
