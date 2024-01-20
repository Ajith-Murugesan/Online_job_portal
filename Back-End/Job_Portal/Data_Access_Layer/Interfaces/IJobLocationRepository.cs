using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces
{
    public interface IJobLocationRepository
    {
        Task<JobLocation> GetJobLocation(int locationId);
        Task<ICollection<JobLocation>> GetAllJobLocations();
        Task<JobLocation> CreateJobLocation(JobLocation jobLocation);
        Task<JobLocation> UpdateJobLocation(JobLocation updatedJobLocation);
        Task<string> DeleteJobLocation(int locationId);
    }
}
