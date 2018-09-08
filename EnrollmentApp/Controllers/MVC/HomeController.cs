using EnrollmentApp.Controllers.API;
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

        //Student WebAPI
        StudentController s = new StudentController();
        //Course WebAPI
        CourseController c = new CourseController();

        public ActionResult Student()
        {
            string username = User.Identity.Name;
            return View(s.Get(username));
        }

        public ActionResult StudentCourses()
        {
            
            return View();
        }

        //
        // GET Home/CourseSearch
        public ActionResult CourseSearch()
        {
            return View();
        }

        //Action used for AJAX operation (Get Course By Major and/or Course Number). It returns a partial view).
        [HttpGet]
        public ActionResult CourseSearchByMajorOrCourseNo(CourseSearchViewModels obj)
        {
            string maja = Enum.GetName(typeof(Major), obj.Major);
            string cn = obj.Number;
            if (cn == null && maja != null)
            {
                return PartialView("_CourseSearchPartial", c.GetCourseByMajor(maja));
            }
            else
            {
                return PartialView("_CourseSearchPartial", c.GetCourseByNumber(cn));
            }
        }

        // This action is called when Home/AddDropCourses (page) receives a request.
        // GET Home/AddDropCourses
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult AddDropCourses()
        {
            return View(c.GetCourseByMajor());
        }

        // This action is called when Home/AddDropCourses (page) receives a request.
        public ActionResult _DropCoursePartial()
        {
            string username = User.Identity.Name;
            int si = s.Get(username).StudentID;
            List<Course> course = c.GetStudentCourses(si);
            if (course.Count() == 0)
            {
                return PartialView("_DropCoursePartial");
            }
            else
            {
                return PartialView("_DropCoursePartial", c.GetStudentCourses(si));
            }
        }

        // This action is called when Home/Student (page) receives a request.
        // It returns the class schedule partial
        public ActionResult _ClassSchedulePartial()
        {
            string username = User.Identity.Name;
            int si = s.Get(username).StudentID;
            List<Course> course = c.GetStudentCourses(si);
            if (course.Count() == 0)
            {
                return PartialView("_ClassSchedulePartial");
            }
            else
            {
                return PartialView("_ClassSchedulePartial", c.GetStudentCourses(si));
            }
        }

        // This action is called when a user "adds" a course to their couse schedule.
        // It adds the selected course to the students_course table.
        //Action used for AJAX operation (Display courses the student added. It returns a partial view).
        // POST: /Home/AddDropCourses
        [HttpPost]
        public ActionResult AddStudentCourses(int courseid)
        {

            string username = User.Identity.Name;
            int si = s.Get(username).StudentID;

            List<Course> lc = c.GetStudentCourses(si);
            List<Course> check = lc.Where(p => p.CourseID == courseid).ToList();

            if (check.Count() == 0)
            {
                bool var = c.Post(si, courseid);
            }
            else
            {
                return new HttpStatusCodeResult(404, "Sorry Can't Add! This Course Is In Your Schedule.");
            }

            return PartialView("_DropCoursePartial", c.GetStudentCourses(si));

        }


        // This action is called when a user "drops" a course from their couse schedule.
        // It drops the selected course from the students_course table.
        //Action used for AJAX operation (Displays updated course in class schedule. It returns a partial view).
        // POST: /Home/AddDropCourses
        [HttpPost]
        public ActionResult DeleteStudentCourses(int courseid)
        {

            string username = User.Identity.Name;
            int si = s.Get(username).StudentID;

            bool var = c.Delete(si, courseid);

            return PartialView("_DropCoursePartial", c.GetStudentCourses(si));

        }

        // This action is called when Home/Apply (page) receives a request.
        // GET: /Home/Apply
        [AllowAnonymous]
        public ActionResult Apply()
        {
            return View();
        }

        // This action is called when a user submits an application form from Home/Apply (page).
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