using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;

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
            var res = await _jobLocationService.GetJobLocation(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _jobLocationService.GetAllJobLocations();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> CreateJobLocation(JobLocation jobLocation)
        {
            var res = await _jobLocationService.CreateJobLocation(jobLocation);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateJobLocation(JobLocation updatedJobLocation)
        {
            var res = await _jobLocationService.UpdateJobLocation(updatedJobLocation);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobLocation(int id)
        {
            var res = await _jobLocationService.DeleteJobLocation(id);
            return Ok(res);
        }
    }
}
