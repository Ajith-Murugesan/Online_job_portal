using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data_Access_Layer.Repositories
{
    public class JobPostActivityRepository : IJobPostActivityRepository
    {
        private readonly IConfiguration _config;

        public JobPostActivityRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<JobPostActivity> GetJobPostActivity(int userAccountId, int jobPostId)
        {
            JobPostActivity jobPostActivity = new JobPostActivity();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, job_post_id, apply_date FROM job_post_activity WHERE user_account_id = @UserAccountId AND job_post_id = @JobPostId", con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);
                    cmd.Parameters.AddWithValue("@JobPostId", jobPostId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            jobPostActivity.UserAccountId = reader.GetInt32(0);
                            jobPostActivity.JobPostId = reader.GetInt32(1);
                            jobPostActivity.ApplyDate = reader.GetDateTime(2);
                        }
                    }
                }
            }

            return jobPostActivity;
        }

        public async Task<ICollection<JobPostActivity>> GetAllJobPostActivities()
        {
            List<JobPostActivity> jobPostActivities = new List<JobPostActivity>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, job_post_id, apply_date FROM job_post_activity", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        jobPostActivities.Add(new JobPostActivity
                        {
                            UserAccountId = reader.GetInt32(0),
                            JobPostId = reader.GetInt32(1),
                            ApplyDate = reader.GetDateTime(2)
                        });
                    }
                }
            }

            return jobPostActivities;
        }

        public async Task<JobPostActivity> ApplyToJobPost(JobPostActivity jobPostActivity)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO job_post_activity (user_account_id, job_post_id, apply_date) " +
                                     "VALUES (@UserAccountId, @JobPostId, @ApplyDate);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", jobPostActivity.UserAccountId);
                    cmd.Parameters.AddWithValue("@JobPostId", jobPostActivity.JobPostId);
                    cmd.Parameters.AddWithValue("@ApplyDate", jobPostActivity.ApplyDate);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return jobPostActivity;
        }

        public async Task<string> WithdrawApplication(int userAccountId, int jobPostId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM job_post_activity WHERE user_account_id = @UserAccountId AND job_post_id = @JobPostId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);
                    cmd.Parameters.AddWithValue("@JobPostId", jobPostId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "Application withdrawn successfully";
        }
    }
}
