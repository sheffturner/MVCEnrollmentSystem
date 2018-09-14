using EnrollmentApp.DAL;
using EnrollmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnrollmentApp.Controllers.API
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private CourseRepository _courserepository = new CourseRepository();
        private StudentRepository _studentrepository = new StudentRepository();

        // GET api/<controller>
        public List<Course> Get()
        {
            return _courserepository.GetCourses();
        }

        [HttpGet]
        [Route("{major}")]
        public List<Course> GetCourseByMajor()
        {
            string username = User.Identity.Name;
            string majorname = _studentrepository.GetStudentMajor(username);
            return this.Get(null, majorname);

        }

        // GET: api/courses/major
        [HttpGet]
        [Route("{major}")]
        public List<Course> GetCourseByMajor(string major)
        {
            return this.Get(null, major);

        }

        // GET: api/students/coursesbycourseno/coursenumber
        [HttpGet]
        [Route("coursesbycourseno/{coursenumber}")]
        public List<Course> GetCourseByNumber(string coursenumber)
        {
            return this.Get(coursenumber, null);
        }

        //Students/major?coursenumber?
        [HttpGet]
        public List<Course> Get(string coursenumber, string major)
        {
            List<Course> c = _courserepository.GetCourses(coursenumber, major);
            if (c == null)
            {
                if (major == null && coursenumber != null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No Courses available for = {0}", coursenumber)),
                        ReasonPhrase = "Courses Not Found"
                    };
                    throw new HttpResponseException(resp);
                }
                else
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No Courses under = {0}", major)),
                        ReasonPhrase = "Courses Not Found"
                    };
                    throw new HttpResponseException(resp);
                }
            }
            return c;
        }

        public List<Course> GetStudentCourses(int studentid)
        {
            return _courserepository.GetStudentCourses(studentid);
        }
       

        public bool Post([FromBody]int studentid, int courseid)
        {
            return _courserepository.InsertStudentCourse(studentid, courseid);
        }

        public bool Delete(int studentid, int courseid)
        {
            return _courserepository.DeleteStudentCourse(studentid, courseid);
        }

    }
}