using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Job_Portal.Controllers
{
    [Route("JobLocation/[action]")]
    [ApiController]
    public class JobLocationController : ControllerBase
    {
        private readonly IJobLocationService _jobLocationService;

        public JobLocationController(IJobLocationService jobLocationService)
        {
            _jobLocationService = jobLocationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var res = await _jobLocationService.GetJobLocation(id);
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
                var res = await _jobLocationService.GetAllJobLocations();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateJobLocation(JobLocation jobLocation)
        {
            try
            {
                var res = await _jobLocationService.CreateJobLocation(jobLocation);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateJobLocation(JobLocation updatedJobLocation)
        {
            try
            {
                var res = await _jobLocationService.UpdateJobLocation(updatedJobLocation);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobLocation(int id)
        {
            try
            {
                var res = await _jobLocationService.DeleteJobLocation(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
