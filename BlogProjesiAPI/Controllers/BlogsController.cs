using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
           var result = _blogService.GetAll();
            if (result.Success)
            {
                return Ok(result);//result. konusuna biraz bak
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]//Buraları test et isim ver vs
        public IActionResult Add(Blog blog)
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
