using EnrollmentApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace EnrollmentApp.DAL
{
    public class StudentRepository
    {

        public List<Student> GetStudents()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
                var output = connection.Query<Student>("SELECT [StudentID],[FirstName],[LastName],[Major],[Year],[GPA] FROM [Student]").ToList();
                return output;
            }
        }

        public Student GetSingleStudent(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Student student)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}