using Business_Logic_Layer.Services;
using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Job_Portal.Controllers
{
    [Route("SeekerProfile/[action]")]
    [ApiController]
    public class SeekerProfileController : ControllerBase
    {
        private readonly ISeekerProfileService _seekerProfileService;

        public SeekerProfileController(ISeekerProfileService seekerProfileService)
        {
            _seekerProfileService = seekerProfileService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var res = await _seekerProfileService.GetSeekerProfile(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var res = await _seekerProfileService.GetAllSeekerProfiles();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetInterviewInviteById(int id)
        {
            try
            {
                var res = await _seekerProfileService.GetInterviewsById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateSeekerProfile(SeekerProfile seekerProfile)
        {
            try
            {
                var res = await _seekerProfileService.CreateSeekerProfile(seekerProfile);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateInterviewInvite(EmailInvite invite)
        {
            try
            {
                var res = await _seekerProfileService.CreateInterviewInvite(invite);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSeekerProfile(SeekerProfile updatedSeekerProfile)
        {
            try
            {
                var res = await _seekerProfileService.UpdateSeekerProfile(updatedSeekerProfile);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AcceptInvite(int id)
        {
            try
            {
                var res = await _seekerProfileService.AcceptInvite(id);
                return Ok(new
                {
                    message = res
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> DeclineInvite(int id)
        {
            try
            {
                var res = await _seekerProfileService.DeclineInvite(id);
                return Ok(new
                {
                    message = res
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeekerProfile(int id)
        {
            try
            {
                var res = await _seekerProfileService.DeleteSeekerProfile(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
