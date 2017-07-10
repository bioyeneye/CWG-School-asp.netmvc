using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Data
{
    /// <summary>
    /// Singleton class for the student management system database
    /// </summary>
    public class StudentMsDbSingleton
    {
        private static StudentMsDb _studentMsDb;

        public StudentMsDbSingleton()
        {
            
        }

        /// <summary>
        /// Aids single instance database for the application
        /// </summary>
        /// <returns>Returns single instance of the database if is null it creates a new database object else returns created one</returns>
        public static StudentMsDb SingletonStudentDb()
        {
            return _studentMsDb ?? StudentMsDb.Create();
        }
    }
}