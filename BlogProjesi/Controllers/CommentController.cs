using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
