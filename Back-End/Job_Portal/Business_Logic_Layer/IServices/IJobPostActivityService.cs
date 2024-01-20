using Data_Access_Layer.Models;

namespace Business_Logic_Layer.IServices
{
    public interface IJobPostActivityService
    {
        Task<JobPostActivity> GetJobPostActivity(int userAccountId, int jobPostId);
        Task<ICollection<JobPostActivity>> GetAllJobPostActivities();
        Task<JobPostActivity> ApplyToJobPost(JobPostActivity jobPostActivity);
        Task<string> WithdrawApplication(int userAccountId, int jobPostId);
    }
}
