using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutImageController : ControllerBase
    {
        IAboutImageService _aboutImageService;

        public AboutImageController(IAboutImageService carImageService)
        {
            _aboutImageService = carImageService;

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _aboutImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _aboutImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int AboutId)
        {
            var result = _aboutImageService.GetByAboutId(AboutId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] AboutImage aboutImage)
        {
            var result = _aboutImageService.Add(file, aboutImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] AboutImage aboutImage)
        {
            var result = _aboutImageService.Update(file, aboutImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(AboutImage aboutImage)
        {
            var result = _aboutImageService.Delete(aboutImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
