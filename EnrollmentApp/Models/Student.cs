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
            [Required]
            public string UserName { get; set; }
            public int AddressID { get; set; }
            public int MajorID { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string Gender { get; set; }
            [Required]
            public string Major { get; set; }
            public string Year { get; set; }
            [Required]
            public string DOB { get; set; }
            [Required]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression("^(\\([0-9]{3}\\) |[0-9]{3}-)[0-9]{3}-[0-9]{4}$", ErrorMessage = "Please enter valid phone no.")]
            public string PhoneNumber { get; set; }
            [Required]
            public string Email { get; set; }
            public decimal GPA { get; set; }
            [Required]
            public string Street { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            public string Zip { get; set; }
            [Required]
            public string State { get; set; }
            [Required]
            public string Country { get; set; }

            public string FullName
            {
                get
                {
                    return FirstName + " " + LastName;
                }
            }

    }
}