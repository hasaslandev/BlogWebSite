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
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}