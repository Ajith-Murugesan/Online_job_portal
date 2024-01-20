using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("JobType/[action]")]
    [ApiController]
    public class JobTypeController : ControllerBase
    {
        private readonly IJobTypeService _jobTypeService;

        public JobTypeController(IJobTypeService jobTypeService)
        {
            _jobTypeService = jobTypeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _jobTypeService.GetJobType(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _jobTypeService.GetAllJobTypes();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> CreateJobType(JobType jobType)
        {
            var res = await _jobTypeService.CreateJobType(jobType);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateJobType(JobType updatedJobType)
        {
            var res = await _jobTypeService.UpdateJobType(updatedJobType);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobType(int id)
        {
            var res = await _jobTypeService.DeleteJobType(id);
            return Ok(res);
        }
    }
}
