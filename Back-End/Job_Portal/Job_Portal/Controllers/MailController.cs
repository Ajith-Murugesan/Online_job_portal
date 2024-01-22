
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("Mail/[action]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        //injecting the IMailService into the constructor
        public MailController(IMailService _MailService)
        {
            _mailService = _MailService;
        }

        [HttpPost]
        public IActionResult SendEmail(string request)
        {
            _mailService.SendEmail(request);
            return Ok();
        }

        [HttpPost]
        public IActionResult EmailInvite(string toEmail,EmailInvite invite)
        {
            _mailService.SendInviteEmail(toEmail,invite);
            return Ok();
        }
    }
}
