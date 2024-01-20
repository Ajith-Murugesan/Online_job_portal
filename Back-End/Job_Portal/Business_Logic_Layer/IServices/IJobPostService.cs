using Data_Access_Layer.Models;

namespace Business_Logic_Layer.IServices
{
    public interface IJobPostService
    {
        Task<JobPost> GetJobPost(int jobPostId);
        Task<ICollection<JobPost>> GetAllJobPosts();
        Task<JobPost> CreateJobPost(JobPost jobPost);
        Task<JobPost> UpdateJobPost(JobPost updatedJobPost);
        Task<string> DeleteJobPost(int jobPostId);
    }
}
