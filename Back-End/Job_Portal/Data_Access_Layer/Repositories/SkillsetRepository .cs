using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data_Access_Layer.Repositories
{
    public class SkillsetRepository : ISkillsetRepository
    {
        private readonly IConfiguration _config;

        public SkillsetRepository(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Skillset> GetSkillset(int skillsetId)
        {
            Skillset skillset = new Skillset();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT skillset_id, skillset_name FROM skillset WHERE skillset_id = @SkillsetId", con))
                {
                    cmd.Parameters.AddWithValue("@SkillsetId", skillsetId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            skillset.SkillsetId = reader.GetInt32(0);
                            skillset.SkillsetName = reader.GetString(1);
                        }
                    }
                }
            }

            return skillset;
        }

        public async Task<ICollection<Skillset>> GetAllSkillsets()
        {
            List<Skillset> skillsets = new List<Skillset>();

            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("SELECT skillset_id, skillset_name FROM skillset", con))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        skillsets.Add(new Skillset
                        {
                            SkillsetId = reader.GetInt32(0),
                            SkillsetName = reader.GetString(1)
                        });
                    }
                }
            }

            return skillsets;
        }

        public async Task<Skillset> CreateSkillset(Skillset skillset)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string insertQuery = "INSERT INTO skillset (skillset_name) VALUES (@SkillsetName);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@SkillsetName", skillset.SkillsetName);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return skillset;
        }

        public async Task<Skillset> UpdateSkillset(Skillset updatedSkillset)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string updateQuery = "UPDATE skillset SET skillset_name = @SkillsetName WHERE skillset_id = @SkillsetId;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@SkillsetId", updatedSkillset.SkillsetId);
                    cmd.Parameters.AddWithValue("@SkillsetName", updatedSkillset.SkillsetName);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return updatedSkillset;
        }

        public async Task<string> DeleteSkillset(int skillsetId)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await con.OpenAsync();

                string deleteQuery = "DELETE FROM skillset WHERE skillset_id = @SkillsetId;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@SkillsetId", skillsetId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return "Skillset deleted successfully";
        }
    }
}
