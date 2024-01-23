using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            var res = await _seekerProfileService.GetSeekerProfile(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _seekerProfileService.GetAllSeekerProfiles();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInterviewInviteById(int id)
        {
            var res = await _seekerProfileService.GetInterviewsById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSeekerProfile(SeekerProfile seekerProfile)
        {
            var res = await _seekerProfileService.CreateSeekerProfile(seekerProfile);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult> CreateInterviewInvite(EmailInvite invite)
        {
            var res = await _seekerProfileService.CreateInterviewInvite(invite);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSeekerProfile(SeekerProfile updatedSeekerProfile)
        {
            var res = await _seekerProfileService.UpdateSeekerProfile(updatedSeekerProfile);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeekerProfile(int id)
        {
            var res = await _seekerProfileService.DeleteSeekerProfile(id);
            return Ok(res);
        }
    }
}
