using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager();
        public PartialViewResult Index()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(Contact p)
        {
            cm.BLContactAdd(p);
            return PartialView();
        }
        public ActionResult SendBox()
        {
            var messagelist = cm.GetAll();
            return View(messagelist);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact contact = cm.GetContactDetails(id);
            return View(contact);
        }
    }
}