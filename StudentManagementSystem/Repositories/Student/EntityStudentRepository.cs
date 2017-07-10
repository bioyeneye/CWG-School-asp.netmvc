using System.Linq;
using System.Threading.Tasks;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Application;

namespace StudentManagementSystem.Repositories.Student
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models.Application;
    using System.Data.Entity;

    /// <summary>
    /// Student entity repository for student operations
    /// </summary>
    public class EntityStudentRepository : IStudentRepositoryContract, IRepositoryBase<Models.Application.Student>
    {
        private StudentMsDb _studentMsDb;
        public EntityStudentRepository()
        {
            _studentMsDb = StudentMsDbSingleton.SingletonStudentDb();
        }

        public Task<Student> GetById(int? id)
        {
            return _studentMsDb.Students.FindAsync(id);
        }

        public Task<List<Student>> GetAll()
        {
            return _studentMsDb.Students.Include(s => s.ApplicationUser).ToListAsync();
        }

        public Task<int> Insert(Student entity)
        {
            _studentMsDb.Students.Add(entity);
            return _studentMsDb.SaveChangesAsync();
        }

        public Task<int> Update(Student entity, int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Student entity)
        {
            throw new NotImplementedException();
        }


        public bool CheckApplicationStatus()
        {
            throw new NotImplementedException();
        }

        public bool ApplyForAdmission(ApplicationForm applicationForm)
        {
            throw new NotImplementedException();
        }

        public bool CheckStatus(ApplicationStatus applicationStatus)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> PendingStudents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> ApprovedStudents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> RejectedStudents()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByUserId(string getUserId)
        {
            return _studentMsDb.Students.FirstOrDefaultAsync(s => s.ApplicationUserId == getUserId);
        }
    }
}