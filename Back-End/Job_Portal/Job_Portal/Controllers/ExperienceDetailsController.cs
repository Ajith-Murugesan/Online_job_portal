using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("ExperienceDetails/[action]")]
    [ApiController]
    public class ExperienceDetailsController : ControllerBase
    {
        private readonly IExperienceDetailsService _experienceDetailsService;

        public ExperienceDetailsController(IExperienceDetailsService experienceDetailsService)
        {
            _experienceDetailsService = experienceDetailsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _experienceDetailsService.GetExperienceDetails(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _experienceDetailsService.GetAllExperienceDetails();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExperienceDetails(ExperienceDetails experienceDetails)
        {
            var res = await _experienceDetailsService.CreateExperienceDetails(experienceDetails);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateExperienceDetails(ExperienceDetails updatedExperienceDetails)
        {
            var res = await _experienceDetailsService.UpdateExperienceDetails(updatedExperienceDetails);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExperienceDetails(int id)
        {
            var res = await _experienceDetailsService.DeleteExperienceDetails(id);
            return Ok(res);
        }
    }
}
