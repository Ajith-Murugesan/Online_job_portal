using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
            try
            {
                var res = await _experienceDetailsService.GetExperienceDetails(id);
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
                var res = await _experienceDetailsService.GetAllExperienceDetails();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateExperienceDetails(ExperienceDetails experienceDetails)
        {
            try
            {
                var res = await _experienceDetailsService.CreateExperienceDetails(experienceDetails);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateExperienceDetails(ExperienceDetails updatedExperienceDetails)
        {
            try
            {
                var res = await _experienceDetailsService.UpdateExperienceDetails(updatedExperienceDetails);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExperienceDetails(int id)
        {
            try
            {
                var res = await _experienceDetailsService.DeleteExperienceDetails(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
