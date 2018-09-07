using Dapper;
using EnrollmentApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EnrollmentApp.DAL
{
    public class CourseRepository
    {
        public List<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourses(string coursenumber, string major)
        {
            List<Course> course = new List<Course>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
                string sql = "dbo.spCourse_GetCourses";
                course = connection.Query<Course>(sql,
                    new
                    {
                        CourseNumber = coursenumber,
                        Major = major
                    }, commandType: CommandType.StoredProcedure).ToList();

                if (course == null)
                {
                    return null;
                }
                else
                {
                    return course;
                }

            }
        }


        public List<Course> GetStudentCourses(int studentid)
        {
            List <Course> course = new List<Course>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
                string sql = "dbo.spStudentCourse_GeetStudentCourses";
                course = connection.Query<Course>(sql,
                    new
                    {
                        StudentID = studentid
                    }, commandType: CommandType.StoredProcedure).ToList();

                if (course == null)
                {
                    return null;
                }
                else
                {
                    
                    return course;
                }

            }
        }
        

        public bool InsertStudentCourse(int studentid, int courseid)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
                string sql = "dbo.spStudentCourse_InsertStudentCourse";
                int rowsAffected = connection.Execute(sql,
                    new
                    {
                        StudentID = studentid,
                        CourseID = courseid,
                    }, commandType: CommandType.StoredProcedure);

                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public bool DeleteStudentCourse(int studentid, int courseid)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {
                string sql = "dbo.spStudentCourse_DeleteStudentCourse";
                int rowsAffected = connection.Execute(sql,
                    new
                    {
                        StudentID = studentid,
                        CourseID = courseid,
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

        public int GetStudentCount(string username)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("App1DB")))
            {

                string sql = String.Format("Select Count(*) from dbo.Student Where Student.UserName = '{0}'", username);
                var output = connection.Query<int>(sql);
                return output.First();
            }
        }
    }
}