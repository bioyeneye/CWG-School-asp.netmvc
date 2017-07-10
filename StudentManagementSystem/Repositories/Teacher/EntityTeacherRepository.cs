using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Teacher
{
    using System.Collections.Generic;
    using Contracts;
    using Models.Application;

    /// <summary>
    /// Teacher entity repository for teacher operations
    /// </summary>
    public class EntityTeacherRepository : ITeacherRepositoryContract, IRepositoryBase<Models.Application.Teacher>
    {
        public bool ApproveStudentApplication(ApplicationForm applicationForm)
        {
            throw new System.NotImplementedException();
        }

        public Task<Teacher> GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Teacher>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Insert(Teacher entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Teacher entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(Teacher entity)
        {
            throw new System.NotImplementedException();
        }
    }
}