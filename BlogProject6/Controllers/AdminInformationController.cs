﻿using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject6.Controllers
{
    public class AdminInformationController : Controller
    {
        // GET: Adminİnformation
        AdminManager am = new AdminManager();
        SkillManager sm = new SkillManager();
        public PartialViewResult About()
        {
            var adminvalues = am.GetAll();
            return PartialView(adminvalues);
        }
        public PartialViewResult Facts()
        {
            var adminvalues = am.GetAll();
            return PartialView(adminvalues);
        }
        public PartialViewResult Skills()
        {
            var adminvalues = sm.GetAll();
            return PartialView(adminvalues);
        }
        public PartialViewResult Resume()
        {
            var adminvalues = am.GetAll();
            return PartialView(adminvalues);
        }
        public PartialViewResult Services()
        {
            var adminvalues = am.GetAll();
            return PartialView(adminvalues);
        }

    }
}