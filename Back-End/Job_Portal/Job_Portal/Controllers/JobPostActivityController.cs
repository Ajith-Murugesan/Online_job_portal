using Business_Logic_Layer.IServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
            try
            {
                var res = await _jobPostActivityService.GetJobPostActivity(userAccountId, jobPostId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var res = await _jobPostActivityService.GetJobPostActivityByUserId(id);
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
                var res = await _jobPostActivityService.GetAllJobPostActivities();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> ApplyToJobPost(JobPostActivity jobPostActivity)
        {
            try
            {
                var res = await _jobPostActivityService.ApplyToJobPost(jobPostActivity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{userAccountId}/{jobPostId}")]
        public async Task<ActionResult> WithdrawApplication(int userAccountId, int jobPostId)
        {
            try
            {
                var res = await _jobPostActivityService.WithdrawApplication(userAccountId, jobPostId);
                return Ok(new
                {
                    message = res
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
