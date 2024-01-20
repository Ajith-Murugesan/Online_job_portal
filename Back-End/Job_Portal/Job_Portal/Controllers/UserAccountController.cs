using Business_Logic_Layer.IServices;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("UserAccount/[action]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService userAccountService;

        public UserAccountController(IUserAccountService _userAccountService)
        {
            userAccountService = _userAccountService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await userAccountService.GetAccount(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await userAccountService.GetAllUsers();
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser(RegisterUser account)
        {
            var res = await userAccountService.CreateAccount(account);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAccount(UserAccount updatedAccount)
        {
            var res = await userAccountService.UpdateAccount(updatedAccount);
            return Ok(res);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserStatus(int id)
        {
            var res = await userAccountService.UpdateUserStatus(id);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAccount(int userId)
        {
            var res = await userAccountService.DeleteAccount(userId);
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult> ResetPassword(ResetPassword password)
        {
            var res = await userAccountService.ResetPassword(password);
            return Ok(res);
        }
    }
}
