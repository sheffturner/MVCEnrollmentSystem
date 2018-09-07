using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentApp.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public int MajorID { get; set; }
        public String Name { get; set; }
        public String Number { get; set; }
        public String Day { get; set; }
        public String Time { get; set; }
        public String Room { get; set; }
    }
}