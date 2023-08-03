using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
