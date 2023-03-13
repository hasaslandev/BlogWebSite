using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(); 
        public ActionResult Index()
        {
            var Cvalues = categoryManager.GetAll();
            return View(Cvalues);
        }
        public PartialViewResult BlogDetailsCategoryList()
        {
            var Cvalues = categoryManager.GetAll();
            return PartialView(Cvalues);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist = categoryManager.GetAll().Distinct();
            return View(categorylist);
        }
    }
}