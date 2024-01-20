using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IJobTypeRepository
    {
        Task<JobType> GetJobType(int jobTypeId);
        Task<ICollection<JobType>> GetAllJobTypes();
        Task<JobType> CreateJobType(JobType jobType);
        Task<JobType> UpdateJobType(JobType updatedJobType);
        Task<string> DeleteJobType(int jobTypeId);
    }
}
