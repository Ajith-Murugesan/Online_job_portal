using Data_Access_Layer.Models;

namespace Business_Logic_Layer.IServices
{
    public interface IJobLocationService
    {
        Task<JobLocation> GetJobLocation(int locationId);
        Task<ICollection<JobLocation>> GetAllJobLocations();
        Task<JobLocation> CreateJobLocation(JobLocation jobLocation);
        Task<JobLocation> UpdateJobLocation(JobLocation updatedJobLocation);
        Task<string> DeleteJobLocation(int locationId);
    }
}
