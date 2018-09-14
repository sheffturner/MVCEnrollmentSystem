using EnrollmentApp.DAL;
using EnrollmentApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EnrollmentApp.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        private StudentRepository _studentrepository = new StudentRepository();

        [HttpGet]
        [Route("all")]
        public List<Student> Get()
        {
            return _studentrepository.GetStudents();
        }

        // GET: api/students/id
        [HttpGet]
        [Route("{id}")]
        public Student Get(int id)
        {
            return this.Get(id, null);
     
        }

        // GET: api/students/studentbyusername/username
        [HttpGet]
        [Route("studentbyusername/{username}")]
        public Student Get(string username)
        {
            return this.Get(null, username);
        }

        //Students/id?username?
        [HttpGet]
        public Student Get(int? id, string username)
        {
            Student s = _studentrepository.GetSingleStudent(id, username);
            if (s == null)
            {
                if(id == null && username != null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No Student with Username = {0}", username)),
                        ReasonPhrase = "Student Username Not Found"
                    };
                    throw new HttpResponseException(resp);
                }
                else
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No Student with ID = {0}", id)),
                        ReasonPhrase = "Student ID Not Found"
                    };
                    throw new HttpResponseException(resp);
                }
            }
            return s;
        }

        // POST: api/Students
        [Route("api/students")]
        [HttpPost]
        public bool Post([FromBody]ApplyViewModels student)
        {
            string username = User.Identity.Name;
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(username);
            string email = user.Email;
            return _studentrepository.InsertStudent(student, username, email);
        }

        // PUT: api/Students/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
        }
    }
}
