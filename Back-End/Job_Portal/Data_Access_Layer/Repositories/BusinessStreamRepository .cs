using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data_Access_Layer.Repositories
{
    public class BusinessStreamRepository : IBusinessStreamRepository
    {
        private readonly IConfiguration _config;

        public BusinessStreamRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<BusinessStream> GetBusinessStream(int streamId)
        {
            BusinessStream businessStream = new BusinessStream();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT stream_id, stream_name FROM business_stream WHERE stream_id = @StreamId", con))
                {
                    cmd.Parameters.AddWithValue("@StreamId", streamId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            businessStream.StreamId = reader.GetInt32(0);
                            businessStream.StreamName = reader.GetString(1);
                        }
                    }
                }
            }

            return businessStream;
        }

        public async Task<ICollection<BusinessStream>> GetAllBusinessStreams()
        {
            List<BusinessStream> businessStreams = new List<BusinessStream>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT stream_id, stream_name FROM business_stream", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        businessStreams.Add(new BusinessStream
                        {
                            StreamId = reader.GetInt32(0),
                            StreamName = reader.GetString(1)
                        });
                    }
                }
            }

            return businessStreams;
        }

        public async Task<BusinessStream> CreateBusinessStream(BusinessStream businessStream)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO business_stream (stream_name) VALUES (@StreamName);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@StreamName", businessStream.StreamName);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return businessStream;
        }

        public async Task<BusinessStream> UpdateBusinessStream(BusinessStream updatedBusinessStream)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE business_stream SET stream_name = @StreamName WHERE stream_id = @StreamId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@StreamId", updatedBusinessStream.StreamId);
                    cmd.Parameters.AddWithValue("@StreamName", updatedBusinessStream.StreamName);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedBusinessStream;
        }

        public async Task<string> DeleteBusinessStream(int streamId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM business_stream WHERE stream_id = @StreamId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@StreamId", streamId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "BusinessStream deleted successfully";
        }
    }
}
