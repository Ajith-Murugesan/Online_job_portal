using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Services
{
    public class JobPostActivityService : IJobPostActivityService
    {
        private readonly IJobPostActivityRepository _jobPostActivityRepository;

        public JobPostActivityService(IJobPostActivityRepository jobPostActivityRepository)
        {
            _jobPostActivityRepository = jobPostActivityRepository;
        }

        public async Task<JobPostActivity> GetJobPostActivity(int userAccountId, int jobPostId)
        {
            return await _jobPostActivityRepository.GetJobPostActivity(userAccountId, jobPostId);
        }

        public async Task<ICollection<JobPostActivity>> GetAllJobPostActivities()
        {
            return await _jobPostActivityRepository.GetAllJobPostActivities();
        }

        public async Task<JobPostActivity> ApplyToJobPost(JobPostActivity jobPostActivity)
        {
            return await _jobPostActivityRepository.ApplyToJobPost(jobPostActivity);
        }

        public async Task<string> WithdrawApplication(int userAccountId, int jobPostId)
        {
            return await _jobPostActivityRepository.WithdrawApplication(userAccountId, jobPostId);
        }
    }
}
