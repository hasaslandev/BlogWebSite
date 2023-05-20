﻿using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class MailSubcribeController : Controller
    {
        SubscribeMailManager subscribeMailManager = new SubscribeMailManager();
        // GET: MailSubcribe
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail subscribeMail)
        {
            subscribeMailManager.BLAdd(subscribeMail);
            return PartialView();
        }
    }
}