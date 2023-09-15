using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthRegisteredVisitorController : ControllerBase
    {
        private IAuthRegisteredVisitorService _authRegisteredVisitorService;

        public AuthRegisteredVisitorController(IAuthRegisteredVisitorService authRegisteredVisitorService)
        {
            _authRegisteredVisitorService = authRegisteredVisitorService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authRegisteredVisitorService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authRegisteredVisitorService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authRegisteredVisitorService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authRegisteredVisitorService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authRegisteredVisitorService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
