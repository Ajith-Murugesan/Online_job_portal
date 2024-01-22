using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;

namespace Business_Logic_Layer.IServices
{
    public interface IJobPostActivityService
    {
        Task<JobPostActivity> GetJobPostActivity(int userAccountId, int jobPostId);
        Task<ICollection<JobpostDetails>> GetJobPostActivityByUserId(int userAccountId);
        Task<ICollection<JobPostActivity>> GetAllJobPostActivities();
        Task<JobPostActivity> ApplyToJobPost(JobPostActivity jobPostActivity);
        Task<string> WithdrawApplication(int userAccountId, int jobPostId);
    }
}
