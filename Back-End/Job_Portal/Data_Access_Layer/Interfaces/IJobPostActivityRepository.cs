using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces
{
    public interface IJobPostActivityRepository
    {
        Task<JobPostActivity> GetJobPostActivity(int userAccountId, int jobPostId);
        Task<ICollection<JobPostActivity>> GetAllJobPostActivities();
        Task<JobPostActivity> ApplyToJobPost(JobPostActivity jobPostActivity);
        Task<string> WithdrawApplication(int userAccountId, int jobPostId);
    }
}
