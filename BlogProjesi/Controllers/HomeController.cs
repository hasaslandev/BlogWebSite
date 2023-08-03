using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
