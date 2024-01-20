using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Services
{
    public class JobLocationService : IJobLocationService
    {
        private readonly IJobLocationRepository _jobLocationRepository;

        public JobLocationService(IJobLocationRepository jobLocationRepository)
        {
            _jobLocationRepository = jobLocationRepository;
        }

        public async Task<JobLocation> GetJobLocation(int locationId)
        {
            return await _jobLocationRepository.GetJobLocation(locationId);
        }

        public async Task<ICollection<JobLocation>> GetAllJobLocations()
        {
            return await _jobLocationRepository.GetAllJobLocations();
        }

        public async Task<JobLocation> CreateJobLocation(JobLocation jobLocation)
        {
            return await _jobLocationRepository.CreateJobLocation(jobLocation);
        }

        public async Task<JobLocation> UpdateJobLocation(JobLocation updatedJobLocation)
        {
            return await _jobLocationRepository.UpdateJobLocation(updatedJobLocation);
        }

        public async Task<string> DeleteJobLocation(int locationId)
        {
            return await _jobLocationRepository.DeleteJobLocation(locationId);
        }
    }
}
