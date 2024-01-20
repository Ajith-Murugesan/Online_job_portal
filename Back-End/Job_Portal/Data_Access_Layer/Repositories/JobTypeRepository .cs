using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class JobTypeRepository:IJobTypeRepository
    {
        private readonly IConfiguration _config;

        public JobTypeRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<JobType> GetJobType(int jobTypeId)
        {
            JobType jobType = new JobType();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT job_type_id, job_type_name FROM job_type WHERE job_type_id = @JobTypeId", con))
                {
                    cmd.Parameters.AddWithValue("@JobTypeId", jobTypeId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            jobType.JobTypeId = reader.GetInt32(0);
                            jobType.JobTypeName = reader.GetString(1);
                        }
                    }
                }
            }

            return jobType;
        }

        public async Task<ICollection<JobType>> GetAllJobTypes()
        {
            List<JobType> jobTypes = new List<JobType>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT job_type_id, job_type_name FROM job_type", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        jobTypes.Add(new JobType
                        {
                            JobTypeId = reader.GetInt32(0),
                            JobTypeName = reader.GetString(1)
                        });
                    }
                }
            }

            return jobTypes;
        }

        public async Task<JobType> CreateJobType(JobType jobType)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO job_type (job_type_name) VALUES (@JobTypeName);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@JobTypeName", jobType.JobTypeName);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return jobType;
        }

        public async Task<JobType> UpdateJobType(JobType updatedJobType)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE job_type SET job_type_name = @JobTypeName WHERE job_type_id = @JobTypeId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@JobTypeId", updatedJobType.JobTypeId);
                    cmd.Parameters.AddWithValue("@JobTypeName", updatedJobType.JobTypeName);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedJobType;
        }

        public async Task<string> DeleteJobType(int jobTypeId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM job_type WHERE job_type_id = @JobTypeId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@JobTypeId", jobTypeId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "JobType deleted successfully";
        }
    }
}
