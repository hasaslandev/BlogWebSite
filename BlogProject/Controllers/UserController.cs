using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProject.Controllers
{

    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}