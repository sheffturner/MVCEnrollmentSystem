using EnrollmentApp.DAL;
using EnrollmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnrollmentApp.Controllers
{
    public class StudentController : ApiController
    {
        private StudentRepository _studentrepository = new StudentRepository();

        // GET: api/Student
        [Route("api/students")]
        [HttpGet]
        public List<Student> Get()
        {
            return _studentrepository.GetStudents();
        }

        // GET: api/Student/id
        [HttpGet]
        public Student Get(int id)
        {
            return this.Get(id, null);
        }

        // GET: api/Student/username
        [HttpGet]
        public Student Get(string username)
        {
            return this.Get(null, username);
        }

        // GET: api/Student/id?username?
        [HttpGet]
        public Student Get(int? id, string username)
        {
            return _studentrepository.GetSingleStudent(id, username);
        }

        // POST: api/Student
        [Route("api/students")]
        [HttpPost]
        public bool Post([FromBody]ApplyViewModels student)
        {
            string username = User.Identity.Name;
            return _studentrepository.InsertStudent(student, username);
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
