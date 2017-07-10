using System.Threading.Tasks;
using StudentManagementSystem.Models.Application;

namespace StudentManagementSystem.Repositories.Course
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models;

    /// <summary>
    /// Course entity repository for course operations
    /// </summary>
    public class EntityCourseRepository : ICourseRepositoryContract, IRepositoryBase<Models.Application.Course>
    {
        public IEnumerable<SelectedCourses> SelectedCourseses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Application.Course> TeacherCourses(int teacherId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Application.Course> DepartmentCourses(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Application.Course> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Application.Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(Models.Application.Course entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Models.Application.Course entity, int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Models.Application.Course entity)
        {
            throw new NotImplementedException();
        }
    }
}