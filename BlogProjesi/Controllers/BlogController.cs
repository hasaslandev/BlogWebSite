using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace BlogProjesi.Controllers
{
    public class BlogController : Controller
    {
        IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public PartialViewResult BlogList(int page = 1)
        {
            int pageSize = 8;

            var blogDataResult = _blogService.GetAll();
            var blogList = blogDataResult.Data;

            var pagedBlogList = blogList.ToPagedList(page, pageSize);

            return PartialView(pagedBlogList);
        }
        public PartialViewResult FeaturedPosts()
        {
            //1.post
            var blogDataResult = _blogService.GetAll();
            var blogList = blogDataResult.Data;

            var post = blogList.OrderByDescending(z => z.BlogID).FirstOrDefault(x => x.CategoryID == 1);
            var posttitle1 = post?.BlogTitle;
            var postimage1 = post?.BlogImage;
            var postdate1 = post?.BlogDate;

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;

            //var posttitle2 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            //var postimage2 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            //var postdate2 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            //ViewBag.posttitle2 = posttitle2;
            //ViewBag.postimage2 = postimage2;
            //ViewBag.postdate2 = postdate2;
           
            //var posttitle3 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            //var postimage3 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            //var postdate3 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            //ViewBag.posttitle3 = posttitle3;
            //ViewBag.postimage3 = postimage3;
            //ViewBag.postdate3 = postdate3;
       
            //var posttitle4 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            //var postimage4 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            //var postdate4 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            //ViewBag.posttitle4 = posttitle4;
            //ViewBag.postimage4 = postimage4;
        
            //var posttitle5 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            //var postimage5 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            //var postdate5 = _blogService.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            //ViewBag.posttitle5 = posttitle5;
            //ViewBag.postimage5 = postimage5;
            //ViewBag.postdate5 = postdate5;
            return PartialView();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = _blogService.GetBlogById(id);
            return PartialView(BlogDetailsList);
        }
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = _blogService.GetBlogById(id);
            return PartialView(BlogDetailsList);
        }
        //public ActionResult BlogByCategory(int id)
        //{
        //    var BlogListByCategory = _blogService.GetBlogByCategory(id);
        //    var CategoryName1 = _blogService.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
        //    ViewBag.CategoryName1 = CategoryName1;
        //    return View(BlogListByCategory);
        //}
        public ActionResult AdminBlogList()
        {
            var bloglist = _blogService.GetAll();
            return View(bloglist);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist2 = _blogService.GetAll();
            return View(bloglist2);
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            LocalContext c = new LocalContext();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            _blogService.Add(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            _blogService.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = _blogService.FindBlog(id);
            LocalContext c = new LocalContext();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            _blogService.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentDal());
            var commentList = cm.CommentById(id);
            return View(commentList);
        }







        public IActionResult Index()
        {
            var result = _blogService.GetAll();
            if (result != null)
            {
                if (result.Success)
                {
                    return View(result.Data);
                }
                else
                {
                    return View(result.Message);
                }
            }
            else
            {
                // Handle the case where result is null
                return View("Error");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _blogService.GetAll();
            if (result.Success)
            {
                return Ok(result);//result. konusuna biraz bak
            }
            return BadRequest(result);
        }
        [HttpPost]//Buraları test et isim ver vs
        public IActionResult Post(Blog blog)
        {
            var result = _blogService.Add(blog);
            if (result.Success)
            {
                return Ok(result);//result. konusuna biraz bak
            }
            return BadRequest(result);
        }

    }
}
