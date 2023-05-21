using BlogProject6.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject6.Controllers
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
            return Json(Bloglist());
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