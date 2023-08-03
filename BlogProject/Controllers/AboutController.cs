﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Footer()
        {
            AboutManager aboutManager = new AboutManager(new EfAboutDal());
            var aboutcontentlist=aboutManager.GetAll();
            return PartialView(aboutcontentlist);
        }
        public PartialViewResult MeetTheTeam()
        {
            return PartialView();
        }
        public ActionResult UpdateAboutList()
        {
            var aboutlist = abm.GetAll();
            return View(aboutlist);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.UpdateAboutBM(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}