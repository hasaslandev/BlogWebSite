using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject6.Controllers
{
    public class CategoryController : Microsoft.AspNetCore.Mvc.Controller
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