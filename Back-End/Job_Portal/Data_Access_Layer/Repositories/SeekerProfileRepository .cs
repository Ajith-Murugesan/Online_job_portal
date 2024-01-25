using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.Design;
using System.Data;

namespace Data_Access_Layer.Repositories
{
    public class SeekerProfileRepository : ISeekerProfileRepository
    {
        private readonly IConfiguration _config;

        public SeekerProfileRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<SeekerProfile> GetSeekerProfile(int userAccountId)
        {
            SeekerProfile seekerProfile = new SeekerProfile();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, first_name, last_name, current_salary FROM seeker_profile WHERE user_account_id = @UserAccountId", con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            seekerProfile.UserAccountId = reader.GetInt32(0);
                            seekerProfile.FirstName = reader.GetString(1);
                            seekerProfile.LastName = reader.GetString(2);
                            seekerProfile.CurrentSalary = reader.GetInt64(3);
                        }
                    }
                }
            }

            return seekerProfile;
        }

        public async Task<ICollection<SeekerProfile>> GetAllSeekerProfiles()
        {
            List<SeekerProfile> seekerProfiles = new List<SeekerProfile>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, first_name, last_name, current_salary FROM seeker_profile", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        seekerProfiles.Add(new SeekerProfile
                        {
                            UserAccountId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            CurrentSalary = reader.GetInt64(3)
                        });
                    }
                }
            }

            return seekerProfiles;
        }

        public async Task<SeekerProfile> CreateSeekerProfile(SeekerProfile seekerProfile)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO seeker_profile (user_account_id, first_name, last_name, current_salary) VALUES (@UserAccountId, @FirstName, @LastName, @CurrentSalary);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", seekerProfile.UserAccountId);
                    cmd.Parameters.AddWithValue("@FirstName", seekerProfile.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", seekerProfile.LastName);
                    cmd.Parameters.AddWithValue("@CurrentSalary", seekerProfile.CurrentSalary);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return seekerProfile;
        }

        public async Task<SeekerProfile> UpdateSeekerProfile(SeekerProfile updatedSeekerProfile)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE seeker_profile SET first_name = @FirstName, last_name = @LastName, current_salary = @CurrentSalary WHERE user_account_id = @UserAccountId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", updatedSeekerProfile.UserAccountId);
                    cmd.Parameters.AddWithValue("@FirstName", updatedSeekerProfile.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", updatedSeekerProfile.LastName);
                    cmd.Parameters.AddWithValue("@CurrentSalary", updatedSeekerProfile.CurrentSalary);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedSeekerProfile;
        }

        public async Task<string> DeleteSeekerProfile(int userAccountId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM seeker_profile WHERE user_account_id = @UserAccountId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "SeekerProfile deleted successfully";
        }

        public async Task<EmailInvite> CreateInterviewInvite(EmailInvite invite)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("CreateInterviewInvite", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CompanyId", invite.CompanyId);
                    cmd.Parameters.AddWithValue("@JobPostId", invite.JobPostId);
                    cmd.Parameters.AddWithValue("@UserAccountId", invite.UserAccountId);
                    cmd.Parameters.AddWithValue("@LocationId", invite.LocationId);
                    cmd.Parameters.AddWithValue("@InterviewDate", invite.InterviewDate);
                    cmd.Parameters.AddWithValue("@InterviewTime", invite.InterviewTime);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return invite;
        }

        public async Task<ICollection<EmailInvite>> GetInterviewsById(int userId)
        {
            List<EmailInvite> emailInvites = new List<EmailInvite>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("GetInterviewDetailsByUserAccount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_account_id", userId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            emailInvites.Add(new EmailInvite
                            {
                                InterviewId = reader.GetInt32(0),
                                CompanyId = reader.GetInt32(1),
                                CompanyName = reader.GetString(2),
                                JobPostId = reader.GetInt32(3),
                                JobDescription = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                UserAccountId = reader.GetInt32(5),
                                UserName = reader.GetString(6),
                                LocationId = reader.GetInt32(7),
                                Address = reader.GetString(8),
                                City = reader.GetString(9),
                                InterviewDate = reader.GetDateTime(10).ToString(),
                                InterviewTime = reader.GetTimeSpan(11).ToString(),
                                IsAccepetd = reader.GetBoolean(12),
                                IsDeclined=reader.GetBoolean(13)
                            });
                        }
                    }
                }
            }

            return emailInvites;
        }

        public async Task<string> AcceptInvite(int userAccountId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE interview_invites SET is_accepted = 1 WHERE interview_id = @UserAccountId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);
                    

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "Invite Accepted";
        }

        public async Task<string> DeclineInvite(int userAccountId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE interview_invites SET is_declined = 1 WHERE interview_id = @UserAccountId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);


                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "Invite Declined";
        }
    }
}
