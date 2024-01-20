using Business_Logic_Layer.IServices;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class JobTypeService:IJobTypeService
    {
        private readonly IJobTypeRepository _jobTypeRepository;

        public JobTypeService(IJobTypeRepository jobTypeRepository)
        {
            _jobTypeRepository = jobTypeRepository;
        }

        public async Task<JobType> GetJobType(int jobTypeId)
        {
            return await _jobTypeRepository.GetJobType(jobTypeId);
        }

        public async Task<ICollection<JobType>> GetAllJobTypes()
        {
            return await _jobTypeRepository.GetAllJobTypes();
        }

        public async Task<JobType> CreateJobType(JobType jobType)
        {
            return await _jobTypeRepository.CreateJobType(jobType);
        }

        public async Task<JobType> UpdateJobType(JobType updatedJobType)
        {
            return await _jobTypeRepository.UpdateJobType(updatedJobType);
        }

        public async Task<string> DeleteJobType(int jobTypeId)
        {
            return await _jobTypeRepository.DeleteJobType(jobTypeId);
        }
    }
}
