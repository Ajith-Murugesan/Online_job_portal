using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data_Access_Layer.Repositories
{
    public class JobLocationRepository : IJobLocationRepository
    {
        private readonly IConfiguration _config;

        public JobLocationRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<JobLocation> GetJobLocation(int locationId)
        {
            JobLocation jobLocation = new JobLocation();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT location_id, address, city, state, pincode FROM job_location WHERE location_id = @LocationId", con))
                {
                    cmd.Parameters.AddWithValue("@LocationId", locationId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            jobLocation.LocationId = reader.GetInt32(0);
                            jobLocation.Address = reader.GetString(1);
                            jobLocation.City = reader.GetString(2);
                            jobLocation.State = reader.GetString(3);
                            jobLocation.Pincode = reader.GetInt32(4);
                        }
                    }
                }
            }

            return jobLocation;
        }

        public async Task<ICollection<JobLocation>> GetAllJobLocations()
        {
            List<JobLocation> jobLocations = new List<JobLocation>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT location_id, address, city, state, pincode FROM job_location", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        jobLocations.Add(new JobLocation
                        {
                            LocationId = reader.GetInt32(0),
                            Address = reader.GetString(1),
                            City = reader.GetString(2),
                            State = reader.GetString(3),
                            Pincode = reader.GetInt32(4)
                        });
                    }
                }
            }

            return jobLocations;
        }

        public async Task<JobLocation> CreateJobLocation(JobLocation jobLocation)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO job_location (address, city, state, pincode) VALUES (@Address, @City, @State, @Pincode);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Address", jobLocation.Address);
                    cmd.Parameters.AddWithValue("@City", jobLocation.City);
                    cmd.Parameters.AddWithValue("@State", jobLocation.State);
                    cmd.Parameters.AddWithValue("@Pincode", jobLocation.Pincode);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return jobLocation;
        }

        public async Task<JobLocation> UpdateJobLocation(JobLocation updatedJobLocation)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE job_location SET address = @Address, city = @City, state = @State, pincode = @Pincode WHERE location_id = @LocationId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@LocationId", updatedJobLocation.LocationId);
                    cmd.Parameters.AddWithValue("@Address", updatedJobLocation.Address);
                    cmd.Parameters.AddWithValue("@City", updatedJobLocation.City);
                    cmd.Parameters.AddWithValue("@State", updatedJobLocation.State);
                    cmd.Parameters.AddWithValue("@Pincode", updatedJobLocation.Pincode);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedJobLocation;
        }

        public async Task<string> DeleteJobLocation(int locationId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM job_location WHERE location_id = @LocationId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@LocationId", locationId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "JobLocation deleted successfully";
        }
    }
}
