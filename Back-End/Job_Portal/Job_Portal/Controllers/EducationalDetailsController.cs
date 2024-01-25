using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
            try
            {
                var res = await _educationalDetailsService.GetEducationalDetails(id);
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
                var res = await _educationalDetailsService.GetAllEducationalDetails();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateEducationalDetails(EducationalDetails educationalDetails)
        {
            try
            {
                var res = await _educationalDetailsService.CreateEducationalDetails(educationalDetails);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEducationalDetails(EducationalDetails updatedEducationalDetails)
        {
            try
            {
                var res = await _educationalDetailsService.UpdateEducationalDetails(updatedEducationalDetails);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEducationalDetails(int id)
        {
            try
            {
                var res = await _educationalDetailsService.DeleteEducationalDetails(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
