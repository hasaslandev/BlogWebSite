using BlogProject.Models;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeResult()
        {
            return Json(Bloglist(),JsonRequestBehavior.AllowGet);
        }
        public List<Class1> Bloglist()
        {
            List<Class1> cs = new List<Class1>();
            using(var c = new LocalContext())
            {
                cs = c.Blogs.Select(x => new Class1
                {
                    BlogName = x.BlogTitle,
                    Rating =x.BlogRating
                }).ToList();
            }

            return cs;
        }
    }
}