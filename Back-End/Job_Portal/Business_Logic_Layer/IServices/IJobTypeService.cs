using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.IServices
{
    public interface IJobTypeService
    {
        Task<JobType> GetJobType(int jobTypeId);
        Task<ICollection<JobType>> GetAllJobTypes();
        Task<JobType> CreateJobType(JobType jobType);
        Task<JobType> UpdateJobType(JobType updatedJobType);
        Task<string> DeleteJobType(int jobTypeId);
    }
}
