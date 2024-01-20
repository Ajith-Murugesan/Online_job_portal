using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data_Access_Layer.Repositories
{
    public class ExperienceDetailsRepository : IExperienceDetailsRepository
    {
        private readonly IConfiguration _config;

        public ExperienceDetailsRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<ExperienceDetails> GetExperienceDetails(int userAccountId)
        {
            ExperienceDetails experienceDetails = new ExperienceDetails();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, is_current_job, start_date, end_date, job_title, company_name FROM experience_details WHERE user_account_id = @UserAccountId", con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            experienceDetails.UserAccountId = reader.GetInt32(0);
                            experienceDetails.IsCurrentJob = reader.GetString(1);
                            experienceDetails.StartDate = reader.GetDateTime(2);
                            experienceDetails.EndDate = reader.GetDateTime(3);
                            experienceDetails.JobTitle = reader.GetString(4);
                            experienceDetails.CompanyName = reader.GetString(5);
                        }
                    }
                }
            }

            return experienceDetails;
        }

        public async Task<ICollection<ExperienceDetails>> GetAllExperienceDetails()
        {
            List<ExperienceDetails> experienceDetailsList = new List<ExperienceDetails>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, is_current_job, start_date, end_date, job_title, company_name FROM experience_details", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        experienceDetailsList.Add(new ExperienceDetails
                        {
                            UserAccountId = reader.GetInt32(0),
                            IsCurrentJob = reader.GetString(1),
                            StartDate = reader.GetDateTime(2),
                            EndDate = reader.GetDateTime(3),
                            JobTitle = reader.GetString(4),
                            CompanyName = reader.GetString(5),
                        });
                    }
                }
            }

            return experienceDetailsList;
        }

        public async Task<ExperienceDetails> CreateExperienceDetails(ExperienceDetails experienceDetails)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO experience_details (user_account_id, is_current_job, start_date, end_date, job_title, company_name) VALUES (@UserAccountId, @IsCurrentJob, @StartDate, @EndDate, @JobTitle, @CompanyName);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", experienceDetails.UserAccountId);
                    cmd.Parameters.AddWithValue("@IsCurrentJob", experienceDetails.IsCurrentJob);
                    cmd.Parameters.AddWithValue("@StartDate", experienceDetails.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", experienceDetails.EndDate);
                    cmd.Parameters.AddWithValue("@JobTitle", experienceDetails.JobTitle);
                    cmd.Parameters.AddWithValue("@CompanyName", experienceDetails.CompanyName);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return experienceDetails;
        }

        public async Task<ExperienceDetails> UpdateExperienceDetails(ExperienceDetails updatedExperienceDetails)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE experience_details SET is_current_job = @IsCurrentJob, start_date = @StartDate, end_date = @EndDate, job_title = @JobTitle, company_name = @CompanyName WHERE user_account_id = @UserAccountId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", updatedExperienceDetails.UserAccountId);
                    cmd.Parameters.AddWithValue("@IsCurrentJob", updatedExperienceDetails.IsCurrentJob);
                    cmd.Parameters.AddWithValue("@StartDate", updatedExperienceDetails.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", updatedExperienceDetails.EndDate);
                    cmd.Parameters.AddWithValue("@JobTitle", updatedExperienceDetails.JobTitle);
                    cmd.Parameters.AddWithValue("@CompanyName", updatedExperienceDetails.CompanyName);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedExperienceDetails;
        }

        public async Task<string> DeleteExperienceDetails(int userAccountId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM experience_details WHERE user_account_id = @UserAccountId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "ExperienceDetails deleted successfully";
        }
    }
}
