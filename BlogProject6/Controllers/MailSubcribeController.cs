using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace BlogProject6.Controllers
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