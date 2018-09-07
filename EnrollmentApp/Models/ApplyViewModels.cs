using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.WebPages;
using Microsoft.AspNet.Identity;

namespace EnrollmentApp.Models
{
    public class ApplyViewModels : Student
    {
            public new Gender Gender { get; set; }
            public new Major? Major { get; set; }
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