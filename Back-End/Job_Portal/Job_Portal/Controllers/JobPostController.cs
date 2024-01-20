using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("JobPost/[action]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly IJobPostService _jobPostService;

        public JobPostController(IJobPostService jobPostService)
        {
            _jobPostService = jobPostService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _jobPostService.GetJobPost(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _jobPostService.GetAllJobPosts();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> CreateJobPost(JobPost jobPost)
        {
            var res = await _jobPostService.CreateJobPost(jobPost);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateJobPost(JobPost updatedJobPost)
        {
            var res = await _jobPostService.UpdateJobPost(updatedJobPost);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobPost(int id)
        {
            var res = await _jobPostService.DeleteJobPost(id);
            return Ok(res);
        }
    }
}
