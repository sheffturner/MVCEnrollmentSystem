using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnrollmentApp.Models
{
    public class Student
    {
            public int StudentID { get; set; }
            public int AddressID { get; set; }
            public int MajorID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string Major { get; set; }
            public string Year { get; set; }
            public string DOB { get; set; }
            [DataType(DataType.PhoneNumber)]
            [RegularExpression("^(\\([0-9]{3}\\) |[0-9]{3}-)[0-9]{3}-[0-9]{4}$", ErrorMessage = "Please enter valid phone no.")]
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public decimal GPA { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Zip { get; set; }
            public string State { get; set; }
            public string Country { get; set; }

    }
}