using StNicholasHospital.Payments.Domain.Interface;
using StNicholasHospital.Payments.Domain.Service;
using StNicholasHospital.Payments.Persistence.Repository;
using StNicholasHospital.Payments.Presentation.App_Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StNicholasHospital.Payments.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly StaffService _staffService;
        private readonly IStaffRepository _staffRepository;
        private readonly string _connectionString;

        public HomeController() : base() 
        {
            _connectionString = ConfigurationManager.ConnectionStrings["StNicholasHospitalConnString"].ConnectionString;
            _staffRepository = new StaffRepository(_connectionString);
            _staffService = new StaffService(_staffRepository);
        }

        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password)
        {
            try {
                var staff = _staffService.GetByID(Username, Password);
                AppHelper.AddStaffToCache(staff);              

                FormsAuthentication.SetAuthCookie(staff.StaffNo, false);
                return RedirectToAction("Index", "Staff");
            }
            catch (Exception) {
                return View(Username, Password);
            }
            
        }

        //[Authorize]
        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login");

        //}
    }
}