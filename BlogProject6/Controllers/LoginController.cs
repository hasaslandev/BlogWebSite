using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace BlogProject6.Controllers
{

    public class LoginController : Controller
    {

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            LocalContext c = new LocalContext();
            var userinfo = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (userinfo !=null)
            {
                //FormsAuthentication.SetAuthCookie(userinfo.UserName, false);
                //Session["UserName"] = userinfo.UserName.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}