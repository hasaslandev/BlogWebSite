using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BlogProject6.Controllers
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
            //FormsAuthentication.SignOut();
            //Session.Abandon();

            //return RedirectToAction("Index", "Login");
        }
    }
}