using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
    }
}
