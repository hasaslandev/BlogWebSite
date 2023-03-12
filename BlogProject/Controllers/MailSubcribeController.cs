using BusinessLayer.Concrete;
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
        // GET: MailSubcribe
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail subscribeMail)
        {
            SubscribeMailManager subscribeMailManager =new  SubscribeMailManager();
            subscribeMailManager.BLAdd(subscribeMail);
            return PartialView();
        }
    }
}