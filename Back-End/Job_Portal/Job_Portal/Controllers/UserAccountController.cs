using Business_Logic_Layer.IServices;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

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
            try
            {
                var res = await userAccountService.GetAccount(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetJobApplications(int id)
        {
            try
            {
                var res = await userAccountService.GetJobApplicationById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUser([FromQuery] Login login)
        {
            try
            {
                var res = await userAccountService.GetUser(login);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var res = await userAccountService.GetAllUsers();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(RegisterUser account)
        {
            try
            {
                var res = await userAccountService.CreateAccount(account);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    message = "Email already exists!",
                    msg = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAccount(UserAccount updatedAccount)
        {
            try
            {
                var res = await userAccountService.UpdateAccount(updatedAccount);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserStatus(UpdateUserStatus status)
        {
            try
            {
                var res = await userAccountService.UpdateUserStatus(status);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAccount(DeleteInfo deleteInfo)
        {
            try
            {
                var res = await userAccountService.DeleteAccount(deleteInfo);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<ActionResult> ResetPassword(ResetPassword password)
        {
            try
            {
                var res = await userAccountService.ResetPassword(password);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }
    }
}
