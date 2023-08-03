using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
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
        ICategoryService categoryManager = new CategoryManager(new EfCategoryDal()); 
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