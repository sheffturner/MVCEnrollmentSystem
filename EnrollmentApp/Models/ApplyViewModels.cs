using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.WebPages;
using Microsoft.AspNet.Identity;

namespace EnrollmentApp.Models
{
    public class ApplyViewModels
    {
            public string UserName { get; set; }
            public int AddressID { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Zip { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public int StudentID { get; set; }
            public int MajorID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Gender Gender { get; set; }
            public Major Major { get; set; }
            public string Year { get; set; }
            public string DOB { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public decimal GPA { get; set; }

    }
    public enum Gender
    {
        Male,
        Female
    }

    public enum Major
    {
        CDM,
        Business,
        Science,
        Law,
        Arts
        
    }
}