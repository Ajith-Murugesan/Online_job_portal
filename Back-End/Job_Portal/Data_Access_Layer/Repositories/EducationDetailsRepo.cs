using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Data_Access_Layer.Repositories
{
    public class EducationDetailsRepo:IEducationalDetails
    {

        private readonly IConfiguration _config;

        public EducationDetailsRepo(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<EducationalDetails> GetEducationalDetails(int userAccountId)
        {
            EducationalDetails educationalDetails = new EducationalDetails();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, degree_name, major, institute_name, starting_date, completion_date, percentage, cgpa FROM educational_details WHERE user_account_id = @UserAccountId", con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            educationalDetails.UserAccountId = reader.GetInt32(0);
                            educationalDetails.DegreeName = reader.GetString(1);
                            educationalDetails.Major = reader.GetString(2);
                            educationalDetails.InstituteName = reader.GetString(3);
                            educationalDetails.StartingDate = reader.GetDateTime(4);
                            educationalDetails.CompletionDate = reader.GetDateTime(5);
                            educationalDetails.Percentage = reader.GetInt32(6);
                            educationalDetails.CGPA = reader.GetInt32(7);
                        }
                    }
                }
            }

            return educationalDetails;
        }

        public async Task<ICollection<EducationalDetails>> GetAllEducationalDetails()
        {
            List<EducationalDetails> educationalDetailsList = new List<EducationalDetails>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT user_account_id, degree_name, major, institute_name, starting_date, completion_date, percentage, cgpa FROM educational_details", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        educationalDetailsList.Add(new EducationalDetails
                        {
                            UserAccountId = reader.GetInt32(0),
                            DegreeName = reader.GetString(1),
                            Major = reader.GetString(2),
                            InstituteName = reader.GetString(3),
                            StartingDate = reader.GetDateTime(4),
                            CompletionDate = reader.GetDateTime(5),
                            Percentage = reader.GetInt32(6),
                            CGPA = reader.GetInt32(7)
                        });
                    }
                }
            }

            return educationalDetailsList;
        }

        public async Task<EducationalDetails> CreateEducationalDetails(EducationalDetails educationalDetails)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO educational_details (user_account_id, degree_name, major, institute_name, starting_date, completion_date, percentage, cgpa) " +
                                     "VALUES (@UserAccountId, @DegreeName, @Major, @InstituteName, @StartingDate, @CompletionDate, @Percentage, @CGPA);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", educationalDetails.UserAccountId);
                    cmd.Parameters.AddWithValue("@DegreeName", educationalDetails.DegreeName);
                    cmd.Parameters.AddWithValue("@Major", educationalDetails.Major);
                    cmd.Parameters.AddWithValue("@InstituteName", educationalDetails.InstituteName);
                    cmd.Parameters.AddWithValue("@StartingDate", educationalDetails.StartingDate);
                    cmd.Parameters.AddWithValue("@CompletionDate", educationalDetails.CompletionDate);
                    cmd.Parameters.AddWithValue("@Percentage", educationalDetails.Percentage);
                    cmd.Parameters.AddWithValue("@CGPA", educationalDetails.CGPA);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return educationalDetails;
        }

        public async Task<EducationalDetails> UpdateEducationalDetails(EducationalDetails updatedEducationalDetails)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE educational_details SET degree_name = @DegreeName, major = @Major, " +
                                     "institute_name = @InstituteName, starting_date = @StartingDate, " +
                                     "completion_date = @CompletionDate, percentage = @Percentage, cgpa = @CGPA " +
                                     "WHERE user_account_id = @UserAccountId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", updatedEducationalDetails.UserAccountId);
                    cmd.Parameters.AddWithValue("@DegreeName", updatedEducationalDetails.DegreeName);
                    cmd.Parameters.AddWithValue("@Major", updatedEducationalDetails.Major);
                    cmd.Parameters.AddWithValue("@InstituteName", updatedEducationalDetails.InstituteName);
                    cmd.Parameters.AddWithValue("@StartingDate", updatedEducationalDetails.StartingDate);
                    cmd.Parameters.AddWithValue("@CompletionDate", updatedEducationalDetails.CompletionDate);
                    cmd.Parameters.AddWithValue("@Percentage", updatedEducationalDetails.Percentage);
                    cmd.Parameters.AddWithValue("@CGPA", updatedEducationalDetails.CGPA);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedEducationalDetails;
        }

        public async Task<string> DeleteEducationalDetails(int userAccountId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM educational_details WHERE user_account_id = @UserAccountId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@UserAccountId", userAccountId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "EducationalDetails deleted successfully";
        }
    }
}
