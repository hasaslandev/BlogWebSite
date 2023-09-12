using Business.Abstract;
using Entity.Concrete;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System.Net;

namespace BlogProjesiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContackService _contactService;
        public ContactController(IContackService contactService)
        {
               _contactService = contactService;
        }
        [HttpPost("sendmail")]
        public IActionResult SendEmail(Contact request)
        {
            _contactService.SendEmail(request);
            _contactService.Add(request);
            return Ok();
        }

    }
}
