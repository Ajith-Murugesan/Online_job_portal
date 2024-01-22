using Data_Access_Layer.DTOs;
using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;

namespace Business_Logic_Layer.IServices
{
    public interface IJobPostService
    {
        Task<ICollection<JobpostDetails>> GetJobPostById(int jobPostId);
        Task<ICollection<JobpostDetails>> GetJobPost();
        Task<ICollection<JobPost>> GetAllJobPosts();
        Task<JobPost> CreateJobPost(JobPost jobPost);
        Task<JobPost> UpdateJobPost(JobPost updatedJobPost);
        Task<UpdateUserStatusResponse> DeleteJobPost(int jobPostId);
    }
}
