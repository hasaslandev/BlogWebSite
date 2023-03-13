using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProject.Controllers
{

    public class LoginController : Controller
    {
        [Authorize]
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var userinfo = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (userinfo !=null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.UserName, false);
                Session["UserName"] = userinfo.UserName.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}