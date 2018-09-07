using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentApp.Models
{
    public class CourseSearchViewModels
    {
        public int CourseID { get; set; }
        public String Name { get; set; }
        public String Number { get; set; }
        public String Day { get; set; }
        public String Time { get; set; }
        public String Room { get; set; }
        public Major? Major { get; set; }
    }

}