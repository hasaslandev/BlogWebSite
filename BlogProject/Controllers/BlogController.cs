using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult BlogList()
        {
            var bloglist = bm.GetAll();
            return PartialView(bloglist);
        }
        public PartialViewResult FeaturedPosts()
        {
            return PartialView();
        } 
        public PartialViewResult MailSubscribe()
        {
            return PartialView();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
        public PartialViewResult BlogCover()
        {
            return PartialView();
        } 
        public PartialViewResult BlogReadAll()
        {
            return PartialView();
        }
        public ActionResult BlogByCategory()
        {
            return View();
        }
    }
}