using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.ApplicationForm
{
    using System.Collections.Generic;
    using Contracts;
    using Models.Application;

    /// <summary>
    /// Application form entity repository for application form operations
    /// </summary>
    public class EntityApplicationFormRepository : IApplicationFormRepositoryContract, IRepositoryBase<Models.Application.ApplicationForm>
    {
        public ApplicationForm StudntApplicationForm(Student student)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ApplicationForm> DepartmentApplicationForms(Department department)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApplicationForm> GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ApplicationForm>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Insert(ApplicationForm entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(ApplicationForm entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(ApplicationForm entity)
        {
            throw new System.NotImplementedException();
        }
    }
}