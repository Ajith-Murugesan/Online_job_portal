using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data_Access_Layer.Repositories
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly IConfiguration _config;

        public JobPostRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<JobPost> GetJobPost(int jobPostId)
        {
            JobPost jobPost = new JobPost();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT job_post_id, user_account_id, company_id, job_type_id, job_description, created_date, location_id, is_active FROM job_post WHERE job_post_id = @JobPostId", con))
                {
                    cmd.Parameters.AddWithValue("@JobPostId", jobPostId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            jobPost.JobPostId = reader.GetInt32(0);
                            jobPost.UserAccountId = reader.GetInt32(1);
                            jobPost.CompanyId = reader.GetInt32(2);
                            jobPost.JobTypeId = reader.GetInt32(3);
                            jobPost.JobDescription = reader.GetString(4);
                            jobPost.CreatedDate = reader.GetDateTime(5);
                            jobPost.LocationId = reader.GetInt32(6);
                            jobPost.IsActive = reader.GetString(7);
                        }
                    }
                }
            }

            return jobPost;
        }

        public async Task<ICollection<JobPost>> GetAllJobPosts()
        {
            List<JobPost> jobPosts = new List<JobPost>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT job_post_id, user_account_id, company_id, job_type_id, job_description, created_date, location_id, is_active FROM job_post", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        jobPosts.Add(new JobPost
                        {
                            JobPostId = reader.GetInt32(0),
                            UserAccountId = reader.GetInt32(1),
                            CompanyId = reader.GetInt32(2),
                            JobTypeId = reader.GetInt32(3),
                            JobDescription = reader.GetString(4),
                            CreatedDate = reader.GetDateTime(5),
                            LocationId = reader.GetInt32(6),
                            IsActive = reader.GetString(7)
                        });
                    }
                }
            }

            return jobPosts;
        }

        public async Task<JobPost> CreateJobPost(JobPost jobPost)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO job_post (user_account_id, company_id, job_type_id, job_description, created_date, location_id, is_active) " +
                                     "VALUES (@UserAccountId, @CompanyId, @JobTypeId, @JobDescription, @CreatedDate, @LocationId, @IsActive);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", jobPost.UserAccountId);
                    cmd.Parameters.AddWithValue("@CompanyId", jobPost.CompanyId);
                    cmd.Parameters.AddWithValue("@JobTypeId", jobPost.JobTypeId);
                    cmd.Parameters.AddWithValue("@JobDescription", jobPost.JobDescription);
                    cmd.Parameters.AddWithValue("@CreatedDate", jobPost.CreatedDate);
                    cmd.Parameters.AddWithValue("@LocationId", jobPost.LocationId);
                    cmd.Parameters.AddWithValue("@IsActive", jobPost.IsActive);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return jobPost;
        }

        public async Task<JobPost> UpdateJobPost(JobPost updatedJobPost)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE job_post SET user_account_id = @UserAccountId, company_id = @CompanyId, job_type_id = @JobTypeId, " +
                                     "job_description = @JobDescription, created_date = @CreatedDate, location_id = @LocationId, is_active = @IsActive " +
                                     "WHERE job_post_id = @JobPostId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@JobPostId", updatedJobPost.JobPostId);
                    cmd.Parameters.AddWithValue("@UserAccountId", updatedJobPost.UserAccountId);
                    cmd.Parameters.AddWithValue("@CompanyId", updatedJobPost.CompanyId);
                    cmd.Parameters.AddWithValue("@JobTypeId", updatedJobPost.JobTypeId);
                    cmd.Parameters.AddWithValue("@JobDescription", updatedJobPost.JobDescription);
                    cmd.Parameters.AddWithValue("@CreatedDate", updatedJobPost.CreatedDate);
                    cmd.Parameters.AddWithValue("@LocationId", updatedJobPost.LocationId);
                    cmd.Parameters.AddWithValue("@IsActive", updatedJobPost.IsActive);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedJobPost;
        }

        public async Task<string> DeleteJobPost(int jobPostId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM job_post WHERE job_post_id = @JobPostId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@JobPostId", jobPostId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "JobPost deleted successfully";
        }
    }
}
