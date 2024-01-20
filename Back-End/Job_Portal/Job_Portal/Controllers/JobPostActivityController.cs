using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.Controllers
{
    [Route("JobPostActivity/[action]")]
    [ApiController]
    public class JobPostActivityController : ControllerBase
    {
        private readonly IJobPostActivityService _jobPostActivityService;

        public JobPostActivityController(IJobPostActivityService jobPostActivityService)
        {
            _jobPostActivityService = jobPostActivityService;
        }

        [HttpGet("{userAccountId}/{jobPostId}")]
        public async Task<ActionResult> Get(int userAccountId, int jobPostId)
        {
            var res = await _jobPostActivityService.GetJobPostActivity(userAccountId, jobPostId);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _jobPostActivityService.GetAllJobPostActivities();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> ApplyToJobPost(JobPostActivity jobPostActivity)
        {
            var res = await _jobPostActivityService.ApplyToJobPost(jobPostActivity);
            return Ok(res);
        }

        [HttpDelete("{userAccountId}/{jobPostId}")]
        public async Task<ActionResult> WithdrawApplication(int userAccountId, int jobPostId)
        {
            var res = await _jobPostActivityService.WithdrawApplication(userAccountId, jobPostId);
            return Ok(res);
        }
    }
}
