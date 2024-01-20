using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Services
{
    public class JobPostService : IJobPostService
    {
        private readonly IJobPostRepository _jobPostRepository;

        public JobPostService(IJobPostRepository jobPostRepository)
        {
            _jobPostRepository = jobPostRepository;
        }

        public async Task<JobPost> GetJobPost(int jobPostId)
        {
            return await _jobPostRepository.GetJobPost(jobPostId);
        }

        public async Task<ICollection<JobPost>> GetAllJobPosts()
        {
            return await _jobPostRepository.GetAllJobPosts();
        }

        public async Task<JobPost> CreateJobPost(JobPost jobPost)
        {
            return await _jobPostRepository.CreateJobPost(jobPost);
        }

        public async Task<JobPost> UpdateJobPost(JobPost updatedJobPost)
        {
            return await _jobPostRepository.UpdateJobPost(updatedJobPost);
        }

        public async Task<string> DeleteJobPost(int jobPostId)
        {
            return await _jobPostRepository.DeleteJobPost(jobPostId);
        }
    }
}
