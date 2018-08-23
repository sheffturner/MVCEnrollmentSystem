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

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post([FromBody]string value)
        {
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
