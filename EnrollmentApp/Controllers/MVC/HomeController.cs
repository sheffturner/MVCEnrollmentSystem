using EnrollmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        StudentController s = new StudentController();

        public ActionResult Student()
        {
            string username = User.Identity.Name;
            return View(s.Get(username));
        }

        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //
        // GET: /Home/Apply
        [AllowAnonymous]
        public ActionResult Apply()
        {
            return View();
        }

        //
        // POST: /Home/Apply
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(ApplyViewModels student)
        {
            bool var = s.Post(student);

            if (var == true)
            {
                return RedirectToAction("Student", "Home");
            }
            return View(student);
        }


    }
}