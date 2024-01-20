using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces
{
    public interface IJobPostRepository
    {
        Task<JobPost> GetJobPost(int jobPostId);
        Task<ICollection<JobPost>> GetAllJobPosts();
        Task<JobPost> CreateJobPost(JobPost jobPost);
        Task<JobPost> UpdateJobPost(JobPost updatedJobPost);
        Task<string> DeleteJobPost(int jobPostId);
    }
}
