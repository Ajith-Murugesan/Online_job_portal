using Business_Logic_Layer.IServices;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("EducationalDetails/[action]")]
    [ApiController]
    public class EducationalDetailsController : ControllerBase
    {
        private readonly IEducationalDetailService _educationalDetailsService;

        public EducationalDetailsController(IEducationalDetailService educationalDetailsService)
        {
            _educationalDetailsService = educationalDetailsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _educationalDetailsService.GetEducationalDetails(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _educationalDetailsService.GetAllEducationalDetails();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEducationalDetails(EducationalDetails educationalDetails)
        {
            var res = await _educationalDetailsService.CreateEducationalDetails(educationalDetails);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEducationalDetails(EducationalDetails updatedEducationalDetails)
        {
            var res = await _educationalDetailsService.UpdateEducationalDetails(updatedEducationalDetails);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEducationalDetails(int id)
        {
            var res = await _educationalDetailsService.DeleteEducationalDetails(id);
            return Ok(res);
        }
    }
}
