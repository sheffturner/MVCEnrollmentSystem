using EnrollmentApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace EnrollmentApp.DAL
{
    public class StudentRepository
    {    
        // Gets all students enrolled at the university
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
                string sql = "dbo.spStudent_GetStudents";
                students = connection.Query<Student>(sql, commandType: CommandType.StoredProcedure).ToList();

                if (students == null)
                {
                    return null;
                }
                else
                {
                    return students;
                }

            }
        }

        // Gets a single student by either their student id or student username
        public Student GetSingleStudent(int? id, string username)
        {
            Student student = new Student();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
                string sql = "dbo.spStudent_GetSingleStudent";
                student = connection.Query<Student>(sql,
                    new {   StudentID = id,
                            UserName = username
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                   
                if(student == null)
                {
                    return null;
                }
                else
                {
                    return student;
                }
              
            }
        }

        // Inserts a student in the Student table. It takes the username and email used in the apply form as parameters.
        public bool InsertStudent(ApplyViewModels student, string username, string email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
                string sql = "dbo.spStudent_InsertStudentInfo";
                int rowsAffected = connection.Execute(sql, 
                    new {   UserName = username,
                            Email = email,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            DOB = student.DOB,
                            Gender = student.Gender.ToString(),
                            Street = student.Street,
                            City = student.City,
                            Zip = student.Zip,
                            State = student.State,
                            Country = student.Country,
                            PhoneNumber = student.PhoneNumber,
                            Major = student.Major.ToString(),
                    }, commandType: CommandType.StoredProcedure);

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
                
            }
        }

        public bool UpdateCustomer(Student student)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        // GetStudentCount() checks whether a student is currently enrolled at the university.
        // It should return 1 if a username is found.
        public int GetStudentCount(string username)
        {   
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
              
                string sql = String.Format("Select Count(*) from dbo.Student Where Student.UserName = '{0}'", username);
                var output = connection.Query<int>(sql);
                return output.First();
            }
        }

        // Gets the student's major by their student username
        public string GetStudentMajor(string username)
        {
            Student student = new Student();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
               
                string sql = "dbo.spStudent_GetStudentMajor";
                student = connection.Query<Student>(sql,
                    new
                    {
                        UserName = username
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                string output = student.Major;
                return output;
            }
        }
    }
}