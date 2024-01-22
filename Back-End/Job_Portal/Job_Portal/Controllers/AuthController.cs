using Business_Logic_Layer.Services;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("Auth/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        public AuthController(IAuth auth)
        {
            _auth = auth;
        }


        [HttpPost]
        public async Task<ActionResult> Login(Login account)
        {
            var token = await _auth.Login(account);

            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }
        }
    }
}
