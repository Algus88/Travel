using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travels.Mocks;
using Travels.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Travels.Controllers
{
    public class EmployeeController : Controller
    {
        //EmployeeContext db = new EmployeeContext();
        private ApplicationEmployeeManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationEmployeeManager>();
            }
        }

        // GET: Employee
        public ActionResult Customer()
        {
            return View();
        }
        
        // GET: Employee/Details/5
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string nickName, string password)
        {
            EmployeeMock customers = new EmployeeMock();
          //  var user = customers.Employees.Where(x => x.FirstName == nickName.ToLower() && Verification.VerifyHashedPassword(x.HashedPassword,password)==true).Count();
            var user = UserManager.Users.ToList().Where(x => x.FirstName == nickName.ToLower() && Verification.VerifyHashedPassword(x.HashedPassword, password) == true);
            if (user.Count() == 1)
            {
                if (user.Where(x => x.IsDriver == true).Count() == 1)
                { return RedirectToAction("Driver", "Index"); }
                else { return RedirectToAction("Passenger", "Index"); }
            }
            ViewBag.Message = "Incorrect Login";
            return View("Login");
        }

      
    }
}
