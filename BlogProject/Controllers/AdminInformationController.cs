using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class AdminInformationController : Controller
    {
        // GET: Adminİnformation
        AdminManager am = new AdminManager();
        public PartialViewResult Index()
        {
            var adminvalues = am.GetAll();
            return PartialView(adminvalues);
        }
    }
}