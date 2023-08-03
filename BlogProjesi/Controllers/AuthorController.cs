using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
